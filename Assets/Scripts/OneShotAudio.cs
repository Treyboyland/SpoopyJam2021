using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotAudio : MonoBehaviour
{
    [SerializeField]
    AudioSource source;

    public AudioSource Source { get { return source; } }


    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(WaitThenStop());
        }
    }


    IEnumerator WaitThenStop()
    {
        source.Play();
        while (source.isPlaying)
        {
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
