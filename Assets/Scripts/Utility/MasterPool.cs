using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MasterPool : MonoBehaviour
{
    [SerializeField]
    List<MonoCount> objectsToPool;


    [Serializable]
    public struct MonoCount
    {
        public MonoBehaviour MonoBehaviour;

        public uint Count;
    }

    static MasterPool _instance;

    public static MasterPool Pool { get { return _instance; } }

    Dictionary<MonoBehaviour, List<MonoBehaviour>> pool = new Dictionary<MonoBehaviour, List<MonoBehaviour>>();

    private void Awake()
    {
        if (_instance != null && this != _instance)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;

        DontDestroyOnLoad(gameObject);
    }

    MonoBehaviour CreateItem(MonoBehaviour itemToCreate)
    {
        var instance = Instantiate(itemToCreate, transform);
        instance.gameObject.SetActive(false);
        pool[itemToCreate].Add(instance);

        return instance;
    }

    void Initialize()
    {
        foreach (var item in objectsToPool)
        {
            if (!pool.ContainsKey(item.MonoBehaviour))
            {
                pool.Add(item.MonoBehaviour, new List<MonoBehaviour>());
            }

            for (int i = 0; i < item.Count; i++)
            {
                pool[item.MonoBehaviour].Add(CreateItem(item.MonoBehaviour));
            }
        }
    }

    public MonoBehaviour GetObject(MonoBehaviour objToGet)
    {
        if (!pool.ContainsKey(objToGet))
        {
            pool.Add(objToGet, new List<MonoBehaviour>());
        }

        foreach (var item in pool[objToGet])
        {
            if (!item.gameObject.activeInHierarchy)
            {
                return item;
            }
        }

        return CreateItem(objToGet);
    }
}
