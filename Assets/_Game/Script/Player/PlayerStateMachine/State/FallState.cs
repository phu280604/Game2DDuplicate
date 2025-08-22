using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : BaseState<PlayerController, PlayerStateFactory>
{
    public FallState(PlayerController context, PlayerStateFactory stateFactory) : base(context, stateFactory) { }

    #region --- Overrides ---

    protected override void Enter() 
    {
        Ctrl.Anim.Play("JumpOut");

        Ctrl.States.IsJumping = false;
    }

    public override void Execute()
    {
        
        CheckSwitchState();
    }

    protected override void Exit() { }

    protected override void CheckSwitchState()
    {
        if (Mathf.Abs(Ctrl.States.Dir) > 0.1f)
            SwitchState(Fac.RunState());
        else if (Ctrl.States.IsGround)
            SwitchState(Fac.IdleState());

    }

    #endregion

    #region --- Fields ---

    private float _currentSpeed;

    #endregion
}
