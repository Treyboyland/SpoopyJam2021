using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectOnEnable : MonoBehaviour
{

    void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            var selectable = gameObject.GetComponent<Selectable>();
            if (selectable != null)
            {
                selectable.Select();
            }
        }
    }
}
