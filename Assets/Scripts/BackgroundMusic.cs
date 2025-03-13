using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField]
    AudioMixer mixer;

    [SerializeField]
    AudioMixerSnapshot gameSnapshot;

    [SerializeField]
    AudioMixerSnapshot shopSnapshot;

    void Start()
    {
        SetShopSnapshot();
    }

    public void SetShopSnapshot()
    {
        mixer.TransitionToSnapshots(new AudioMixerSnapshot[] { shopSnapshot }, new float[] { 1 }, 0.5f);
    }

    public void SetGameSnapshot()
    {
        mixer.TransitionToSnapshots(new AudioMixerSnapshot[] { gameSnapshot }, new float[] { 1 }, 0.5f);
    }
}
