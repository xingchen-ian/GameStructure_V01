using UnityEngine;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    public List<AudioClip> audioClips; // 储存所有的音频剪辑

    // 播放单一音效
    public void PlaySound(int clipIndex)
    {
        // 创建一个新的Audio Source组件并配置它
        AudioSource newAudioSource = gameObject.AddComponent<AudioSource>();
        newAudioSource.clip = audioClips[clipIndex];
        
        // 播放音效
        newAudioSource.Play();
        
        // 音效播放完成后，销毁Audio Source组件
        Destroy(newAudioSource, audioClips[clipIndex].length);
    }

    // 播放背景音乐
    public void PlayBackgroundMusic(int clipIndex)
    {
        // 创建一个新的Audio Source组件并配置它
        AudioSource newAudioSource = gameObject.AddComponent<AudioSource>();
        newAudioSource.clip = audioClips[clipIndex];
        newAudioSource.loop = true; // 设置为循环播放

        // 播放背景音乐
        newAudioSource.Play();
    }
}