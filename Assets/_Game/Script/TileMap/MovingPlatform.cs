using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    #region --- Unity Methods ---

    private void Start()
    {
        _dir = GetDirection(transform.position, _startPoint.position);
    }
    private void Update()
    {
        _rd2D.velocity = _speed * _dir;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(SwitchAnchor(collision.gameObject, _startPoint.name))
            _dir = GetDirection(transform.position, _endPoint.position);
        else if (SwitchAnchor(collision.gameObject, _endPoint.name))
            _dir = GetDirection(transform.position, _startPoint.position);
    }

    

    #endregion

    #region --- Methods ---

    private bool SwitchAnchor(GameObject target, string name) => target.name == name;

    private Vector2 GetDirection(Vector2 startPoint, Vector2 endPoint) => new Vector2(endPoint.x - startPoint.x, endPoint.y - startPoint.y).normalized;

    #endregion

    #region --- Fields ---

    [SerializeField] private Rigidbody2D _rd2D;

    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;

    [SerializeField] private float _speed;
    private Vector2 _dir;

    #endregion
}
