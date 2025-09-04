using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingCoin : MonoBehaviour
{
    #region --- Unity Methods ---

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer(NameLayer.Coin))
        {
            _ctrl.NotifyObserver(LayerMask.NameToLayer(NameLayer.Coin), _ctrl);
            collision.gameObject.SetActive(false);
        }
    }

    #endregion

    #region --- Fields ---

    [SerializeField] private PlayerController _ctrl;

    #endregion
}
