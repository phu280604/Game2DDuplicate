using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStates
{
    #region --- Properties ---

    public Vector2 AnchorPos { get; set; }

    public bool IsGround { get; set; } = false;
    public bool IsJumping { get; set; } = false;
    public bool JumpTriggered { get; set; } = false;
    public bool IsAttacking { get; set; } = false;
    public bool AttackTriggered { get; set; } = false;

    #endregion
}
