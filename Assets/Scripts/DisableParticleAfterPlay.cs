using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableParticleAfterPlay : MonoBehaviour
{
    [SerializeField]
    ParticleSystem particle;
    
    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(WaitThenDisbale());
        }
    }

    IEnumerator WaitThenDisbale()
    {
        particle.Play();
        while (particle.particleCount != 0 || particle.isPlaying)
        {
            yield return null;
        }

        gameObject.SetActive(false);
    }
}
