
using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    void Awake()
    {
        // Persist audio manager between scenes
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        // Initialize sounds on awake (before game starts)
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("Theme");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found!");
            return;
        }

        s.source.Play();

    }

    public void FadeOut(string name)
    {
        AudioSource s = FindAudioSource(name);

        if (s)
        {
            StartCoroutine(FadeOut(s, 0.5f));
        }
    }

    public void FadeIn(string name)
    {
        AudioSource s = FindAudioSource(name);

        if (s)
        {
            StartCoroutine(FadeIn(s, 5f, s.volume));
        }
    }

    private AudioSource FindAudioSource(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found!");
            return null;
        }

        return s.source;
    }

    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }

    public static IEnumerator FadeIn(AudioSource audioSource, float FadeTime, float vol)
    {
        // Added vol so that overall volume is maintained in the editor
        float startVolume = 0.1f;

        audioSource.volume = 0;
        audioSource.Play();

        Debug.Log("FadeIn " + audioSource.volume + " To " + vol);
        while (audioSource.volume <= vol)
        {
            float vol2 = startVolume * Time.deltaTime / FadeTime;
            //Debug.Log(vol2);
            audioSource.volume += vol2;
            //Debug.Log(audioSource.volume);

            yield return null;
        }

        audioSource.volume = vol;
    }

}
