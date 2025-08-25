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
        Ctrl.Rg2D.velocity = new Vector2(0f, Ctrl.Rg2D.velocity.y);
        time += Time.fixedDeltaTime;
        CheckSwitchState();
    }

    public override void Exit() 
    {
        Ctrl.States.Dir *= -1;
    }


    protected override void CheckSwitchState()
    {
        if(time >= idleTime)
        {
            SwitchState(Fac.PatrolState());
        }
    }

    #endregion

    #region --- Fields ---

    private float time;
    private float idleTime;

    #endregion
}
