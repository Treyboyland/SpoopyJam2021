using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwapperUI : MonoBehaviour
{
    [SerializeField]
    GameObject primaryUI;

    [SerializeField]
    GameObject secondaryUI;

    void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            ShowPrimaryWeapons();
        }
    }

    void ShowPrimaryWeapons()
    {
        primaryUI.SetActive(true);
        secondaryUI.SetActive(false);
    }

    public void SwapUI()
    {
        primaryUI.SetActive(!primaryUI.activeSelf);
        secondaryUI.SetActive(!primaryUI.activeSelf);
    }
}
