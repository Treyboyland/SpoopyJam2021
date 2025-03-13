using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileParticle : MonoBehaviour
{
    [SerializeField]
    ParticleSystem particle;

    public Projectile Projectile;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnEnable()
    {
        if (Projectile != null)
        {
            transform.position = Projectile.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Projectile == null && gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
            return;
        }

        transform.position = Projectile.transform.position;

        if (Projectile.gameObject.activeInHierarchy && !particle.isPlaying)
        {
            particle.Play();
        }
        else if (!Projectile.gameObject.activeInHierarchy && particle.isPlaying)
        {
            particle.Stop();
        }
        else if (!Projectile.gameObject.activeInHierarchy && particle.particleCount == 0)
        {
            Projectile = null;
            gameObject.SetActive(false);
        }
    }
}
