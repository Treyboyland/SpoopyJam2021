using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField]
    TMP_Text buttonText;

    [SerializeField]
    PlayerUpgradeSO upgradeType;

    [SerializeField]
    GameEventPlayerUpgrade upgradeEvent;

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        UpdateDescription();
    }

    public void AttemptUpgrade()
    {
        upgradeEvent.Invoke(upgradeType);
    }

    public void UpdateDescription()
    {
        buttonText.text = $"Upgrade {upgradeType.UpgradeName}: " +
            $"{(PlayerGameStats.Instance == null ? -1 : PlayerGameStats.Instance.GetUpgradeCost(upgradeType))}";
    }
}
