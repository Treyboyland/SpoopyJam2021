using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyProgressBar : MonoBehaviour
{
    [SerializeField]
    Image energyGauge;

    [SerializeField]
    Image energyBorder;

    [SerializeField]
    Color activeColor;

    [SerializeField]
    Color inactiveColor;

    public void UpdateProgress(WeaponProgress progress)
    {
        energyGauge.fillAmount = progress.Progress;
        energyBorder.color = progress.CanFire ? activeColor : inactiveColor;
    }
}
