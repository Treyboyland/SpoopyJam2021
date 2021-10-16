using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventGeneric<T> : GameEvent
{
    [Tooltip("Value that will be sent whenever the game event is invoked")]
    [SerializeField]
    T value;

    /// <summary>
    /// Value that will be sent whenever the game event is invoked
    /// </summary>
    /// <value></value>
    public T Value
    {
        get
        {
            return value;
        }
        set
        {
            this.value = value;
        }
    }

    List<GameEventGenericListener<T>> genericListeners = new List<GameEventGenericListener<T>>();

    public void AddListener(GameEventGenericListener<T> toAdd)
    {
        if (!genericListeners.Contains(toAdd))
        {
            genericListeners.Add(toAdd);
        }
    }

    public void RemoveListener(GameEventGenericListener<T> toRemove)
    {
        genericListeners.Remove(toRemove);
    }

    public override void Invoke()
    {
        foreach (var listener in genericListeners)
        {
            listener.Response.Invoke(value);
        }

        foreach (var listener in listeners)
        {
            listener.Response.Invoke();
        }
    }
}


public class GameEventGeneric<T, U> : GameEvent
{
    [Tooltip("Value that will be sent whenever the game event is invoked")]
    [SerializeField]
    T value1;

    /// <summary>
    /// Value that will be sent whenever the game event is invoked
    /// </summary>
    /// <value></value>
    public T Value1
    {
        get
        {
            return value1;
        }
        set
        {
            this.value1 = value;
        }
    }

    [Tooltip("Other value that will be sent whenever the game event is invoked")]
    [SerializeField]
    U value2;

    /// <summary>
    /// Other value that will be sent whenever the game event is invoked
    /// </summary>
    /// <value></value>
    public U Value2
    {
        get
        {
            return value2;
        }
        set
        {
            Debug.LogWarning("New value: " + value);
            this.value2 = value;
        }
    }

    List<GameEventGenericListener<T, U>> genericListeners = new List<GameEventGenericListener<T, U>>();

    public void AddListener(GameEventGenericListener<T, U> toAdd)
    {
        if (!genericListeners.Contains(toAdd))
        {
            genericListeners.Add(toAdd);
        }
    }

    public void RemoveListener(GameEventGenericListener<T, U> toRemove)
    {
        genericListeners.Remove(toRemove);
    }

    public override void Invoke()
    {
        foreach (var listener in genericListeners)
        {
            listener.Response.Invoke(value1, value2);
        }

        foreach (var listener in listeners)
        {
            listener.Response.Invoke();
        }
    }
}