using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    #region --- Unity Methods ---

    private void Start()
    {
        _timer = _respawnTime;
        _isRespawning = false;
    }
    private void Update()
    {
        if(_isRespawning && _timer > 0f)
            _timer -= Time.deltaTime;
        else if(_timer <= 0f)
            RespawnPlayer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _timer = _respawnTime;
        _isRespawning = true;
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if(_ctrl == null)
                _ctrl = collision.GetComponent<PlayerController>();
            _ctrl.OnDespawn();
        }
    }

    #endregion

    #region --- Methods ---

    private void RespawnPlayer()
    {
        Debug.Log("Respawn Player");
        _ctrl.OnInit();
        _timer = _respawnTime;
        _isRespawning = false;
    }

    #endregion

    #region --- Fields ---

    private bool _isRespawning;

    private PlayerController _ctrl;

    [SerializeField] private float _respawnTime;
    private float _timer;

    #endregion
}
