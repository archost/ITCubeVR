using UnityEngine;
using UnityEngine.UI;

public class ImageFrameController : MonoBehaviour
{
    public RawImage imageFrame; // Ссылка на RawImage в инспекторе

    // Метод для установки изображения
    public void SetImage(Texture2D texture)
    {
        imageFrame.texture = texture;
    }

    private void Start()
    {
        // Путь к ресурсу относительно папки Resources
        string imagePath = "myImage"; // Имя файла без расширения

        // Загружаем ресурс
        Texture2D loadedTexture = Resources.Load<Texture2D>(imagePath);

        // Устанавливаем загруженную текстуру в RawImage
        SetImage(loadedTexture);
    }

}