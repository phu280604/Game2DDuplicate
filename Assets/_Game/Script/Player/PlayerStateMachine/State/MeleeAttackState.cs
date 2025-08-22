using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackState: BaseState<PlayerController, PlayerStateFactory>
{
    public MeleeAttackState(PlayerController context, PlayerStateFactory stateFactory) : base(context, stateFactory) { }

    #region --- Overrides ---

    protected override void Enter() 
    {
        Ctrl.Anim.Play("MeleeAttack1");
        StopMoving();
        AttackHandle();
    }

    public override void Execute()
    {
        CheckSwitchState();
    }

    protected override void Exit() 
    {
        Ctrl.States.IsAttacking = false;
    }

    protected override void CheckSwitchState()
    {
        if(Ctrl.States.AttackTriggered)
            return;

        if (Mathf.Abs(Ctrl.States.Dir) > 0.1f)
            SwitchState(Fac.RunState());
        else
            SwitchState(Fac.IdleState());
    }

    #endregion

    #region --- Methods ---

    private void AttackHandle()
    {
        
    }

    private void StopMoving()
    {
        Ctrl.Rg2D.velocity = new Vector2(0, Ctrl.Rg2D.velocity.y);
    }

    #endregion
}
