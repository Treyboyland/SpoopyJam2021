using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationSpawner : MonoBehaviour
{
    [SerializeField]
    GameEventGeneric<Vector3> onSpawnAtLocation;

    [SerializeField]
    GameEvent onSpawned;

    [SerializeField]
    float secondsToWait;

    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(WaitThenFire());
        }
    }

    IEnumerator WaitThenFire()
    {
        yield return new WaitForSeconds(secondsToWait);
        onSpawnAtLocation.Value = transform.position;
        onSpawnAtLocation.Invoke();

        if (onSpawned != null)
        {
            onSpawned.Invoke();
        }
        gameObject.SetActive(false);
    }
}
