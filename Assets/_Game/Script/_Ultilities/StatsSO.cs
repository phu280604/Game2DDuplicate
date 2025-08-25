using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsSO : ScriptableObject
{
    #region --- Methods ---

    public void OnInit()
    {
        CurrentHealthPoint = _maxHealthPoint;
    }

    #endregion

    #region --- Properties ---

    public float CurrentHealthPoint { get; set; }

    #endregion

    #region --- Fields ---

    [SerializeField] protected float _maxHealthPoint;
    [SerializeField] protected float _movementSpeed;
    [SerializeField] protected float _damage;

    #endregion
}
