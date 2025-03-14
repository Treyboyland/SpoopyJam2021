using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HighlightSelectedUIObject : MonoBehaviour
{
    [SerializeField]
    RectTransform rectTransform;

    [SerializeField]
    float bounds;

    GameObject currentObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var obj = EventSystem.current.currentSelectedGameObject;
        if (obj == null && currentObject != null)
        {
            SelectCurrentObject();
        }
        else if (currentObject != obj)
        {
            currentObject = obj;
            UpdatePosition();
        }
    }

    void SelectCurrentObject()
    {
        var select = currentObject.GetComponent<Selectable>();
        if (select)
        {
            select.Select();
        }
    }

    void UpdatePosition()
    {
        if (currentObject == null)
        {
            return;
        }
        var rect = currentObject.GetComponent<RectTransform>();
        if (rect)
        {
            rectTransform.sizeDelta = rect.sizeDelta;
            rectTransform.sizeDelta += new Vector2(bounds, bounds);
            rectTransform.position = rect.position;
        }
    }
}
