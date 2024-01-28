using UnityEngine;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    public List<AudioClip> audioClips; // store all the audio clips

    // play a single sound effect
    public void PlaySound(int clipIndex)
    {
        // create a new Audio Source component and configure it
        AudioSource newAudioSource = gameObject.AddComponent<AudioSource>();
        newAudioSource.clip = audioClips[clipIndex];
        
        // play the sound effect
        newAudioSource.Play();
        
        // destroy the Audio Source component after the sound effect is played
        Destroy(newAudioSource, audioClips[clipIndex].length);
    }

    // play a background music
    public void PlayBackgroundMusic(int clipIndex)
    {
        // create a new Audio Source component and configure it
        AudioSource newAudioSource = gameObject.AddComponent<AudioSource>();
        newAudioSource.clip = audioClips[clipIndex];
        newAudioSource.loop = true; // set the background music to loop

        // play the background music
        newAudioSource.Play();
    }
}