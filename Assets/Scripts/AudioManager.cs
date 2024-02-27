using UnityEngine;
using System.Collections.Generic;
using RHTMGame.Utils;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
   
    public List<Sound> sounds;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(Instance);

        sounds = new List<Sound>
        {
            new Sound()
            {
                name = "stepHit",
                clip = Resources.Load<AudioClip>("SoundEffects/stepHit"),
                volume = 1f,
                pitch = 1f
            },
            new Sound()
            {
                name = "gameOver",
                clip = Resources.Load<AudioClip>("SoundEffects/gameOver"),
                volume = 1f,
                pitch = 1f
            },
            new Sound()
            {
                name = "riverFlowsInYou",
                clip = Resources.Load<AudioClip>("Songs/riverFlowsInYou"),
                volume = 1f,
                pitch = 1f
            },
            new Sound()
            {
                name = "gods",
                clip = Resources.Load<AudioClip>("Songs/gods"),
                volume = 1f,
                pitch = 1f
            },
            new Sound()
            {
                name = "mainMenu",
                clip = Resources.Load<AudioClip>("Songs/mainMenuMusic"),
                volume = 1f,
                pitch = 1f
            }
        };

        foreach (var s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        var s = sounds.Find(s => s.name == name); 
        if (s == null)
        {
            Debug.LogWarning($"Sound {name} not found");
            return;
        }

        s.source.volume = s.volume * Globals.Instance.MusicVolume;
        s.source.Play();
    }

    public void PlayEffect(string name)
    {
        var s = sounds.Find(s => s.name == name);
        if (s == null)
        {
            Debug.LogWarning($"Sound {name} not found");
            return;
        }

        s.source.volume = s.volume * Globals.Instance.EffectsVolume;
        s.source.Play();
    }

    public void Pause(string name)
    {
        var s = sounds.Find(s => s.name == name);
        if (s == null)
        {
            Debug.LogWarning($"Sound {name} not found");
            return;
        }

        s.source.Pause();
    }

    public void Resume(string name)
    {
        var s = sounds.Find(s => s.name == name);
        if(s == null)
        {
            Debug.LogWarning($"Sound {name} not found");
            return;
        }

        s.source.UnPause();
    }

    public void Stop(string name)
    {
        var s = sounds.Find(s => s.name == name);
        if (s == null)
        {
            Debug.LogWarning($"Sound {name} not found");
            return;
        }

        s.source.Stop();
    }
}

public class Sound
{
    public string name;
    public AudioClip clip;
    public float volume;
    public float pitch;
    public bool loop;

    public AudioSource source;
}