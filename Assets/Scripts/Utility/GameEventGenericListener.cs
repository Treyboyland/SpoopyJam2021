using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventGenericListener<T> : MonoBehaviour
{
    [SerializeField]
    GameEventGeneric<T> gameEvent;

    public UnityEvent<T> Response;

    private void OnEnable()
    {
        gameEvent.AddListener(this);
    }

    private void OnDisable()
    {
        gameEvent.RemoveListener(this);
    }
}


public class GameEventGenericListener<T,U> : MonoBehaviour
{
    [SerializeField]
    GameEventGeneric<T,U> gameEvent;

    public UnityEvent<T, U> Response;

    private void OnEnable()
    {
        gameEvent.AddListener(this);
    }

    private void OnDisable()
    {
        gameEvent.RemoveListener(this);
    }
}