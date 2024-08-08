using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTracker : MonoBehaviour
{
    [SerializeField]
    Transform objectToTrack;

    public Transform ObjectToTrack { get { return objectToTrack; } set { objectToTrack = value; } }

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

    private void OnDisable()
    {
        objectToTrack = null;
    }

}
