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
        
        GameObject deadVFX = Resources.Load<GameObject>("Prefab/Dead_VFX");
        SpawnerManager.Instance.OnSpawn(deadVFX, Ctrl.transform.position, deadVFX.transform.rotation);
    }

    public override void Execute()
    {
        OnHide();

        CheckSwitchState();
    }

    public override void Exit() { }

    protected override void CheckSwitchState()
    {
        if (!Ctrl.States.IsDead)
            SwitchState(Fac.IdleState());
    }

    #endregion

    #region --- Methods ---

    private void OnHide()
    {
        bool hideTriggered = Ctrl.Anim.GetBool("canHide");
        if (hideTriggered)
        {
            hideTriggered = false;
            Ctrl.OnDespawn();
        }
    }

    #endregion
}
