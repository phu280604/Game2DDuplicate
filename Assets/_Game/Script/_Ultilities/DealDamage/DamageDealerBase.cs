using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class DamageDealerBase<T> : MonoBehaviour
{
    #region --- Unity Methods ---

    private void Awake()
    {
        _hitVFX = Resources.Load<GameObject>("Prefab/Hit_VFX");
        _flyingText = Resources.Load<GameObject>("Prefab/FlyingText");
    }

    #endregion

    #region --- Methods ---

    public abstract void DealDamage(GameObject target);
    public virtual void ReceiveDamage(float dmg)
    {
        if (_hitVFX != null && _hitPosSpawnVFX != null)
            SpawnerManager.Instance.OnSpawn(_hitVFX, _hitPosSpawnVFX.transform.position, _hitPosSpawnVFX.transform.rotation);

        if (_flyingText != null)
        {
            FlyingObject obj = _flyingText.GetComponent<FlyingObject>();
            obj.ChangeText($"-{dmg}");

            SpawnerManager.Instance.OnSpawn(_flyingText, this.transform.position, _flyingText.transform.rotation);
        }
    }

    protected bool CheckDeadFlag(float curHP)
    {
        return curHP <= 0;
    }

    #endregion

    #region --- Fields ---

    [SerializeField] protected LayerMask _target;
    [SerializeField] protected T _ctrl;

    protected GameObject _hitVFX;
    [SerializeField] protected Transform _hitPosSpawnVFX;

    protected GameObject _flyingText;

    #endregion
}
