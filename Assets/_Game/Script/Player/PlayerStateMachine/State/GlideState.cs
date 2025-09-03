using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlideState : BaseState<PlayerController, PlayerStateFactory>
{
    public GlideState(PlayerController context, PlayerStateFactory stateFactory) : base(context, stateFactory) { }

    #region --- Overrides ---

    public override void Enter() 
    {
        Ctrl.Anim.Play("Glide");
        _preGraScal = Ctrl.Rg2D.gravityScale;
        Ctrl.Rg2D.gravityScale = 0.5f;

        Ctrl.Rg2D.velocity = new Vector2(Ctrl.Rg2D.velocity.x, 0);
    }

    public override void Execute() 
    {
        RunHandle();

        CheckSwitchState();
    }

    public override void Exit() 
    {
        Ctrl.Rg2D.gravityScale = _preGraScal;
        Ctrl.States.IsGliding = false;
    }

    protected override void CheckSwitchState() 
    {
        if (Ctrl.States.IsDead)
        {
            SwitchState(Fac.DeadState());
            return;
        }

        if (!Ctrl.States.IsGround) return;

        if (Mathf.Abs(Ctrl.States.Dir) > 0f)
            SwitchState(Fac.RunState());
        else
            SwitchState(Fac.IdleState());
    }

    #endregion

    #region --- Methods ---

    private void RunHandle()
    {
        float sign = Mathf.Sign(Ctrl.States.Dir);
        if (Mathf.Abs(Ctrl.States.Dir) > 0.1f)
        {
            _currentSpeed = Ctrl.Stats.MovementSpeed / 2;

            Ctrl.transform.rotation = Quaternion.Euler(0, Ctrl.States.Dir > 0 ? 0 : 180, 0);
        }
        else
            _currentSpeed = 0f;

        Ctrl.Rg2D.velocity = new Vector2(_currentSpeed * sign, Ctrl.Rg2D.velocity.y);
    }

    #endregion

    #region --- Fields ---

    private float _preGraScal;

    private float _currentSpeed;

    #endregion
}
