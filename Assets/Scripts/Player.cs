using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    PlayerGameStats gameStats;

    [SerializeField]
    Weapon leftWeapon;


    [SerializeField]
    Weapon rightWeapon;

    public Weapon LeftWeapon
    {
        get { return leftWeapon; }
        set
        {
            SetWeaponValue(leftWeapon, leftWeaponSlot, value);
        }
    }

    [SerializeField]
    Transform leftWeaponSlot;

    public Transform LeftWeaponSlot { get { return leftWeaponSlot; } }

    [SerializeField]
    Transform rightWeaponSlot;

    public Transform RightWeaponSlot { get { return rightWeaponSlot; } }

    public Weapon RightWeapon
    {
        get { return rightWeapon; }
        set
        {
            SetWeaponValue(rightWeapon, rightWeaponSlot, value);
        }
    }

    [SerializeField]
    PlayerReticle playerReticle;

    [SerializeField]
    GameEvent onPlayerDamaged;

    [SerializeField]
    GameEventGeneric<Vector3> onPlayerDefeated;

    [SerializeField]
    float maxOxygen;

    public float MaxOxygen { get { return maxOxygen; } set { maxOxygen = value; } }

    uint currentHealth = 0;

    static Player _instance = null;

    public static Player PlayerInstance { get { return _instance; } }

    Vector3 startingPosition;

    private void Awake()
    {
        _instance = this;
        if (leftWeapon != null)
        {
            UpdateComponents(leftWeapon, leftWeaponSlot, playerReticle);
        }
        if (rightWeapon != null)
        {
            UpdateComponents(rightWeapon, rightWeaponSlot, playerReticle);
        }

        startingPosition = transform.position;
    }


    private void OnEnable()
    {
        currentHealth = (uint)gameStats.InGameStats.MaxHealth;
        transform.position = startingPosition;
    }

    void SetWeaponValue(Weapon playerWeapon, Transform weaponSlot, Weapon updatedWeapon)
    {
        if (playerWeapon != null)
        {
            playerWeapon.gameObject.SetActive(false);
        }
        var newWeapon = MasterPool.Pool.GetObject(updatedWeapon) as Weapon;
        newWeapon.gameObject.SetActive(true);
        var tracker = newWeapon.GetComponent<ObjectTracker>();
        UpdateComponents(newWeapon, weaponSlot, playerReticle);

        playerWeapon = newWeapon;
    }

    void UpdateComponents(Weapon weapon, Transform weaponSlot, PlayerReticle reticleToTrack)
    {
        var tracker = weapon.GetComponent<ObjectTracker>();
        if (tracker != null)
        {
            tracker.ObjectToTrack = weaponSlot;
        }
        var reticle = weapon.GetComponent<ReticleTracker>();
        if (reticle != null)
        {
            reticle.Reticle = reticleToTrack;
        }
    }

    public void Damage(uint damage)
    {
        if (damage > currentHealth)
        {
            currentHealth = 0;
        }
        else
        {
            currentHealth -= damage;
        }

        onPlayerDamaged.Invoke();

        if (currentHealth == 0)
        {
            onPlayerDefeated.Value = transform.position;
            onPlayerDefeated.Invoke();
            gameObject.SetActive(false);
        }
    }
}
