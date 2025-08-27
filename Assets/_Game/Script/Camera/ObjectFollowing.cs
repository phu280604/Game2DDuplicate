using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectFollowing : MonoBehaviour
{
    #region --- Unity Methods ---

    private void Start()
    {
        _target = GameObject.FindGameObjectWithTag(_targetTag).transform;
    }

    private void FixedUpdate()
    {
        if(_useSmooth)
            transform.position = Vector3.Lerp(transform.position, _target.position + _offset, _smoothSpeed * Time.deltaTime);
        else
            transform.position = _target.position + _offset;
        
    }

    #endregion

    #region --- Fields ---

    [SerializeField] private string _targetTag;
    [SerializeField] private Transform _target;

    [SerializeField] private Vector3 _offset;
    [SerializeField] private bool _useSmooth = true;
    [SerializeField] private float _smoothSpeed;

    #endregion
}
