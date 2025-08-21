using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, IStateController<BaseState<PlayerController, PlayerStateFactory>>
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

        CurrentState.Execute();

        //if (!_states.IsGround && _rg2D.velocity.y < 0f)
        //{
        //    FallHandle();
        //    Debug.Log("Fall");
        //}

        //AnimationHandle();
    }

    #endregion

    #region --- Methods ---

    private void OnInit()
    {
        _states = new PlayerStates();
        _stats = Resources.Load<PlayerStatsSO>("PlayerSO/PlayerStats");

        _stateFactory = new PlayerStateFactory(this);
        CurrentState = _stateFactory.IdleState();
    }

    public void GetMoveAxis(InputAction.CallbackContext context)
    {
        _states.Dir = context.ReadValue<float>();
        Debug.Log($"Move Axis: {_states.Dir}");
    }

    public void GetButtonJump(InputAction.CallbackContext context)
    {
        if (context.performed && _states.IsGround)
            JumpHandle();
    }

    public void GetButtonAttack(InputAction.CallbackContext context)
    {
        //if(context.performed && _states.IsGround)
        //{
            
        //    ChangeNameAnim("attack");

        //    Debug.Log("Attack performed");
        //}
    }

    private void IsGround()
    {
        Vector3 point = gameObject.transform.localPosition;
        float length = 1.9f;

        Debug.DrawLine(point, point + Vector3.down * length, Color.green);

        RaycastHit2D hit = Physics2D.Raycast(point, Vector2.down, length, _groundLayerMask);

        _states.IsGround = hit.collider != null;
    }

    private void JumpHandle()
    {
        _animTriggered = true;
        _states.IsJumping = true;
        _rg2D.AddForce(Vector2.up * _stats.JumpForce, ForceMode2D.Impulse);
    }

    private void FallHandle()
    {
        _animTriggered = true;
        _states.IsJumping = false;
    }

    private void AnimationHandle()
    {
        if (!_animTriggered) return;

        if (_states.IsGround && _states.IsJumping)
        {
            ChangeNameAnim("jump");
        }
        else if (!_states.IsGround && _rg2D.velocity.y < -0.1f)
        {
            ChangeNameAnim("fall");
        }
        else if (Mathf.Abs(_rg2D.velocity.x) > 0.1f && _states.IsGround)
        {
            ChangeNameAnim("run");
        }
        else if(_states.IsGround)
        {
            ChangeNameAnim("idle");
        }
        

        _animTriggered = false;
    }

    public void ChangeNameAnim(string nameAnim)
    {
        if(_currentAnimName != nameAnim)
        {
            _anim.ResetTrigger(nameAnim);
            _currentAnimName = nameAnim;
            _anim.SetTrigger(nameAnim);
        }
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

    [SerializeField] private LayerMask _groundLayerMask;

    private PlayerStateFactory _stateFactory;
    private PlayerStates _states;
    private PlayerStatsSO _stats;

    private string _currentAnimName = "";
    private bool _animTriggered = false;

    #endregion
}
