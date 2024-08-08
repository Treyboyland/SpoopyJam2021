using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReticle : MonoBehaviour
{
    [SerializeField]
    Camera gameCamera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetPosition(Vector2 mousePosition)
    {
        var worldPos = gameCamera.ScreenToWorldPoint(mousePosition);
        worldPos.z = 0;
        //Debug.LogWarning("Reticle: " + worldPos);
        transform.position = worldPos;
    }
}
