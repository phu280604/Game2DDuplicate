using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EPatrolState : BaseState<EnemyController, EnemyStateFactory>
{
    public EPatrolState(EnemyController context, EnemyStateFactory stateFactory) : base(context, stateFactory) { }

    #region --- Overrides ---

    public override void Enter()
    {
        Ctrl.Anim.Play("Run");

        Ctrl.transform.rotation = Quaternion.Euler(0, Ctrl.States.Dir < 0 ? 180 : 0, 0);

        anchorNext = Ctrl.States.SavePoint.x + (Ctrl.Stats.PatrolRange * Ctrl.States.Dir);
    }

    public override void Execute()
    {
        RunHandle();

        CheckSwitchState();
    }

    public override void Exit() 
    {
        Ctrl.Rg2D.velocity = new Vector2(0f, Ctrl.Rg2D.velocity.y);
    }

    protected override void CheckSwitchState()
    {
        if (Ctrl.States.IsDead)
        {
            SwitchState(Fac.DeadState());
            return;
        }

        float checkLength = CheckLength();
        if (checkLength <= 0.3f)
        {
            SwitchState(Fac.IdleState());
        }
    }

    #endregion

    #region --- Methods ---

    private void RunHandle()
    {
        Ctrl.Rg2D.velocity = new Vector2(Ctrl.States.Dir * Ctrl.Stats.MovementSpeed, Ctrl.Rg2D.velocity.y);
    }

    private float CheckLength()
    {
        float curPos = Ctrl.transform.position.x;

        return Mathf.Sqrt(Mathf.Pow(anchorNext - curPos, 2));
    }

    #endregion

    #region --- Fields ---

    private float anchorNext;

    #endregion
}
