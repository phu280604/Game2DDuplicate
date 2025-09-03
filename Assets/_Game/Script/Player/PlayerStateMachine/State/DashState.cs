using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : BaseState<PlayerController, PlayerStateFactory>
{
    public DashState(PlayerController context, PlayerStateFactory stateFactory) : base(context, stateFactory) { }

    #region --- Overrides ---

    public override void Enter() 
    {
        Ctrl.Anim.Play("Slide");
        _timer = 0;
        _curPos = Ctrl.transform.position;
        Vector2 dir = Ctrl.States.Dir > 0f ? Vector2.right : Vector2.left;
        _tarPos = (Vector2)Ctrl.transform.position + (dir * Ctrl.Stats.DashRange);
    }

    public override void Execute() 
    {
        OnDashing();

        CheckSwitchState();
    }

    public override void Exit() { }

    protected override void CheckSwitchState() 
    {
        if (Mathf.Abs(Vector2.Distance(Ctrl.transform.position, _tarPos)) <= 0.5f)
        {
            if (Mathf.Abs(Ctrl.States.Dir) > 0f)
                SwitchState(Fac.RunState());
            else
                SwitchState(Fac.IdleState());
        }
    }

    #endregion

    #region --- Methods ---

    private void OnDashing()
    {
        _timer += Time.fixedDeltaTime;
        float t = _timer / Ctrl.Stats.DashTime;

        Ctrl.transform.position = Vector3.Lerp(_curPos, _tarPos, t);
    }

    #endregion

    #region --- Fields ---

    private Vector2 _curPos;
    private Vector2 _tarPos;

    private float _timer;

    #endregion
}
