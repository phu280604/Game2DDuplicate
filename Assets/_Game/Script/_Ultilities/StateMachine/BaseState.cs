using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState<T, U> where T : IStateController<BaseState<T, U>>
{
    public BaseState(T ctrl, U fac)
    {
        Ctrl = ctrl;
        Fac = fac;
    }

    #region --- Methods ---

    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();
    protected abstract void CheckSwitchState();
    protected void SwitchState(BaseState<T, U> newState)
    {
        if (Ctrl.CurrentState == null) return;

        Ctrl.CurrentState.Exit();

        Ctrl.CurrentState = newState;

        Ctrl.CurrentState.Enter();
        //string tmp = Ctrl.CurrentState.GetType().Name;
        //if (tmp[0] == 'E')
        //{
        //    Debug.Log(tmp);
        //}
        
    }

    #endregion

    #region --- Properties ---

    protected T Ctrl { get; set; }
    protected U Fac { get; set; }

    #endregion
}
