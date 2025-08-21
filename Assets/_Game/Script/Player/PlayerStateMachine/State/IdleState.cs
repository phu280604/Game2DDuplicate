using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState<PlayerController, PlayerStateFactory>
{
    public IdleState(PlayerController context, PlayerStateFactory stateFactory) : base(context, stateFactory) { }

    #region --- Overrides ---

    protected override void Enter()
    {
        Ctrl.ChangeNameAnim("idle");
    }

    public override void Execute()
    {
        Ctrl.Rg2D.velocity = new Vector2(0f, Ctrl.Rg2D.velocity.y);

        CheckSwitchState();
    }

    protected override void Exit()
    {
        
    }

    protected override void CheckSwitchState()
    {
        if(Mathf.Abs(Ctrl.States.Dir) > 0.1f)
        {
            SwitchState(Fac.RunState());
        }
    }

    #endregion
}
