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

    public void PlaySoundWithRandomPitch(AudioClip sound, float from = 0.9f, float to = 1f)
    {
        source.pitch = Random.Range(from, to);
        source.PlayOneShot(sound);
    }
}
