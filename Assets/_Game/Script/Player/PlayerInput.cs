using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public void Start()
    {
        _ctrl = GetComponent<PlayerController>();
    }

    public void GetMoveAxis(InputAction.CallbackContext context)
    {
        _ctrl.States.Dir = context.ReadValue<float>();
    }

    public void GetButtonJump(InputAction.CallbackContext context)
    {
        if (context.performed && _ctrl.States.IsGround)
            _ctrl.States.IsJumping = true;
        else if(context.performed && _ctrl.States.CanGliding)
            _ctrl.States.IsGliding = true;
        else if (context.canceled)
        {
            _ctrl.States.IsGliding = false;
            _ctrl.States.IsJumping = false;
        }
    }

    public void GetButtonSlide(InputAction.CallbackContext context)
    {
        if (context.performed && Mathf.Abs(_ctrl.States.Dir) > 0f)
        {
            _ctrl.States.IsDashing = true;
            Debug.Log(_ctrl.States.IsDashing);
        }
        
        if(context.canceled && _ctrl.States.IsDashing)
        {
            _ctrl.States.IsDashing = false;
        }
    }

    public void GetButtonAttack(InputAction.CallbackContext context)
    {
        if (context.performed && _ctrl.States.IsGround)
        {
            _ctrl.States.IsAttacking = true;
        }
    }

    public void GetButtonRangeAttack(InputAction.CallbackContext context)
    {
        if (context.performed && _ctrl.States.IsGround)
        {
            _ctrl.States.IsRangeAttacking = true;
        }
    }

    #region --- Fields ---

    private PlayerController _ctrl;

    #endregion
}
