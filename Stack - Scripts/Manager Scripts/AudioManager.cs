using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource[] sounds;

    private void Awake()
    {
        sounds = GetComponents<AudioSource>();
    }

    private void OnEnable()
    {
        EventManager.GameFail += SetFailSound;
        EventManager.GameSuccess += SetSuccessSound;
    }

    private void OnDisable()
    {
        EventManager.GameFail -= SetFailSound;
        EventManager.GameSuccess -= SetSuccessSound;

    }

    public void SetSuccessSound(bool value)
    {
        //sounds[0].Play();
       // Debug.Log("with delegate success : ");
    }

    public void SetFailSound()
    {
        Debug.Log("with delegate : ");
      //  sounds[1].Play();
    }

    public void SetMatchSound()
    {
        sounds[2].Play();
    }

    public void SetBulletSounds(int value)
    {
        sounds[value].Play();
    }
}

