using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateFactory
{
    public EnemyStateFactory(EnemyController ctrl)
    {
        _ctrl = ctrl;
    }

    #region --- Methods ---

    public BaseState<EnemyController, EnemyStateFactory> IdleState() => new EIdleState(_ctrl, this);

    internal BaseState<EnemyController, EnemyStateFactory> PatrolState() => new EPatrolState(_ctrl, this);

    #endregion

    #region --- Fields ---

    private EnemyController _ctrl;

    #endregion
}
