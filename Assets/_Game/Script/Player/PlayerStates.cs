using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : States
{
    #region --- Properties ---

    public bool IsJumping { get; set; } = false;
    public bool JumpTriggered { get; set; } = false;
    public bool IsAttacking { get; set; } = false;
    public bool IsRangeAttacking { get; set; } = false;
    public bool AttackTriggered { get; set; } = false;
    public bool IsDashing { get; set; }

    #endregion
}
