using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    #region --- Unity Methods ---

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    #region --- Methods ---

    public void OnSpawn(GameObject obj, Vector2 spawnPos, Quaternion rotation)
    {
        Instantiate(obj, spawnPos, rotation).SetActive(true);
    }

    #endregion

    #region --- Fields ---

    public static SpawnerManager Instance { get; private set; }

    #endregion
}
