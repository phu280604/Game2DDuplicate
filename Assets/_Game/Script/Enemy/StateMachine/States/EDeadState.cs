using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EDeadState : BaseState<EnemyController, EnemyStateFactory>
{
    public EDeadState(EnemyController context, EnemyStateFactory stateFactory) : base(context, stateFactory) { }

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
            SwitchState(Fac.IdleState());
    }

    #endregion
}
