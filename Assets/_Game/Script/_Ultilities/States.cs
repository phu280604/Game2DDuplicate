using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class States
{
    #region --- Properties ---

    public Vector2 SavePoint { get; set; }
    public float Dir { get; set; } = 1f;
    public bool IsGround { get; set; } = false;
    public bool IsDead { get; set; }

    #endregion

    #region --- Methods ---

    public void OnInit(GameObject target)
    {
        if (SavePoint != null)
            target.transform.position = (Vector3)SavePoint;
        else
            SavePoint = target.transform.position;

        IsDead = false;
    }

    #endregion
}
