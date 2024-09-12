using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEventsOnEnable : MonoBehaviour
{
    [SerializeField]
    List<GameEvent> eventsToFireEnabled;

    [SerializeField]
    List<GameEvent> eventsToFireDisabled;

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            EvokeEvents(eventsToFireEnabled);
        }
    }

    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    void OnDisable()
    {
        if (!gameObject.activeInHierarchy)
        {
            EvokeEvents(eventsToFireDisabled);
        }
    }


    void EvokeEvents(List<GameEvent> events)
    {
        foreach (var eventItem in events)
        {
            eventItem.Invoke();
        }
    }
}
