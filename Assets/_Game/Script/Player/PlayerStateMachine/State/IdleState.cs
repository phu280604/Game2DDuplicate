using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState<PlayerController, PlayerStateFactory>
{
    public IdleState(PlayerController context, PlayerStateFactory stateFactory) : base(context, stateFactory) { }

    #region --- Overrides ---

    public override void Enter() 
    {
        if(!Ctrl.States.IsAttacking && Ctrl.States.IsGround)
            Ctrl.Anim.Play("Idle");
    }

    public override void Execute()
    {
        Ctrl.Rg2D.velocity = new Vector2(0f, Ctrl.Rg2D.velocity.y);

        CheckSwitchState();
    }

    public override void Exit() { }


    protected override void CheckSwitchState()
    {
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
        else if(Mathf.Abs(Ctrl.States.Dir) > 0.1f)
            SwitchState(Fac.RunState());
    }

    #endregion
}
