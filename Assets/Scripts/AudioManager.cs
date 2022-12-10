using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance; 

    public void Start()
    {

        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

       foreach(Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            //sound.source.name = sound.name;
        }

    }
    public void PlayMySound(string name)
    {
        foreach(Sound sound in sounds)
        {
            if(sound.name == name)
            {
                sound.source.Play();
            }
        }
    }
}
