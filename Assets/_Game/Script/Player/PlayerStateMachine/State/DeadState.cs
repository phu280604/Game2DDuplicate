using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : BaseState<PlayerController, PlayerStateFactory>
{
    public DeadState(PlayerController context, PlayerStateFactory stateFactory) : base(context, stateFactory) { }

    #region --- Overrides ---

    public override void Enter() 
    {
        Ctrl.Anim.Play("Dead");
        _timer = Ctrl.Stats.RespawnTime;
    }

    public override void Execute() 
    {
        RespawnCountDown();

        CheckSwitchState();
    }

    public override void Exit() { }

    protected override void CheckSwitchState() 
    {
        if (!Ctrl.States.IsDead)
        {
            SwitchState(Fac.IdleState());
            return;
        }

    }

    #endregion

    #region --- Methods ---

    private void RespawnCountDown()
    {
        if (_timer > 0f)
            _timer -= Time.deltaTime;
        else if (_timer <= 0f)
            RespawnPlayer();
    }

    private void RespawnPlayer()
    {
        Ctrl.OnInit();
    }

    #endregion

    #region --- Fields ---

    private float _timer;

    #endregion
}
