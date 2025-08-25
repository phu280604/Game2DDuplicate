using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Stats/EnemyStats", order = 1)]
public class EnemyStatsSO : StatsSO
{
    #region --- Properties ---

    public float MaxHealthPoint => _maxHealthPoint;
    public float MovementSpeed => _movementSpeed;

    public float PatrolRange => patrolRange;
    public float DetectRange => detectRange;

    #endregion

    #region --- fields ---

    [SerializeField] private float patrolRange;
    [SerializeField] private float detectRange;

    #endregion
}
