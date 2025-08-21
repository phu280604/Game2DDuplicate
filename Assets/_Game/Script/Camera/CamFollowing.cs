using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CamFollowing : MonoBehaviour
{
    #region --- Unity Methods ---

    private void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _target.position + _offset, _smoothSpeed * Time.deltaTime);
    }

    #endregion

    #region --- Fields ---

    [SerializeField] private Transform _target;

    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _smoothSpeed;

    #endregion
}
