using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour, IObserver<PlayerController>
{
    #region --- Overrides ---

    public void OnNotify(PlayerController value)
    {
        _amount++;
        _text.text = _amount.ToString();
    }

    #endregion

    #region --- Unity Methods ---

    private void Start()
    {
        OnInit();
    }

    #endregion

    #region --- Methods ---

    private void OnInit()
    {
        _amount = 0;
        _text.text = _amount.ToString();
        _player.AddObserver(LayerMask.NameToLayer(NameLayer.Coin), this);
    }

    #endregion

    #region --- Fields ---

    [SerializeField] private PlayerController _player;

    [SerializeField] private TextMeshProUGUI _text;
    private int _amount;

    #endregion
}
