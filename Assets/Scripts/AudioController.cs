using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioClip shake;
    [SerializeField] AudioClip firework;

    AudioSource bgMusic;
    AudioSource soundEffect;
    [Range(0.0f, 1.0f)]
    public float volume;
    private static AudioController instance;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else Destroy(gameObject);
        bgMusic = GetComponents<AudioSource>()[1];
        soundEffect = GetComponents<AudioSource>()[0];
        bgMusic.volume = volume;
        soundEffect.volume = volume;
    }
    void Start()
    {
        
    }

    public void mute()
    {
        bgMusic.mute = true;
        soundEffect.mute = true;
    }

    public void unmute()
    {
        bgMusic.mute = false;
        soundEffect.mute = false;
    }

    public bool getState()
    {
        if (!bgMusic.mute)
        {
            return true;
        }
        else
        {
            return false;
        }     
    }

    public static void playShake()
    {
        instance.soundEffect.PlayOneShot(instance.shake);
    }

    public static void playFirework()
    {
        instance.soundEffect.PlayOneShot(instance.firework);
    }

    public static void stopSound()
    {
        instance.soundEffect.Stop();
    }

}
