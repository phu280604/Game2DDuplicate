using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateController<TState>
{
    public TState CurrentState { get; set; }
}
