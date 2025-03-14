using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerWeaponSetter : MonoBehaviour
{
    [Header("Weapon Bases")]
    [SerializeField]
    WeaponDataSO pistolData;

    [SerializeField]
    WeaponDataSO shotgunData;

    [SerializeField]
    WeaponDataSO kunaiData;

    [SerializeField]
    WeaponDataSO dashData;

    [SerializeField]
    WeaponDataSO smartBombData;

    [SerializeField]
    WeaponDataSO randomFireData;

    [Header("Weapon Type")]
    [SerializeField]
    WeaponTypeSO pistolType;

    [SerializeField]
    WeaponTypeSO shotgunType;

    [SerializeField]
    WeaponTypeSO kunaiType;

    [SerializeField]
    WeaponTypeSO smartBombType;

    [SerializeField]
    WeaponTypeSO dashType;

    [SerializeField]
    WeaponTypeSO sprayAndPrayType;

    [Header("Weapon Levels")]
    [SerializeField]
    WeaponLevelDataSO pistolLevelData;

    [SerializeField]
    WeaponLevelDataSO shotgunLevelData;

    [SerializeField]
    WeaponLevelDataSO kunaiLevelData;

    [SerializeField]
    WeaponLevelDataSO dashLevelData;

    [SerializeField]
    WeaponLevelDataSO smartBombLevelData;

    [SerializeField]
    WeaponLevelDataSO randomFireLevelData;

    [SerializeField]
    bool isDebug;

    [SerializeField]
    Player player;

    [SerializeField]
    WeaponDataFinder dataFinder;

    [SerializeField]
    List<PlayerUpgradeSO> weaponParameters;

    List<WeaponDataSO> allWeapons = new List<WeaponDataSO>();
    List<WeaponLevelDataSO> allWeaponLevels = new List<WeaponLevelDataSO>();

    // Start is called before the first frame update
    void Start()
    {
        allWeapons = new List<WeaponDataSO>() { pistolData, shotgunData, kunaiData, smartBombData, dashData, randomFireData };
        allWeaponLevels = new List<WeaponLevelDataSO>() { pistolLevelData, shotgunLevelData, kunaiLevelData, smartBombLevelData, dashLevelData, randomFireLevelData };
        RefreshWeapons();
    }

    public void RefreshWeapons()
    {
        SetWeapon(new EquipData() { IsLeft = true, WeaponType = PlayerGameStats.Instance.InGameStats.LeftEquipWeapon });
        SetWeapon(new EquipData() { IsLeft = false, WeaponType = PlayerGameStats.Instance.InGameStats.RightEquipWeapon });
    }

    void SetWeapon(Weapon playerWeapon, WeaponDataSO weaponData)
    {
        playerWeapon.WeaponSprite.sprite = weaponData.WeaponType.WeaponSprite;
        playerWeapon.Bullet = weaponData.Projectile;
        playerWeapon.ProjectileOrigin = weaponData.ProjectileOrigin;
        playerWeapon.WeaponType = weaponData.WeaponType;
        playerWeapon.Damage = dataFinder.GetDamage(weaponData);
        playerWeapon.KnockBack = dataFinder.GetKnockback(weaponData);
        playerWeapon.FireAngles = dataFinder.GetFireAngles(weaponData);


        playerWeapon.EnergyPerShot = dataFinder.GetEnergyPerShot(weaponData);
        playerWeapon.MaxEnergy = dataFinder.GetMaxEnergy(weaponData);
        playerWeapon.SecondsBetweenShots = dataFinder.GetSecondsBetweenShots(weaponData);

        playerWeapon.OnWeaponFired = weaponData.WeaponFiredEvent;
        playerWeapon.ShouldFireEvent = weaponData.FiresEventInstead;
        playerWeapon.WeaponEvent = weaponData.WeaponEvent;
    }



    public void SetWeapon(EquipData equipData)
    {
        var weapon = equipData.WeaponType;
        var weaponToModify = equipData.IsLeft ? player.LeftWeapon : player.RightWeapon;

        if (equipData.IsLeft)
        {
            PlayerGameStats.Instance.InGameStats.LeftEquipWeapon = equipData.WeaponType;
        }
        else
        {
            PlayerGameStats.Instance.InGameStats.RightEquipWeapon = equipData.WeaponType;
        }


        var weaponData = allWeapons.Where(x => x.WeaponType == weapon).First();

        foreach (var upgrade in weaponParameters)
        {
            int levelIndex = PlayerGameStats.Instance.InGameStats.GetCountOfUpgradeType(weapon, upgrade);
            var levels = allWeaponLevels.First(x => x.WeaponType == weapon).GetLevelsForUpgrade(upgrade);

            if (levels != null && levelIndex != -1)
            {
                weaponData.SetUpgrade(upgrade, levels.GetAtIndexOfObjectList(levelIndex));
            }
        }

        SetWeapon(weaponToModify, weaponData);
    }

    public void UpdateCurrentWeapons()
    {
        EquipData equipDataRight = new EquipData()
        {
            IsLeft = false,
            WeaponType = player.RightWeapon.WeaponType
        };

        EquipData equipDataLeft = new EquipData()
        {
            IsLeft = true,
            WeaponType = player.LeftWeapon.WeaponType
        };
        SetWeapon(equipDataRight);
    }
}
