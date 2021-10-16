using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoBehaviourPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField]
    T objectPrefab = null;

    [SerializeField]
    int initialSize = 1;

    [SerializeField]
    bool canGrow = true;

    List<T> objects = new List<T>();

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }


    void Initialize()
    {
        for (int i = 0; i < initialSize; i++)
        {
            CreateObject();
        }
    }

    T CreateObject()
    {
        var newObject = Instantiate(objectPrefab, transform);
        newObject.gameObject.SetActive(false);
        objects.Add(newObject);

        return newObject;
    }

    /// <summary>
    /// NOTE: Callers should make sure to set retrieved object active before calling for another one
    /// </summary>
    /// <returns></returns>
    public T GetObject()
    {
        foreach (var obj in objects)
        {
            if (!obj.gameObject.activeInHierarchy)
            {
                return obj;
            }
        }

        return canGrow ? CreateObject() : null;
    }

    public void DisableAll()
    {
        foreach (var obj in objects)
        {
            obj.gameObject.SetActive(false);
        }
    }
}
