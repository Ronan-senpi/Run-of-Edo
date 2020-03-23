using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    [SerializeField]
    private string name;

    public string Name  
    {
        get
        {
            return name;
        }
        protected set
        {
            name = value;
        }
    }

    [SerializeField]
    private AudioClip clip;
    public AudioClip Clip
    {
        get
        {
            return clip;
        }
        set
        {
            clip = value;
        }
    }


    [SerializeField]
    [Range(0f, 1f)]
    private float volume;
    public float Volume
    {
        get
        {
            return volume;
        }
        set
        {
            volume = value;
        }
    }

    [SerializeField]
    [Range(.1f, 3f)]
    private float pitch;
    public float Pitch  
    {
        get
        {
            return pitch;
        }
        set
        {
            pitch = value;
        }
    }

    [SerializeField]
    private bool loop;
    public bool Loop
    {
        get
        {
            return loop;
        }
        set
        {
            loop = value;
        }
    }
    public AudioSource source { get; set; }
}
