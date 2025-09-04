using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region --- Unity Methods ---

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    #region --- Methods ---

    public void OnReset()
    {
        foreach(var eCtrl in _eCtrls)
        {
            eCtrl.SetActive(true);
            eCtrl.GetComponentInChildren<EnemyController>().OnInit();
        }

        foreach (var coin in _coins)
        {
            coin.SetActive(true);
        }
    }

    #endregion

    #region --- Fields ---

    public static GameManager Instance { get; private set; }

    [SerializeField] private List<GameObject> _eCtrls;
    [SerializeField] private List<GameObject> _coins;

    #endregion
}
