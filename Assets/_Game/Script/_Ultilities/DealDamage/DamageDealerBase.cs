using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageDealerBase<T> : MonoBehaviour
{
    #region --- Methods ---

    public abstract void DealDamage(GameObject target);
    public abstract void ReceiveDamage(float dmg);

    protected bool CheckDeadFlag(float curHP)
    {
        return curHP <= 0;
    }

    #endregion

    #region --- Fields ---

    [SerializeField] protected LayerMask _target;
    [SerializeField] protected T _ctrl;

    #endregion
}
