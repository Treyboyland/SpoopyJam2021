using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField]
    MonoBehaviour spawnParticle;

    Dictionary<MonoBehaviour, List<MonoBehaviour>> pool = new Dictionary<MonoBehaviour, List<MonoBehaviour>>();

    Queue<Enemy> enemyQueue = new Queue<Enemy>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    int GetActiveObjects(MonoBehaviour toCheck)
    {
        if (!pool.ContainsKey(toCheck))
        {
            return -1;
        }

        return pool[toCheck].Where(x => x.gameObject.activeInHierarchy).Count();
    }

    public int EnemyActiveCount()
    {
        return pool.Keys.Select(x => GetActiveObjects(x)).Sum();
    }

    MonoBehaviour GetObject(MonoBehaviour toSpawn)
    {
        if (!pool.ContainsKey(toSpawn))
        {
            pool.Add(toSpawn, new List<MonoBehaviour>());
        }

        foreach (var obj in pool[toSpawn])
        {
            if (!obj.gameObject.activeInHierarchy)
            {
                return obj;
            }
        }

        return CreateObject(toSpawn);
    }

    MonoBehaviour CreateObject(MonoBehaviour toCreate)
    {
        var newItem = Instantiate(toCreate, transform);
        newItem.gameObject.SetActive(false);
        pool[toCreate].Add(newItem);

        return newItem;
    }

    public void StartSpawn(Enemy enemy, Vector3 location)
    {
        enemyQueue.Enqueue(enemy);
        var spawnedParticle = GetObject(spawnParticle);
        spawnedParticle.transform.position = location;
        spawnedParticle.gameObject.SetActive(true);
    }

    public void CreateEnemy(Vector3 location)
    {
        if (enemyQueue.Count == 0)
        {
            return;
        }

        var enemy = enemyQueue.Dequeue();

        var enemyToSpawn = GetObject(enemy);

        enemyToSpawn.transform.position = location;
        enemyToSpawn.gameObject.SetActive(true);
    }

    public void DisableAll()
    {
        enemyQueue.Clear();
        foreach (var key in pool.Keys)
        {
            foreach (var item in pool[key])
            {
                item.gameObject.SetActive(false);
            }
        }
    }
}
