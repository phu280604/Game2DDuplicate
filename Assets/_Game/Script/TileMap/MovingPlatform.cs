using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    #region --- Unity Methods ---

    private void Start()
    {
        _target = _startPoint.transform;
    }
    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(SwitchAnchor(collision.gameObject, _startPoint.name))
            _target = _endPoint.transform;
        else if (SwitchAnchor(collision.gameObject, _endPoint.name))
            _target = _startPoint.transform;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(NameLayer.Player))
            collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(NameLayer.Player))
            collision.transform.SetParent(null);
    }

    #endregion

    #region --- Methods ---

    private bool SwitchAnchor(GameObject target, string name) => target.name == name;

    #endregion

    #region --- Fields ---

    [SerializeField] private Transform _target;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;

    [SerializeField] private float _speed;

    #endregion
}
