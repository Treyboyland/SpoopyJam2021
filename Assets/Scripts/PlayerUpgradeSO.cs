using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerUpgrade-", menuName = "Game/Player Upgrade")]
public class PlayerUpgradeSO : ScriptableObject
{
    [SerializeField]
    string upgradeName;

    public string UpgradeName { get => upgradeName; }
}
