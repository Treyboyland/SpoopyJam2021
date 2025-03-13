using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileParticlePool : MonoBehaviour
{
    [SerializeField]
    ProjectileParticle particle;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void TrackProjectile(Projectile projectile)
    {
        var p = MasterPool.Pool.GetObject(particle) as ProjectileParticle;
        p.Projectile = projectile;
        p.gameObject.SetActive(true);
    }
}
