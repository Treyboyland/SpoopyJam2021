using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    [SerializeField]
    Transform objectToTrack;

    [SerializeField]
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (objectToTrack != null && objectToTrack.gameObject.activeInHierarchy)
        {
            transform.position = new Vector3(objectToTrack.position.x, objectToTrack.position.y, transform.position.z) + offset;
        }
    }



}
