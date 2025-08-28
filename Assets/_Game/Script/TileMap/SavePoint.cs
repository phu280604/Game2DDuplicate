using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    #region --- Unity Methods ---

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(NameLayer.Player))
        {
            PlayerController ctrl = collision.GetComponent<PlayerController>();
            ctrl.States.SavePoint = ctrl.transform.position;
        }
    }

    #endregion
}
