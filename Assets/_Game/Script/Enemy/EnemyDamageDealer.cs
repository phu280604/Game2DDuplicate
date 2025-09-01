using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageDealerBase : DamageDealerBase<EnemyController>
{
    #region --- Overrides ---

    public override void DealDamage(GameObject target)
    {
        target.GetComponent<PlayerDamageDealer>()?.ReceiveDamage(_ctrl.Stats.Damage);
    }

    public override void ReceiveDamage(float dmg)
    {
        if (_ctrl.States.IsDead) return;
        _ctrl.Stats.CurrentHealthPoint -= dmg;

        _ctrl.States.IsDead = CheckDeadFlag(_ctrl.Stats.CurrentHealthPoint);
        _ctrl.NotifyObserver(LayerMask.NameToLayer(NameLayer.HealthBar), _ctrl);
    }

    #endregion

    #region --- Unity Methods ---

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int objLayer = collision.gameObject.layer;

        // Kiểm tra layer có nằm trong LayerMask không
        if ((_target.value & (1 << objLayer)) != 0)
        {
            DealDamage(collision.gameObject);
        }
    }

    #endregion
}
