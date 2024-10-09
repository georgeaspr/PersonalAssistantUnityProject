using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SFB;

public class aManager : MonoBehaviour
{
    private string folderPath;
    private string[] songs;
    private int currentSongIndex;
    private AudioSource source;
    private string duration;


    public Text clipTitleText;
    public Text clipTimeText;
    private Text songTotalTime;

    public Transform songsPanel;
    public Transform scrollPanel;
    public GameObject songButtonPrefab;

    public GameObject playButton;
    public GameObject pauseButton;
    public GameObject unpauseButton;


    private void Start()
    {
        folderPath = Path.Combine(Application.persistentDataPath, "Music");

        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        LoadSongsFromFolder();
        currentSongIndex = 0;
        source = GetComponent<AudioSource>();
        CreateSongButtons();
    }

    private void Update()
    {
        if (source.isPlaying)
        {
            ShowPlayTime();
        }
    }

    private void LoadSongsFromFolder()
    {
        songs = Directory.GetFiles(folderPath, "*.mp3");
        Array.Sort(songs);
    }

    private void CreateSongButtons()
    {
        Vector2 buttonPosition = new Vector2(-10f, 292f);

        float panelHeight = 0f;
        List<GameObject> buttons = new List<GameObject>();


        foreach (string songPath in songs)
        {
            GameObject songButtonObject = Instantiate(songButtonPrefab, songsPanel);
            Button songButton = songButtonObject.GetComponent<Button>();
            Text buttonText = songButtonObject.GetComponentInChildren<Text>();
            buttonText.text = Path.GetFileNameWithoutExtension(songPath);

            songButtonObject.GetComponent<RectTransform>().anchoredPosition = buttonPosition;

            buttons.Add(songButtonObject);

            panelHeight += 104f;
            buttonPosition.y -= 104f;

            songButton.onClick.AddListener(() =>
            {
                int index = Array.IndexOf(songs, songPath);
                if (index != -1)
                {
                    currentSongIndex = index;
                    Play();

                    SetButtonTextColor(songButton, "#00FFA8FF");

                    foreach (Button otherButton in songsPanel.GetComponentsInChildren<Button>())
                    {
                        if (otherButton != songButton)
                        {
                            SetButtonTextColor(otherButton, "#FFFFFF");
                        }
                    }
                }
                playButton.SetActive(false);
                pauseButton.SetActive(true);
                unpauseButton.SetActive(false);
            });
        }

        Debug.Log(panelHeight);

        RectTransform songsPanelRectTransform = scrollPanel.GetComponent<RectTransform>();
        Vector2 sizeDelta = songsPanelRectTransform.sizeDelta;
        sizeDelta.y = panelHeight;
        songsPanelRectTransform.sizeDelta = sizeDelta;

        sizeDelta = songsPanelRectTransform.anchoredPosition;
        sizeDelta.y = -panelHeight / 2;
        songsPanelRectTransform.anchoredPosition = sizeDelta;

        foreach (GameObject button in buttons)
        {
            button.transform.SetParent(scrollPanel.transform);
        }

    }

    public void Play()
    {
        if (songs.Length == 0)
        {
            Debug.LogWarning("No songs found in the folder.");
            return;
        }

        string currentSong = songs[currentSongIndex];
        StartCoroutine(PlaySong(currentSong));
    }

    private void SetButtonTextColor(Button button, string colorCode)
    {
        Text buttonText = button.GetComponentInChildren<Text>();

        if (ColorUtility.TryParseHtmlString(colorCode, out Color color))
        {
            buttonText.color = color;
        }
        else
        {
            Debug.LogError("Invalid color code: " + colorCode);
        }
    }

    private IEnumerator PlaySong(string songPath)
    {
        source.Stop();
        source.clip = null;

        using (var www = new WWW("file://" + songPath))
        {
            yield return www;

            source.clip = www.GetAudioClip();
            source.Play();
        }

        if (clipTitleText != null)
        {
            string currentSongTitle = GetCurrentSongTitle(songPath);
            clipTitleText.text = currentSongTitle;
        }

        Debug.Log("Now playing: " + Path.GetFileName(songPath));
    }

