using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingWeapon : MonoBehaviour
{
    #region --- Unity Methods ---

    private void OnEnable()
    {
        Invoke(nameof(OnDeSpawn), _despawnTime);
        _moveV = transform.eulerAngles.y <= 0 ? Vector2.right : Vector2.left;
        
    }

    public void FixedUpdate()
    {
        if (!gameObject.activeSelf) return;

        MoveWeapon();
    }

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

    #region --- Methods ---

    private void MoveWeapon()
    {
        _rg2D.velocity = new Vector2(_moveV.x * _speed, 0);
    }

    private void OnDeSpawn()
    {
        Destroy(gameObject);
    }

    public void DealDamage(GameObject target)
    {
        target.GetComponent<EnemyDamageDealerBase>()?.ReceiveDamage(_ctrl.Stats.RangeDamage);
        OnDeSpawn();
    }

    #endregion

    #region --- Fields ---

    [SerializeField] private Rigidbody2D _rg2D;

    [SerializeField] private LayerMask _target;

    [SerializeField] private PlayerController _ctrl;
    [SerializeField] private float _despawnTime;

    [SerializeField] private float _speed;
    private Vector2 _moveV;

    #endregion
}
