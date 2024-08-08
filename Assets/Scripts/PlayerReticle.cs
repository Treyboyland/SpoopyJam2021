using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReticle : MonoBehaviour
{
    [SerializeField]
    Camera gameCamera;

    [SerializeField]
    Player player;

    [SerializeField]
    float radius;

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
        Vector3 mousePos = new Vector3(mousePosition.x, mousePosition.y, player.transform.position.z - gameCamera.transform.position.z);
        var worldPos = gameCamera.ScreenToWorldPoint(mousePos);
        
        //Debug.LogWarning("Reticle: " + worldPos);
        transform.position = worldPos;
    }

    public void SetPositionController(Vector2 rightStickPos)
    {
        Vector3 newPos = rightStickPos * radius;
        newPos.z = 0;
        transform.position = newPos + player.transform.position;
    }
}
