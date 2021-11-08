using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }

    private AudioSource source;

    public void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();
    }

    public void PlaySoundWithRandomPitch(AudioClip sound)
    {
        source.pitch = Random.Range(0.9f, 1.0f);
        source.PlayOneShot(sound);
    }
}
