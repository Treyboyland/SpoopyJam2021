using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleTracker : MonoBehaviour
{
    [SerializeField]
    PlayerReticle reticle;

    public PlayerReticle Reticle { get { return reticle; } set { reticle = value; } }

    const float SPRITE_CORRECTION_ANGLE = -90;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (reticle != null)
        {
            var pos = reticle.transform.position - transform.position;
            float angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg + SPRITE_CORRECTION_ANGLE;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }


}
