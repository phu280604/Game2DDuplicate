using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetect : MonoBehaviour
{

    #region --- Methods ---

    public bool OnDetecting(float detectRange, LayerMask layer)
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, detectRange, layer);
        _detectRange= detectRange;
        if(hit != null)
        {
            Debug.DrawLine(transform.position, hit.transform.position, Color.red);
            return true;
        }

        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 8f);
    }

    #endregion

    #region --- Fields ---

    private float _detectRange;

    #endregion
}
