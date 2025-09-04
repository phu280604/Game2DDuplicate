using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlyingObject : MonoBehaviour
{
    #region --- Unity Methods ---

    private void Start()
    {
        OnInit();
    }

    private void Update()
    {
        CheckDespawn();
        OnFlying();
    }

    #endregion

    #region --- Methods ---

    private void OnInit()
    {
        _canDestroy = false;
        _animCtrl.Play(_animName);
    }

    private void OnDespawn()
    {
        Destroy(gameObject);
    }

    private void CheckDespawn()
    {
        _canDestroy = _animCtrl.GetBool("canDestroy");

        if(_canDestroy)
            OnDespawn();
    }

    private void OnFlying()
    {
        transform.Translate(_dir * _speed * Time.deltaTime, Space.World);
    }

    public void ChangeText(string text)
    {
        _text.text = text;
    }

    #endregion

    #region --- Fields ---

    [SerializeField] private Animator _animCtrl;
    [SerializeField] private string _animName;

    [SerializeField] private TextMeshProUGUI _text;

    [SerializeField] private Vector2 _dir;
    [SerializeField] private float _speed;

    private bool _canDestroy;

    #endregion
}
