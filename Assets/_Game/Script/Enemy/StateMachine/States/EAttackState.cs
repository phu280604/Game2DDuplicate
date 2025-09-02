using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EAttackState : BaseState<EnemyController, EnemyStateFactory>
{
    public EAttackState(EnemyController context, EnemyStateFactory stateFactory) : base(context, stateFactory) { }

    #region --- Overrides ---

    public override void Enter()
    {
        Ctrl.Anim.Play("Attack");
    }

    public override void Execute()
    {
        CheckSwitchState();
    }

    public override void Exit() { }

    protected override void CheckSwitchState()
    {
        if (Ctrl.States.AttackTriggered) return;

        if(Ctrl.States.Target != null)
        {
            Vector2 tarPos = Ctrl.States.Target.transform.position;
            Vector2 curPos = Ctrl.transform.position;

            float attackRange = Ctrl.Stats.AttackRange;
            if (Vector2.Distance(tarPos, curPos) <= attackRange)
                SwitchState(Fac.IdleState());
            else 
                SwitchState(Fac.PatrolState());

            return;
        }
        
        SwitchState(Fac.PatrolState());
    }

    #endregion
}
