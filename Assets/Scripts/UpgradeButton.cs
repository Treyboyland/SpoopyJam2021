using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField]
    Button button;

    [SerializeField]
    TMP_Text buttonText;

    [SerializeField]
    WeaponTypeAndPlayerUpgrade upgradeType;

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
        if (PlayerGameStats.Instance == null)
        {
            Debug.LogWarning("Player instance null");
        }
        int value = PlayerGameStats.Instance == null ? -1 : PlayerGameStats.Instance.GetUpgradeCost(upgradeType);

        buttonText.text = $"Upgrade {upgradeType.PlayerUpgrade.UpgradeName}: " +
            $"{(value == -1 ? "SOLD OUT" : value.ToString())}";

        button.interactable = value != -1;
    }
}
