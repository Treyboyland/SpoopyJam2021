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
    GameEventInt onLivesUpdated;

    [SerializeField]
    GameEventGeneric<Vector3> onPlayerDefeated;

    [SerializeField]
    float maxOxygen;

    public float MaxOxygen { get { return maxOxygen; } set { maxOxygen = value; } }

    public bool IsInvincible => invincibleTime > 0;

    int currentHealth = 0;

    static Player _instance = null;

    public static Player PlayerInstance { get { return _instance; } }

    public bool IsDead => !gameObject.activeInHierarchy;

    Vector3 startingPosition;

    float invincibleTime = 0;

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
        currentHealth = gameStats.InGameStats.MaxHealth;
        onLivesUpdated.Invoke(currentHealth);
        transform.position = startingPosition;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        invincibleTime = Mathf.Max(invincibleTime - Time.deltaTime, 0);
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

    public void Damage(int damage)
    {
        if (damage > currentHealth)
        {
            currentHealth = 0;
        }
        else
        {
            currentHealth -= damage;
            onLivesUpdated.Invoke(currentHealth);
        }

        if (currentHealth == 0)
        {
            onPlayerDefeated.Value = transform.position;
            onPlayerDefeated.Invoke();
            gameObject.SetActive(false);
        }
        else
        {
            onPlayerDamaged.Invoke();
        }
    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        var enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            Damage(enemy.EnemyStats.Damage);
        }
    }

    public void AddInvincibilityTime(float amount)
    {
        invincibleTime += amount;
    }
}
