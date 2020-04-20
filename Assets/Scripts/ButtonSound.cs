using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioClip sound;
    private AudioSource myaudio;

    void Start()
    {
        myaudio=GetComponent<AudioSource>();
    }
    public void PlayButtonSound()
    {
        myaudio.PlayOneShot(sound);
    }
}
