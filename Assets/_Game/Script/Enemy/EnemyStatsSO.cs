using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Stats/EnemyStats", order = 1)]
public class EnemyStatsSO : StatsSO
{
    #region --- Properties ---

    public float MaxHealthPoint => _maxHealthPoint;
    public float MovementSpeed => _movementSpeed;

    public float PatrolRange => _patrolRange;
    public float DetectRange => _detectRange;
    public float AttackRange => _attackRange;
    public float Damage => _damage;

    #endregion

    #region --- fields ---

    [SerializeField] private float _patrolRange;
    [SerializeField] private float _detectRange;
    [SerializeField] private float _attackRange;

    #endregion
}
