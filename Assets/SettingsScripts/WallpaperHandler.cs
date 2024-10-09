using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using SFB;

public class WallpaperHandler : MonoBehaviour
{
    public Canvas canvas;
    public Button changeButton;
    public Button removeButton;

    private string wallpaperFolderPath;
    private string imageDirectory;
    private Image image;

    private void Start()
    {
        wallpaperFolderPath = Path.Combine(Application.persistentDataPath, "Wallpaper");

        if (!Directory.Exists(wallpaperFolderPath))
            Directory.CreateDirectory(wallpaperFolderPath);

        loadImage();
    }

    public void changeImage()
    {
        string imagePath = string.Empty;
        var extensions = new[] {
            new ExtensionFilter("Image Files", "png", "jpg", "jpeg" ),
        };

        var paths = StandaloneFileBrowser.OpenFilePanel("Select Image", "", extensions, false);
        if (paths.Length > 0)
        {
            imagePath = paths[0];
            Debug.Log("Selected Image Path: " + imagePath);
        }
        else
        {
            Debug.Log("No image selected.");
        }


        if (!string.IsNullOrEmpty(imagePath))
        {
            removeImage();
            string fileName = Path.GetFileName(imagePath);
            string savePath = Path.Combine(wallpaperFolderPath, fileName);

            File.Copy(imagePath, savePath);
        }

        loadImage();
    }

    private void loadImage()
    {
        string[] files = Directory.GetFiles(wallpaperFolderPath);

        Debug.Log("Number of files: " + files.Length);

        if (files.Length != 0)
        {
            imageDirectory = Path.Combine(wallpaperFolderPath, files[0]);

            byte[] imageData = File.ReadAllBytes(imageDirectory);

            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(imageData);

            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);

            image = canvas.GetComponent<Image>();
            image.color = Color.white;
            image.sprite = sprite;
        }
        else
        {
            image = canvas.GetComponent<Image>();

            image.sprite = null;

            image.color = new Color32(0x37, 0x37, 0x37, 0xFF);
        }
    }

    public void removeImage()
    {
        string[] files = Directory.GetFiles(wallpaperFolderPath);

        foreach (string filePath in files)
        {
            File.Delete(filePath);
        }

        loadImage();
    }
}