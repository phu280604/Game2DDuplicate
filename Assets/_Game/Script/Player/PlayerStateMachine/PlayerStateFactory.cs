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

    #endregion

    #region --- Fields ---

    private PlayerController _ctrl;

    #endregion
}
