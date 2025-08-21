using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region --- Unity Methods ---

    private void Start()
    {
        _states = new PlayerStates();
        _stats = Resources.Load<PlayerStatsSO>("PlayerSO/PlayerStats");
    }

    private void FixedUpdate()
    {
        IsGround();
        
        if (!_states.IsGround && _rg2D.velocity.y < 0f)
        {
            FallHandle();
            Debug.Log("Fall");
        }

        MoveHandle();

        AnimationHandle();
    }

    #endregion

    #region --- Methods ---

    public void GetMoveAxis(InputAction.CallbackContext context)
    {
        _dir = context.ReadValue<float>();
    }

    public void GetButtonJump(InputAction.CallbackContext context)
    {
        if (context.performed && _states.IsGround)
            JumpHandle();
    }

    public void GetButtonAttack(InputAction.CallbackContext context)
    {
        if(context.performed && _states.IsGround)
        {
            
            ChangeNameAnim("attack");

            Debug.Log("Attack performed");
        }
    }

    private void IsGround()
    {
        Vector3 point = gameObject.transform.localPosition;
        float length = 1.9f;

        Debug.DrawLine(point, point + Vector3.down * length, Color.green);

        RaycastHit2D hit = Physics2D.Raycast(point, Vector2.down, length, _groundLayerMask);

        _states.IsGround = hit.collider != null;
    }

    private void MoveHandle()
    {
        _states.IsAttacking = _anim.GetBool("isAttack");

        if(_states.IsAttacking)
        {
            _currentSpeed = 0f;
            return;
        }

        if (!_states.IsJumping && _states.IsGround)
            _animTriggered = true;

        float sign = Mathf.Sign(_dir);
        if (Mathf.Abs(_dir) > 0.1f)
        {
            _currentSpeed = _stats.MovementSpeed;

            gameObject.transform.rotation = Quaternion.Euler(0, _dir > 0 ? 0 : 180, 0);
        }
        else
        {
            _currentSpeed = 0f;
        }

        _rg2D.velocity = new Vector2(_currentSpeed * sign, _rg2D.velocity.y);
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

    private void ChangeNameAnim(string nameAnim)
    {
        if(_currentAnimName != nameAnim)
        {
            _anim.ResetTrigger(nameAnim);
            _currentAnimName = nameAnim;
            _anim.SetTrigger(nameAnim);
        }
    }

    #endregion

    #region --- Fields ---

    [SerializeField] private Rigidbody2D _rg2D;
    [SerializeField] private Collider2D _col2D;
    [SerializeField] private Animator _anim;

    [SerializeField] private LayerMask _groundLayerMask;

    private PlayerStates _states;
    private PlayerStatsSO _stats;

    private float _currentSpeed = 0f;
    private float _dir = 0f;
    private string _currentAnimName = "";
    private bool _animTriggered = false;

    #endregion
}
