using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EquippedWeaponText : MonoBehaviour
{
    [SerializeField]
    TMP_Text textBox;

    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
    }

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            UpdateText();
        }
    }

    public void UpdateText()
    {
        string leftWeaponText, rightWeaponText;
        if (PlayerGameStats.Instance == null || PlayerGameStats.Instance.InGameStats == null)
        {
            leftWeaponText = "None";
            rightWeaponText = "None";
        }
        else
        {
            leftWeaponText = PlayerGameStats.Instance.InGameStats.LeftEquipWeapon == null ? "None" : PlayerGameStats.Instance.InGameStats.LeftEquipWeapon.WeaponName;
            rightWeaponText = PlayerGameStats.Instance.InGameStats.RightEquipWeapon == null ? "None" : PlayerGameStats.Instance.InGameStats.RightEquipWeapon.WeaponName;
        }
        textBox.text = $"Left Equip: {leftWeaponText}\r\nRight Equip: {rightWeaponText}";
    }
}
