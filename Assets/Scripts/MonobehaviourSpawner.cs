using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Misc/MonoBehaviour Spawner")]
public class MonobehaviourSpawner : ScriptableObject
{
    [SerializeField]
    MonoBehaviour behaviour;

    public void SpawnObject(Vector3 location)
    {
        var obj = MasterPool.Pool.GetObject(behaviour);
        obj.transform.position = location;
        obj.gameObject.SetActive(true);
    }
}
