using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    EnemyDataSO dataSO;

    uint health = 0;

    private void OnEnable()
    {
        health = dataSO.Health;
    }

    public void Damage(uint dmg)
    {
        if (dmg > health)
        {
            health = 0;
        }
        else
        {
            health -= dmg;
        }
        
    }
}
