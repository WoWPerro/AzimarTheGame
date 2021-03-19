using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
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
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogError("Sound with name: " + name + " not be found!");
        }
        else
        {
             s.source.Play();
        }      
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogError("Sound with name: " + name + " not be found!");
        }
        else
        {
             s.source.Stop();
        }      
    }

    public IEnumerator Play(string name, float Fadein, float increaseAmount)
    {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            if (s == null)
            {
                Debug.LogError("Sound with name: " + name + " not be found!");
            }
            s.source.Play();
            s.source.volume = 0;
            while (s.source.volume <= Fadein)
            {
                s.source.volume += increaseAmount;
                yield return new WaitForSeconds(.1f);
            }
    }

    public IEnumerator Stop(string name, float decreaseAmount)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
            if (s == null)
            {
                Debug.LogError("Sound with name: " + name + " not be found!");
            }
            
            s.source.volume = 0;
            while (s.source.volume >= 0)
            {
                s.source.volume -= decreaseAmount;
                yield return new WaitForSeconds(.1f);
            }

            if(s.source.volume >= 0)
            {
                s.source.Stop();
            }
    }
}
