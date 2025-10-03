using UnityEngine;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    public List<AudioClip> audioClips; // store all the audio clips
    public GameObject SoundPlayOnce; // the prefab object that can have more than one copies in the scene;
    public GameObject SoundPlayInLoop;// the prefab object that can have only one copy in the scene;
    

    // play a single sound effect
    public void PlaySound(int clipIndex)
    {
        // create a new sound object and configure it
        GameObject soundPlayOnce = Instantiate(SoundPlayOnce);
        soundPlayOnce.transform.SetParent(SoundPlayOnce.transform.parent);
        AudioSource audioSource = soundPlayOnce.GetComponent<AudioSource>();
        audioSource.clip = audioClips[clipIndex];
        
        // play the sound effect
        audioSource.Play();
        
        // destroy the Audio Source component after the sound effect is played
        Destroy(soundPlayOnce, audioClips[clipIndex].length);
    }

    
    // play a background music
    public void PlayBackgroundMusic(int clipIndex)
    {
        GameObject BGObject = GameObject.Find("Sound_PlayInLoop(Clone)"); 
        // to see if there is BG object exist already;
        if (BGObject == null)
        {
            // create a new sound object and configure it
            GameObject soundPlayInLoop = Instantiate(SoundPlayInLoop);
            soundPlayInLoop.transform.SetParent(transform);
            AudioSource audioSource = soundPlayInLoop.GetComponent<AudioSource>();
            audioSource.clip = audioClips[clipIndex];
            
            // play the background music
            audioSource.Play();
            
        }

    }
}