using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    [SerializeField]
    Vector2Int initialGhostCount;

    [SerializeField]
    Vector4 spawnParameters;

    [SerializeField]
    Vector2Int subsequentGhostCount;

    [SerializeField]
    Vector2 timeBetweenSpawns;

    [SerializeField]
    MonobehaviourSpawner ghostSpawner;

    [SerializeField]
    MonobehaviourSpawner ghostParticleSpawner;

    float elapsed = 0;

    float currentSpawnTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        int count = UnityEngine.Random.Range(initialGhostCount.x, initialGhostCount.y);


        for (int i = 0; i < count; i++)
        {
            SpawnGhost();
        }
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= currentSpawnTime)
        {
            ResetSpawnTime();
            SpawnNewGhosts();
        }
    }

    Vector3 GetSpawnLocation()
    {
        var x = UnityEngine.Random.Range(spawnParameters.x, spawnParameters.y);
        var y = UnityEngine.Random.Range(spawnParameters.z, spawnParameters.w);
        var z = 0;

        return new Vector3(x, y, z);
    }

    void SpawnGhost()
    {
        ghostSpawner.SpawnObject(GetSpawnLocation());
    }

    void SpawnSpawner()
    {
        ghostParticleSpawner.SpawnObject(GetSpawnLocation());
    }

    void ResetSpawnTime()
    {
        elapsed = 0;
        currentSpawnTime = UnityEngine.Random.Range(timeBetweenSpawns.x, timeBetweenSpawns.y);
    }

    void SpawnNewGhosts()
    {
        int count = UnityEngine.Random.Range(subsequentGhostCount.x, subsequentGhostCount.y);

        for (int i = 0; i < count; i++)
        {
            SpawnSpawner();
        }
    }
}
