using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitThenActivate : MonoBehaviour
{
    [SerializeField]
    float secondsToWait;

    [SerializeField]
    GameObject objectToActivate;

    bool isStarted = false;

    public void StartActivation()
    {
        if (!isStarted)
        {
            StartCoroutine(WaitRoutine());
        }
    }

    IEnumerator WaitRoutine()
    {
        isStarted = true;
        yield return new WaitForSeconds(secondsToWait);
        objectToActivate.SetActive(true);
        isStarted = false;
    }
}
