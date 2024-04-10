using UnityEngine;
using System.Collections.Generic;
using System.IO;
using SqR;

public class BG_pics : MonoBehaviour
{
    public string folderPath;
    private List<Sprite> sprites = new List<Sprite>();

    void Start()
    {
        LoadSprites();
        SetRandomSprite();
    }

    void LoadSprites()
    {
        string[] files = Directory.GetFiles(folderPath);
        foreach (string file in files)
        {
            if (IsImageFile(file))
            {
                byte[] fileData = File.ReadAllBytes(file);
                Texture2D texture = new Texture2D(2, 2);
                texture.LoadImage(fileData);
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);
                sprites.Add(sprite);
            }
        }
    }

    bool IsImageFile(string filePath)
    {
        string extension = Path.GetExtension(filePath).ToLower();
        return extension == ".png" || extension == ".jpg" || extension == ".jpeg" || extension == ".gif" || extension == ".bmp";
    }

    void SetRandomSprite()
    {
        int randomIndex = Random.Range(0, sprites.Count);
        Sprite randomSprite = sprites[randomIndex];
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = randomSprite;
    }
}
