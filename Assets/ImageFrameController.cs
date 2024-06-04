using UnityEngine;
using UnityEngine.UI;

public class ImageFrameController : MonoBehaviour
{
    public RawImage imageFrame; // ������ �� RawImage � ����������

    // ����� ��� ��������� �����������
    public void SetImage(Texture2D texture)
    {
        imageFrame.texture = texture;
    }

    private void Start()
    {
        // ���� � ������� ������������ ����� Resources
        string imagePath = "myImage"; // ��� ����� ��� ����������

        // ��������� ������
        Texture2D loadedTexture = Resources.Load<Texture2D>(imagePath);

        // ������������� ����������� �������� � RawImage
        SetImage(loadedTexture);
    }

}