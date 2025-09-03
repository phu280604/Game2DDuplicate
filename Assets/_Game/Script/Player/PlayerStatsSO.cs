using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Stats/PlayerStats", order = 1)]
public class PlayerStatsSO : StatsSO
{
    #region --- Properties ---

    public float MaxHealthPoint => _maxHealthPoint;
    public float MovementSpeed => _movementSpeed;
    public float Acceleration => _acceleration;
    public float Damage => _damage;
    public float RangeDamage => _rangeDamage;
    public float JumpForce => _jumpForce;

    public float RespawnTime => _respawnTime;
    public float DashTime => _dashTime;
    public float DashRange => _dashRange;

    #endregion

    #region --- Fields ---
    [SerializeField] private float _dashRange;

    [SerializeField] private float _respawnTime;
    [SerializeField] private float _dashTime;

    [SerializeField] private float _acceleration;

    [SerializeField] private float _jumpForce;
    [SerializeField] private float _rangeDamage;

    #endregion
}
