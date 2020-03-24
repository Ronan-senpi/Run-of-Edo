using UnityEngine;
using UnityEngine.Audio;
using System;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{

    [SerializeField]
    protected Sound[] sounds;

    public static AudioManager Instance { get; set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        //Evite de detruire l'audio manager entre les scene
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.Clip;

            s.source.volume = s.Volume;
            s.source.pitch = s.Pitch;
            s.source.loop = s.Loop;
        }
    }

    /// <summary>
    /// Stop all audio source exept MainTheme
    /// </summary>
    public void StopAll()
    {
        foreach (var s in sounds)
        {
            if (s.Name != "MainTheme")
            {
                s.source.Stop();
            }
        }
    }

    void Start()
    {
        this.Play("MainTheme");
    }

    public void Play(string name)
    {
        Sound[] ss = Array.FindAll(sounds, sound => sound.Name == name);
        if (ss == null && ss.Length == 0)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        if (ss.Length == 1)
        {
            ss[0].source.Play();
        }
        else if (ss.Length > 1)
        {
            Sound s = ss[UnityEngine.Random.Range(0, ss.Length)];
            s.source.Play();
        }
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.Name == name && sound.Loop);
        if (s == null)
        {
            return;
        }
        s.source.Stop();
    }

}
