using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : BaseState<PlayerController, PlayerStateFactory>
{
    public DeadState(PlayerController context, PlayerStateFactory stateFactory) : base(context, stateFactory) { }

    #region --- Overrides ---

    public override void Enter() 
    {
        Ctrl.Anim.Play("Dead");
    }

    public override void Execute() 
    {
        CheckSwitchState();
    }

    public override void Exit() { }

    protected override void CheckSwitchState() 
    {
        if (!Ctrl.States.IsDead)
        {
            SwitchState(Fac.IdleState());
            return;
        }

    }

    #endregion
}
