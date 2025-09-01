using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : BaseState<PlayerController, PlayerStateFactory>
{
    public RunState(PlayerController context, PlayerStateFactory stateFactory) : base(context, stateFactory) { }

    #region --- Overrides ---

    public override void Enter() 
    {
        if (!Ctrl.States.IsAttacking && Ctrl.States.IsGround)
            Ctrl.Anim.Play("Run");
    }

    public override void Execute()
    {
        RunHandle();

        CheckSwitchState();
    }

    public override void Exit() { }

    protected override void CheckSwitchState()
    {
        if (Ctrl.States.IsDead)
        {
            SwitchState(Fac.DeadState());
            return;
        }


        if (Ctrl.States.IsAttacking)
        {
            SwitchState(Fac.MeleeAttackState());
            return;
        }

        if (!Ctrl.States.IsGround && Ctrl.Rg2D.velocity.y < 0.1f)
        {
            SwitchState(Fac.FallState());
            return;
        }

        if (Ctrl.States.IsJumping && !Ctrl.States.JumpTriggered)
            SwitchState(Fac.JumpState());
        else if (Mathf.Abs(Ctrl.States.Dir) < 0.1f)
            SwitchState(Fac.IdleState());
    }

    #endregion

    #region --- Methods ---

    private void RunHandle()
    {
        float sign = Mathf.Sign(Ctrl.States.Dir);
        if (Mathf.Abs(Ctrl.States.Dir) > 0.1f)
        {
            _currentSpeed = Ctrl.Stats.MovementSpeed;

            Ctrl.transform.rotation = Quaternion.Euler(0, Ctrl.States.Dir > 0 ? 0 : 180, 0);
        }
        else
            _currentSpeed = 0f;

        Ctrl.Rg2D.velocity = new Vector2(_currentSpeed * sign, Ctrl.Rg2D.velocity.y);
    }

    #endregion

    #region --- Fields ---

    private float _currentSpeed;

    #endregion
}
