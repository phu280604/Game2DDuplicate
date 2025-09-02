using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageDealerBase<T> : MonoBehaviour
{
    #region --- Methods ---

    public abstract void DealDamage(GameObject target);
    public virtual void ReceiveDamage(float dmg)
    {
        if (_hitVFX != null && _hitPosSpawnVFX != null)
            Instantiate(_hitVFX, _hitPosSpawnVFX.transform.position, _hitPosSpawnVFX.transform.rotation).SetActive(true);
    }

    protected bool CheckDeadFlag(float curHP)
    {
        return curHP <= 0;
    }

    #endregion

    #region --- Fields ---

    [SerializeField] protected LayerMask _target;
    [SerializeField] protected T _ctrl;

    [SerializeField] protected GameObject _hitVFX;
    [SerializeField] protected Transform _hitPosSpawnVFX;

    #endregion
}
