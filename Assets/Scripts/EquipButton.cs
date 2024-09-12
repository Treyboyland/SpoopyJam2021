using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EquipButton : MonoBehaviour
{
    [SerializeField]
    TMP_Text textBox;

    [SerializeField]
    EquipData equipData;

    [SerializeField]
    GameEventEquipData onEquip;

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        textBox.text = equipData.IsLeft ? "L" : "R";
    }

    public void EquipWeapon()
    {
        onEquip.Invoke(equipData);
    }
}
