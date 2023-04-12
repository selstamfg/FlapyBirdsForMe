using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMain2 : MonoBehaviour
{
    public GameObject[] sceneCanvases;

    private int currentCanvasIndex = 0;
    public GameObject _whiteSpritePrefab;
    public float fadeOutTime = 1.0f;

    private GameObject whiteSprite;

    private void Awake()
    {
        // ��������� ��� gameOverCanvas
        foreach (GameObject canvas in sceneCanvases)
        {
            canvas.SetActive(false);
        }
        sceneCanvases[currentCanvasIndex].SetActive(true);
    }

    public void Reset()
    {
        // ����� ������� gameOverCanvas
        GameObject currentCanvas = null;
        foreach (GameObject canvas in sceneCanvases)
        {
            if (canvas.activeSelf)
            {
                currentCanvas = canvas;
                break;
            }
        }

        if (currentCanvas == null)
        {
            // ���� ��� �������� gameOverCanvas, �� �������� ������
            sceneCanvases[0].SetActive(true);
        }
        else
        {
            // ��������� ������� gameOverCanvas
            currentCanvas.SetActive(false);

            // ����� ������ �������� gameOverCanvas � �������
            int currentIndex = System.Array.IndexOf(sceneCanvases, currentCanvas);

            if (currentIndex >= 0 && currentIndex < sceneCanvases.Length - 1)
            {
                // ���� ������� gameOverCanvas �� ���������, �� �������� ���������
                sceneCanvases[currentIndex + 1].SetActive(true);
            }
            else
            {
                // ���� ������� gameOverCanvas ���������, �� �������� ������
                sceneCanvases[0].SetActive(true);
            }
        }
        whiteSprite = Instantiate(_whiteSpritePrefab);
        float distance = 10f; // ���������� �� ������ �� �������
        whiteSprite.transform.position = Camera.main.transform.position + Camera.main.transform.forward * distance;
        StartCoroutine(FadeOut(whiteSprite.GetComponent<SpriteRenderer>()));
    }

    private IEnumerator FadeOut(SpriteRenderer spriteRenderer)
    {
        Color startColor = spriteRenderer.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0);

        for (float t = 0; t < fadeOutTime; t += Time.deltaTime)
        {
            spriteRenderer.color = Color.Lerp(startColor, endColor, t / fadeOutTime);
            yield return null;
        }

        Destroy(whiteSprite);
    }

    private void OnEnable()
    {
        Portal.onTouchedPortal += Reset;
    }

    private void OnDisable()
    {
        Portal.onTouchedPortal -= Reset;
    }
}
