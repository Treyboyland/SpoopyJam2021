using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayAndPray : MonoBehaviour
{
    [SerializeField]
    Weapon secondaryWeapon;

    [SerializeField]
    Player player;

    bool isFiring = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CompleteAction()
    {
        if (!isFiring)
        {
            StartCoroutine(CompleteFiringProtocol());
        }
    }

    IEnumerator CompleteFiringProtocol()
    {
        isFiring = true;
        while (secondaryWeapon.EnergyPerShot <= secondaryWeapon.CurrentEnergy && !player.IsDead)
        {
            secondaryWeapon.DecrementWeaponEnergyForShot();
            var bulletObj = MasterPool.Pool.GetObject(secondaryWeapon.Bullet) as Projectile;
            bulletObj.transform.position = player.transform.position;
            bulletObj.Damage = secondaryWeapon.Damage;
            bulletObj.transform.up = Vector3.up;
            bulletObj.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(0.0f, 360.0f)));
            bulletObj.gameObject.SetActive(true);
            yield return new WaitForSeconds(secondaryWeapon.SecondsBetweenShots);
        }
        isFiring = false;
    }
}
