using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EIdleState : BaseState<EnemyController, EnemyStateFactory>
{
    public EIdleState(EnemyController context, EnemyStateFactory stateFactory) : base(context, stateFactory) { }

    #region --- Overrides ---

    public override void Enter()
    {
        time = 0f;
        idleTime = Random.Range(2, 5);
        Ctrl.Anim.Play("Idle");
    }

    public override void Execute()
    {
        time += Time.fixedDeltaTime;
        CheckSwitchState();
    }

    public override void Exit() 
    {
        if(Ctrl.States.Target == null)
            Ctrl.States.Dir *= -1;
    }

    protected override void CheckSwitchState()
    {
        if (Ctrl.States.IsDead)
        {
            SwitchState(Fac.DeadState());
            return;
        }

        if (time >= idleTime)
        {
            if(Ctrl.States.Target != null)
            {
                Vector2 tarPos = Ctrl.States.Target.transform.position;
                Vector2 curPos = Ctrl.transform.position;

                float attackRange = Ctrl.Stats.AttackRange;

                if (Vector2.Distance(tarPos, curPos) <= attackRange)
                {
                    SwitchState(Fac.AttackState());
                    return;
                }
            }

            SwitchState(Fac.PatrolState());
        }
    }

    #endregion

    #region --- Fields ---

    private float time;
    private float idleTime;

    #endregion
}
