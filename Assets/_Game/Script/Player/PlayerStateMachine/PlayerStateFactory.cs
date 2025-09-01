using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateFactory
{
    public PlayerStateFactory(PlayerController ctrl)
    {
        _ctrl = ctrl;
    }

    #region --- Methods ---

    public BaseState<PlayerController, PlayerStateFactory> IdleState() => new IdleState(_ctrl, this);
    public BaseState<PlayerController, PlayerStateFactory> RunState() => new RunState(_ctrl, this);
    public BaseState<PlayerController, PlayerStateFactory> JumpState() => new JumpState(_ctrl, this);
    public BaseState<PlayerController, PlayerStateFactory> FallState() => new FallState(_ctrl, this);
    public BaseState<PlayerController, PlayerStateFactory> DeadState() => new DeadState(_ctrl, this);
    public BaseState<PlayerController, PlayerStateFactory> MeleeAttackState() => new MeleeAttackState(_ctrl, this);

    #endregion

    #region --- Fields ---

    private PlayerController _ctrl;

    #endregion
}
