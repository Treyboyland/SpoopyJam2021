using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyText : MonoBehaviour
{
    [SerializeField]
    TMP_Text textBox;

    // Start is called before the first frame update
    void Start()
    {

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
        textBox.text = "Money: " + PlayerGameStats.Instance.InGameStats.Money;
    }
}
