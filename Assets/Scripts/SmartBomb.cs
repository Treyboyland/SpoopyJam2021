using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartBomb : MonoBehaviour
{
    [SerializeField]
    Player player;

    [SerializeField]
    Weapon secondaryWeapon;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LaunchSmartBomb()
    {
        secondaryWeapon.DecrementWeaponEnergyForShot();
        var bulletObj = MasterPool.Pool.GetObject(secondaryWeapon.Bullet) as Projectile;
        bulletObj.transform.position = player.transform.position;
        bulletObj.Damage = secondaryWeapon.Damage;
        bulletObj.gameObject.SetActive(true);
    }
}
