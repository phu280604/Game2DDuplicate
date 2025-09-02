using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageDealer : DamageDealerBase<PlayerController>
{
    #region --- Overrides ---

    public override void DealDamage(GameObject target)
    {
        target.GetComponent<EnemyDamageDealerBase>()?.ReceiveDamage(_ctrl.Stats.Damage);
    }

    public override void ReceiveDamage(float dmg)
    {
        if (_ctrl.States.IsDead) return;

        _ctrl.Stats.CurrentHealthPoint -= dmg;

        _ctrl.States.IsDead = CheckDeadFlag(_ctrl.Stats.CurrentHealthPoint);

        if(_ctrl.States.IsDead)
            _ctrl.OnDespawn();

        _ctrl.NotifyObserver(LayerMask.NameToLayer(NameLayer.HealthBar), _ctrl);

        base.ReceiveDamage(dmg);
    }

    #endregion

    #region --- Unity Methods ---

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int objLayer = collision.gameObject.layer;

        // Kiem tra layer co nam trong LayerMask khong?
        if ((_target.value & (1 << objLayer)) != 0)
        {
            DealDamage(collision.gameObject);
        }
    }

    #endregion
}
