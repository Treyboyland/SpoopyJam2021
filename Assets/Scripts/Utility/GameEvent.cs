using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "Events/Normal Event", order = -1)]
public class GameEvent : ScriptableObject
{
    protected List<GameEventListener> listeners = new List<GameEventListener>();

    public virtual void AddListener(GameEventListener toAdd)
    {
        if (!listeners.Contains(toAdd))
        {
            listeners.Add(toAdd);
        }
    }

    public virtual void RemoveListener(GameEventListener toRemove)
    {
        listeners.Remove(toRemove);
    }

    public virtual void Invoke()
    {
        foreach (var listener in listeners)
        {
            listener.Response.Invoke();
        }
    }
}
