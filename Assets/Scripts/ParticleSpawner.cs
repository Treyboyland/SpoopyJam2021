using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ParticleSpawner", menuName = "Misc/ParticleSpawner")]
public class ParticleSpawner : ScriptableObject
{
    [SerializeField]
    DisableParticleAfterPlay particlePrefab;


    public void SpawnParticle(Vector3 pos)
    {
        var particle = MasterPool.Pool.GetObject(particlePrefab);
        particle.transform.position = pos;

        particle.gameObject.SetActive(true);
    }
}
