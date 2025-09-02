using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetect : MonoBehaviour
{

    #region --- Methods ---

    public void OnDetecting(float detectRange, LayerMask layer, EnemyController ctrl)
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, detectRange, layer);

        if(hit != null)
        {
            Vector2 tarPos = hit.transform.position;
            Vector2 curPos = ctrl.transform.position;

            float dir = new Vector2(tarPos.x - curPos.x, tarPos.y - curPos.y).normalized.x;
            
            if(Mathf.Sign(dir) == Mathf.Sign(ctrl.States.Dir))
            {
                Debug.DrawLine(transform.position, hit.transform.position, Color.red);
                ctrl.States.Target = hit.gameObject;
                return;
            } 
        }

        ctrl.States.Target = null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 8f);
    }

    #endregion

}
