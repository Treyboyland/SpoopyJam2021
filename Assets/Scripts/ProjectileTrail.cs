using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTrail : MonoBehaviour
{
    [SerializeField]
    ParticleSystem particle;

    public Transform TransformToTrack;

    
    // Update is called once per frame
    void Update()
    {
        if (TransformToTrack != null)
        {
            if (!TransformToTrack.gameObject.activeInHierarchy)
            {
                TransformToTrack = null;
            }
            else
            {
                MatchTransformPosition();
            }
        }
    }

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            MatchTransformPosition();
            StartCoroutine(WaitThenDisable());
        }
    }

    void MatchTransformPosition()
    {
        if (TransformToTrack != null)
        {
            transform.position = TransformToTrack.position;
        }
    }

    IEnumerator WaitThenDisable()
    {
        particle.Play();

        MatchTransformPosition();

        while (TransformToTrack != null)
        {
            yield return null;
        }

        particle.Stop();
        while (particle.particleCount > 0)
        {
            yield return null;
        }

        gameObject.SetActive(false);
    }
}
