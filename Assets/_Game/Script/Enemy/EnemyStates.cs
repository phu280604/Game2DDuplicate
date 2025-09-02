using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStates : States
{
    #region --- Properties ---

    public GameObject Target { get; set; }
    public bool AttackTriggered { get; set; }

    #endregion
}
