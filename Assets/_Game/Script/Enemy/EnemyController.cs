using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyController : MonoBehaviour, IStateController<BaseState<EnemyController, EnemyStateFactory>>
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
        IsGround();
        GetValueAnim();

        CurrentState.Execute();
    }

    #endregion

    #region --- Methods ---

    private void OnInit()
    {
        _states = new EnemyStates();
        _stats = Resources.Load<EnemyStatsSO>("EnemySO/EnemyStats");

        _fac = new EnemyStateFactory(this);
        CurrentState = _fac.IdleState();
        CurrentState.Enter();

    }

    private void IsGround()
    {
        Vector3 point = gameObject.transform.localPosition;
        float length = 1.9f;

        Debug.DrawLine(point, point + Vector3.down * length, Color.green);

        RaycastHit2D hit = Physics2D.Raycast(point, Vector2.down, length, _groundLayerMask);

        _states.IsGround = hit.collider != null;

        if (_states.IsGround)
        {
            _states.JumpTriggered = false;
            _states.AnchorPos = transform.position.x;
        }
    }

    private void GetValueAnim()
    {
        _states.AttackTriggered = _anim.GetBool("isAttack");
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

    [SerializeField] private LayerMask _groundLayerMask;

    private EnemyStateFactory _fac;
    private EnemyStates _states;
    private EnemyStatsSO _stats;

    #endregion
}
