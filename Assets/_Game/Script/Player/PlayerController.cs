using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region --- Unity Methods ---

    private void Start()
    {
        _states = new PlayerStates();
        _stats = Resources.Load<PlayerStatsSO>("PlayerSO/PlayerStats");
    }

    private void FixedUpdate()
    {
        IsGround();

        MoveHandle();
    }

    #endregion

    #region --- Methods ---

    private void IsGround()
    {
        Vector3 point = gameObject.transform.localPosition;
        float length = 1.9f;

        Debug.DrawLine(point, point + Vector3.down * length, Color.green);

        RaycastHit2D hit = Physics2D.Raycast(point, Vector2.down, length, _groundLayerMask);

        _states.IsGround = hit.collider != null;
    }

    private void MoveHandle()
    {
        float moveInput = Input.GetAxis("Horizontal");
        if(moveInput != 0)
        {
            ChangeNameAnim("run");
            _rg2D.velocity = new Vector2(moveInput * _stats.MovementSpeed, _rg2D.velocity.y);
            gameObject.transform.rotation = Quaternion.Euler(0, moveInput > 0 ? 0 : 180, 0);
        }
        else
        {
            ChangeNameAnim("idle");
            _rg2D.velocity = new Vector2(0, _rg2D.velocity.y);
        }
    }

    private void ChangeNameAnim(string nameAnim)
    {
        if(_currentAnimName != nameAnim)
        {
            _anim.ResetTrigger(nameAnim);
            _currentAnimName = nameAnim;
            _anim.SetTrigger(nameAnim);
        }
    }

    #endregion

    #region --- Fields ---

    [SerializeField] private Rigidbody2D _rg2D;
    [SerializeField] private Collider2D _col2D;
    [SerializeField] private Animator _anim;

    [SerializeField] private LayerMask _groundLayerMask;

    private PlayerStates _states;
    private PlayerStatsSO _stats;

    private string _currentAnimName = "";

    #endregion
}
