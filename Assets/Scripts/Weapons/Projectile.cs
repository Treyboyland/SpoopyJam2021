using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    ProjectileDataSO dataSO;

    uint damage;

    float elapsed = 0;

    float maxTime;

    private void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= maxTime)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        elapsed = 0;
        damage = dataSO.Damage;
        maxTime = dataSO.LifeTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
