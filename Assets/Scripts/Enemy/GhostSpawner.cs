using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    [SerializeField]
    int startingPoints;

    [SerializeField]
    int pointsPerUpgrade;

    [SerializeField]
    float spawnDelay;

    [SerializeField]
    Vector2 pointVariance;

    [SerializeField]
    Vector4 spawnParameters;

    [SerializeField]
    Vector2 timeBetweenSpawns;

    [SerializeField]
    EnemyPool pool;

    [SerializeField]
    List<Enemy> potentialEnemies;

    float elapsed = 0;

    float currentSpawnTime = 0;

    int multiplier = 1;

    bool canSpawn = false;
    bool isSpawning = false;

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            elapsed += Time.deltaTime;
        }
        if (canSpawn && elapsed >= currentSpawnTime && !isSpawning)
        {
            ResetSpawnTime();
            StartCoroutine(SpawnGhosts());
        }
        if (canSpawn && pool.EnemyActiveCount() == 0 && !isSpawning)
        {
            //Reset time?
            multiplier++;
            StartCoroutine(SpawnGhosts());
        }
    }

    Vector3 GetSpawnLocation()
    {
        return spawnParameters.Randomize();
    }

    void ResetSpawnTime()
    {
        elapsed = 0;
        currentSpawnTime = timeBetweenSpawns.Randomize();
    }

    void SpawnGhost(Enemy toSpawn)
    {
        pool.StartSpawn(toSpawn, GetSpawnLocation());
    }

    IEnumerator SpawnGhosts()
    {
        isSpawning = true;
        int cost = (int)(startingPoints * pointVariance.Randomize() * multiplier) + pointsPerUpgrade * PlayerGameStats.Instance.InGameStats.GetTotalNumOfUpgrades();
        while (cost > 0)
        {
            var actualEnemies = potentialEnemies.Where(x => x.EnemyStats.SpawnCost <= cost).ToList();
            var chosen = actualEnemies.GetRandomItem();
            cost -= chosen.EnemyStats.SpawnCost;
            SpawnGhost(chosen);
            bool delay = Random.Range(0f, 1f) > .8f;
            if (delay)
            {
                yield return new WaitForSeconds(spawnDelay);
            }
        }
        isSpawning = false;
    }

    public void StopSpawning()
    {
        StopAllCoroutines();
        isSpawning = false;
        canSpawn = false;
        elapsed = 0;
        pool.DisableAll();
    }

    public void StartSpawning()
    {
        canSpawn = true;
        elapsed = 0;
        StartCoroutine(
                //multiplier = 1;
                SpawnGhosts());
    }
}
