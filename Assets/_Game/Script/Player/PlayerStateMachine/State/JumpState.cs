using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : BaseState<PlayerController, PlayerStateFactory>
{
    public JumpState(PlayerController context, PlayerStateFactory stateFactory) : base(context, stateFactory) { }

    #region --- Overrides ---

    public override void Enter()
    {
        Ctrl.Anim.Play("Jump");
        Ctrl.States.JumpTriggered = true;

        if(Mathf.Abs(Ctrl.Rg2D.velocity.y) <= 0.01f)
            JumpHandle();
    }

    public override void Execute()
    {
        CheckSwitchState();
    }

    public override void Exit()
    {
        
    }

    protected override void CheckSwitchState()
    {
        if (Ctrl.States.IsDead)
        {
            SwitchState(Fac.DeadState());
            return;
        }

        if (!Ctrl.States.IsGround && Ctrl.Rg2D.velocity.y < 0.1f)
        {
            SwitchState(Fac.FallState());
            return;
        }

        if (Mathf.Abs(Ctrl.States.Dir) > 0.1f)
            SwitchState(Fac.RunState());
        else
            SwitchState(Fac.IdleState());
    }

    #endregion

    #region --- Methods ---

    private void JumpHandle()
    {
        Ctrl.Rg2D.AddForce(Vector2.up * Ctrl.Stats.JumpForce, ForceMode2D.Impulse);
    }

    #endregion

    #region --- Fields ---

    private float _currentSpeed;

    #endregion
}
