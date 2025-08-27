using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController<T, U> : MonoBehaviour
{

    #region --- Method ---

    public void AddObserver(T key, IObserver<U> value)
    {
        if (!_observers.ContainsKey(key))
        {
            _observers[key] = value;
        }
    }

    public void RemoveObserver(T key)
    {
        if(_observers.ContainsKey(key))
        {
            _observers.Remove(key);
        }
    }

    public void NotifyObserver(T key, U value)
    {
        if (_observers.ContainsKey(key))
        {
            _observers[key].OnNotify(value);
        }
    }

    #endregion

    #region --- Fields ---

    private Dictionary<T, IObserver<U>> _observers = new Dictionary<T, IObserver<U>>();

    #endregion
}
