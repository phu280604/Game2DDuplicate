using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyController : BaseController<int, EnemyController>, IStateController<BaseState<EnemyController, EnemyStateFactory>>
{
    #region --- Overrides ---

    public BaseState<EnemyController, EnemyStateFactory> CurrentState { get; set; }



    #endregion

    #region --- Unity Methods ---

    private void Awake()
    {
        OnInit();
    }

    private void FixedUpdate()
    {
        bool tmp = _detectTool.OnDetecting(_stats.DetectRange, _targetLayer);
        if(tmp)
        {
            Debug.Log("Detect Player");
        }

        CurrentState.Execute();
    }

    #endregion

    #region --- Methods ---

    private void OnInit()
    {
        // States.
        if (_states == null)
        {
            _states = new EnemyStates();
            _states.SavePoint = _baseEnemy.transform.position;
        }
        else
        {
            _states.OnInit(_baseEnemy);
        }

        // Stats.
        _stats = Resources.Load<EnemyStatsSO>("EnemySO/EnemyStats");
        _stats.OnInit();

        // Finite State Machine.
        _fac = new EnemyStateFactory(this);
        CurrentState = _fac.IdleState();
        CurrentState.Enter();
    }

    #endregion

    #region --- Properties ---

    public Rigidbody2D Rg2D => _rg2D;
    public Collider2D Col2D => _col2D;
    public Animator Anim => _anim;

    public EnemyStates States => _states;
    public EnemyStatsSO Stats => _stats;

    #endregion

    #region --- Fields ---

    [SerializeField] private Rigidbody2D _rg2D;
    [SerializeField] private Collider2D _col2D;
    [SerializeField] private Animator _anim;

    [SerializeField] private GameObject _baseEnemy;

    private EnemyStateFactory _fac;
    private EnemyStates _states;
    private EnemyStatsSO _stats;
    [SerializeField] private EnemyDetect _detectTool;

    [SerializeField] private LayerMask _groundLayerMask;
    [SerializeField] private LayerMask _targetLayer;

    #endregion
}
