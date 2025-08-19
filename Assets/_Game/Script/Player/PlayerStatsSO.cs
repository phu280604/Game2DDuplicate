using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Stats/PlayerStats", order = 1)]
public class PlayerStatsSO : StatsSO
{
    #region --- Properties ---

    public float MaxHealthPoint => _maxHealthPoint;
    public float MovementSpeed => _movementSpeed;

    #endregion
}
