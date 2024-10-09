using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public AudioClip[] musicList;
    private int currentTrack;
    private AudioSource source;

    public Text clipTitleText;
    public Text clipTimeText;

    private int length;
    private int playTime;
    private int minutes;
    private int seconds;
    private bool isPaused = false;
    private string songsFolderPath;

    void Start()
    {
        songsFolderPath = Path.Combine(Application.persistentDataPath, "Music");

        if (!Directory.Exists(songsFolderPath))
            Directory.CreateDirectory(songsFolderPath);

        source = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        if (source.isPlaying)
        {
            return;
        }
        currentTrack--;
        if (currentTrack < 0)
        {
            currentTrack = musicList.Length - 1;
        }

        StartCoroutine("WaitForMusicEnd");
    }

    IEnumerator WaitForMusicEnd()
    {
        while (source.isPlaying)
        {
            playTime = (int)source.time;
            ShowPlayTime();
            yield return null;
        }
        NextTitle();
    }

    public void NextTitle()
    {
        source.Stop();
        currentTrack++;
        if (currentTrack > musicList.Length - 1)
        {
            currentTrack = 0;
        }
        source.clip = musicList[currentTrack];
        source.Play();

        ShowCurrentTitle();

        StartCoroutine("WaitForMusicEnd");
    }

    public void PreviousTitle()
    {
        source.Stop();
        currentTrack--;
        if (currentTrack < 0)
        {
            currentTrack = musicList.Length - 1;
        }
        source.clip = musicList[currentTrack];
        source.Play();

        ShowCurrentTitle();

        StartCoroutine("WaitForMusicEnd");
    }

    public void PauseMusic()
    {
        if (!isPaused)
        {
            source.Pause();
            isPaused = true;
        }
    }

    public void ContinueMusic()
    {
        if (isPaused)
        {
            source.UnPause();
            isPaused = false;
        }
    }

    void ShowCurrentTitle()
    {
        clipTitleText.text = source.clip.name;
        length = (int)source.clip.length;
    }

    void ShowPlayTime()
    {
        seconds = playTime % 60;
        minutes = (playTime / 60) % 60;
        clipTimeText.text = minutes + ":" + seconds.ToString("D2") + "/" + ((length / 60) % 60) + ":" + ((length % 60).ToString("D2"));
    }
}