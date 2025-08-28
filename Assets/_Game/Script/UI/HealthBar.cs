using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour, IObserver<EnemyController>, IObserver<PlayerController>
{
    #region --- Overrides ---

    public void OnNotify(EnemyController value)
    {
        _curHealth = value.Stats.CurrentHealthPoint;

        ChangeHealthBar();
    }

    public void OnNotify(PlayerController value)
    {
        _curHealth = value.Stats.CurrentHealthPoint;
    }

    #endregion

    #region --- Unity Methods ---

    private void Start()
    {
        OnInit();
    }

    private void Update()
    {
        ChangeHealthBar();
    }

    #endregion

    #region --- Methods ---

    private void OnInit()
    {
        EnemyController enemyCtrl = _target.GetComponent<EnemyController>();
        PlayerController playerCtrl = _target.GetComponent<PlayerController>();

        if(enemyCtrl != null)
        {
            enemyCtrl.AddObserver(LayerMask.NameToLayer(NameLayer.HealthBar), this);
            _maxHealth = enemyCtrl.Stats.MaxHealthPoint;
            _curHealth = _maxHealth;
        }
        else if (playerCtrl != null)
        {
            playerCtrl.AddObserver(LayerMask.NameToLayer(NameLayer.HealthBar), this);
            _maxHealth = playerCtrl.Stats.MaxHealthPoint;
            _curHealth = _maxHealth;
        }
    }
    private void ChangeHealthBar()
    {
        _healthBar.value = Mathf.Lerp(_healthBar.value, _curHealth / _maxHealth, Time.deltaTime * 5f);
    }

    #endregion

    #region --- Fields ---

    [SerializeField] GameObject _target;
    [SerializeField] private Slider _healthBar;

    private float _curHealth;
    private float _maxHealth;

    #endregion
}
