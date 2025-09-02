using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    #region --- Unity Methods ---

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(NameLayer.Player))
        {
            if(_ctrl == null)
                _ctrl = collision.GetComponent<PlayerController>();
            _ctrl.OnDespawn();
        }
    }

    #endregion

    #region --- Fields ---

    private PlayerController _ctrl;

    #endregion
}
