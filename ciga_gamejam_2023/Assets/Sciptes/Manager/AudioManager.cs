
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] music;
    public AudioClip[] audios;
    public AudioSource musicPlayer;
    public AudioSource audioPlayer;

    public Slider musicSlider;
    public Slider audioSlider;

    private void Start()
    {


        musicSlider.value = musicPlayer.volume;
        audioSlider.value = audioPlayer.volume;

        musicSlider.onValueChanged.AddListener((value) =>
        {
            musicPlayer.volume = value;
        });

        audioSlider.onValueChanged.AddListener((value) =>
        {
            audioPlayer.volume = value;
        });
    }

    /*
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            MusicChange(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            MusicChange(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            MusicChange(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            AudioPlay(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            AudioPlay(5);
        }
    }*/

    /// <summary>
    /// 背景音乐修改方法，传入0，1，2分别对应低碳、碳平衡和高碳
    /// </summary>
    public void MusicChange(int i)
    {
        float timeNow = musicPlayer.time;
        musicPlayer.Pause();
        musicPlayer.clip = music[i];
        musicPlayer.time = timeNow;
        musicPlayer.Play();
    }

    /// <summary>
    /// 音效播放方法，传入id播放对应音乐（现允许范围1-21）
    /// </summary>
    public void AudioPlay(int i)
    {
        //Debug.Log("播放" + i);
        audioPlayer.Pause();
        audioPlayer.clip = audios[i];
        audioPlayer.time = 0.0f;
        audioPlayer.Play();
    }
}
