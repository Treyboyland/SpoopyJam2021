using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LivesText : MonoBehaviour
{
    [SerializeField]
    TMP_Text textbox;

    public void UpdateLives(int lives)
    {
        textbox.text = "Lives: " + lives;
    }
}