    public void NextSong()
    {
        currentSongIndex++;
        if (currentSongIndex >= songs.Length)
            currentSongIndex = 0;

        foreach (Button songButton in songsPanel.GetComponentsInChildren<Button>())
        {
                SetButtonTextColor(songButton, "#FFFFFF");
        }

        Play();
    }

    public void PreviousSong()
    {
        currentSongIndex--;
        if (currentSongIndex < 0)
            currentSongIndex = songs.Length - 1;

        foreach (Button songButton in songsPanel.GetComponentsInChildren<Button>())
        {
            SetButtonTextColor(songButton, "#FFFFFF");
        }

        Play();
    }

    public void Pause()
    {
        source.Pause();
    }

    public void Unpause()
    {
        source.UnPause();
    }

    private string GetCurrentSongTitle(string songPath)
    {
        string currentSongTitle = System.IO.Path.GetFileNameWithoutExtension(songPath);
        return currentSongTitle;
    }

    void ShowPlayTime()
    {
        float currentTime = source.time;
        float totalLength = source.clip != null ? source.clip.length : 0f;

        int currentSeconds = (int)currentTime % 60;
        int currentMinutes = (int)(currentTime / 60) % 60;

        int totalSeconds = (int)totalLength % 60;
        int totalMinutes = (int)(totalLength / 60) % 60;

        string currentTimeText = string.Format("{0:D2}:{1:D2}", currentMinutes, currentSeconds);
        string totalTimeText = string.Format("{0:D2}:{1:D2}", totalMinutes, totalSeconds);

        //songTotalTime.text = totalTimeText;
        clipTimeText.text = currentTimeText + " / " + totalTimeText;
    }

    public void AddSongFromFileExplorer()
    {
        string selectedFile = string.Empty;
        var extensions = new[] {
            new ExtensionFilter("MP3 Files", "mp3"),
        };

        var paths = StandaloneFileBrowser.OpenFilePanel("Select Audio", "", extensions, false);
        if (paths.Length > 0)
        {
            selectedFile = paths[0];
            Debug.Log("Selected MP3 Path: " + selectedFile);
        }
        else
        {
            Debug.Log("No MP3 selected.");
        }

        if (!string.IsNullOrEmpty(selectedFile))
        {
            string fileName = Path.GetFileName(selectedFile);
            string savePath = Path.Combine(folderPath, fileName);

            Array.Resize(ref songs, songs.Length + 1);
            songs[songs.Length - 1] = selectedFile;
            Debug.Log("Added song: " + Path.GetFileName(selectedFile));

            File.Copy(selectedFile, savePath);

            foreach (Transform child in scrollPanel)
            {
                Destroy(child.gameObject);
            }

            CreateSongButtons();
        }
        
    }

    public void DeleteSongFromFileExplorer()
    {
        if (Directory.GetFiles(folderPath).Length > 0)
        {
            string selectedFile = string.Empty;
            var extensions = new[] {
                new ExtensionFilter("MP3 Files", "mp3"),
            };

            var paths = StandaloneFileBrowser.OpenFilePanel("Select Audio", folderPath, extensions, false);
            if (paths.Length > 0)
            {
                selectedFile = paths[0];
                Debug.Log("Selected MP3 Path: " + selectedFile);
            }
            else
            {
                Debug.Log("No MP3 selected.");
            }
            selectedFile = selectedFile.Replace("\\", "/");
            folderPath = folderPath.Replace("\\", "/");
            Debug.Log("Selected File: " + selectedFile);
            Debug.Log("Folder Path: " + folderPath);
            Debug.Log(selectedFile.Contains(folderPath));
            if (selectedFile.Contains(folderPath))
            {
                if (File.Exists(selectedFile))
                {
                    File.Delete(selectedFile);
                    Debug.Log("File deleted: " + selectedFile);
                }
                LoadSongsFromFolder();
                foreach (Transform child in scrollPanel)
                {
                    Destroy(child.gameObject);
                }
                CreateSongButtons();
            }
            else
            {
                Debug.Log("The file selected is not in the right direcrory.");
            }

        }
    }
}
