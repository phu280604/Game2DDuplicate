using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageDealer<T> : MonoBehaviour
{
    #region --- Methods ---

    protected abstract void DealDamage(Collider target);
    protected abstract void ReceiveDamage(float dmg);

    #endregion

    #region --- Fields ---

    [SerializeField] protected LayerMask _target;
    [SerializeField] protected T _ctrl;

    #endregion
}
