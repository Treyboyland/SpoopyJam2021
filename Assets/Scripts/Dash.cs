using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField]
    Player player;

    [SerializeField]
    PlayerMovement playerMovement;

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

    public void PerformDash()
    {
        secondaryWeapon.DecrementWeaponEnergyForShot();
        player.AddInvincibilityTime(PlayerGameStats.Instance.InGameStats.DashInvincibility);
        playerMovement.AddLeapSeconds(PlayerGameStats.Instance.InGameStats.DashTime);
    }
}
