using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : BaseController<int, PlayerController>, IStateController<BaseState<PlayerController, PlayerStateFactory>>
{
    #region --- Overrides ---

    public BaseState<PlayerController, PlayerStateFactory> CurrentState { get; set; }

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
        //Debug.Log(CurrentState.GetType().Name);
    }

    #endregion

    #region --- Methods ---

    public void OnInit()
    {
        // States.
        if(_states == null)
        {
            _states = new PlayerStates();
            _states.SavePoint = _baseSpawner.position;
        }
        else
        {
            _states.OnInit(gameObject); 
            IsGround();
        }

        // Stats.
        if (_stats == null)
            _stats = Resources.Load<PlayerStatsSO>("PlayerSO/PlayerStats");
        _stats.OnInit();
        NotifyObserver(LayerMask.NameToLayer(NameLayer.HealthBar), this);

        // Finite State Machine.
        if (_stateFactory == null)
            _stateFactory = new PlayerStateFactory(this);
        CurrentState = _stateFactory.IdleState();
        CurrentState.Enter();
    }

    public void OnDespawn()
    {
        _states.IsDead = true;
        _stats.CurrentHealthPoint = 0;
        NotifyObserver(LayerMask.NameToLayer(NameLayer.HealthBar), this);
    }

    private void IsGround()
    {
        Vector3 point = gameObject.transform.localPosition;
        float length = 1.9f;

        Debug.DrawLine(point, point + Vector3.down * length, Color.green);

        LayerMask mask = (1 << LayerMask.NameToLayer(NameLayer.Ground)) | (1 << LayerMask.NameToLayer(NameLayer.MovingPlatform));
        RaycastHit2D hit = Physics2D.Raycast(point, Vector2.down, length, mask);

        _states.IsGround = hit.collider != null;

        if (_states.IsGround)
        {
            _states.JumpTriggered = false;
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

    public PlayerStates States => _states;
    public PlayerStatsSO Stats => _stats;

    #endregion

    #region --- Fields ---

    [SerializeField] private Rigidbody2D _rg2D;
    [SerializeField] private Collider2D _col2D;
    [SerializeField] private Animator _anim;

    [SerializeField] private Transform _baseSpawner;

    private PlayerStateFactory _stateFactory;
    private PlayerStates _states;
    private PlayerStatsSO _stats;

    #endregion
}
