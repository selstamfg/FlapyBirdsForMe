using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwi : MonoBehaviour
{

    public GameObject[] sceneCanvases;
    public GameObject spritePrefab;
    public float fadeInTime = 1.0f;
    public float fadeOutTime = 1.0f;

    private GameObject currentSprite;

    private void Awake()
    {
        // ��������� ��� gameOverCanvas
        foreach (GameObject canvas in sceneCanvases)
        {
            canvas.SetActive(false);
        }
        sceneCanvases[0].SetActive(true);
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

        //if (currentSprite != null)
        //{
        //    StartCoroutine(FadeOut(currentSprite.GetComponent<SpriteRenderer>()));
        //}

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
                sceneCanvases[currentIndex + 1].SetActive(true);
            }
            else
            {
                sceneCanvases[0].SetActive(true);
            }
        }
        SpawnSprite();
    }

    private void AnimCallback()
    {

    }

    private void SpawnSprite()
    {
        // ������� ����� ������ �� �������
        currentSprite = Instantiate(spritePrefab, transform.position, Quaternion.identity, transform);
        // ������������� ��������� ������������ �������
        //Color spriteColor = currentSprite.GetComponent<SpriteRenderer>().color;
        //spriteColor.a = 0;
        //currentSprite.GetComponent<SpriteRenderer>().color = spriteColor;
        // ��������� �������� �������� ��������� �������
        //StartCoroutine(FadeIn(currentSprite.GetComponent<SpriteRenderer>()));

        RectTransform rect = currentSprite.GetComponent<RectTransform>();
        LeanTween.alpha(rect, 0, 0);
        LeanTween.alpha(rect, 1, 0.4f).setOnComplete(() =>
        {
            LeanTween.alpha(rect, 0, 0.4f);
        });
    }

    private IEnumerator FadeIn(SpriteRenderer spriteRenderer)
    {
        // ������������� �������� ������������ �������
        Color endColor = spriteRenderer.color;
        endColor.a = 1;
        // �������� ������������ ������� �� �������
        for (float t = 0; t < fadeInTime; t += Time.deltaTime)
        {
            spriteRenderer.color = Color.Lerp(spriteRenderer.color, endColor, t / fadeInTime);
            yield return null;
        }
    }

    private IEnumerator FadeOut(SpriteRenderer spriteRenderer)
    {
        Color endColor = spriteRenderer.color;
        endColor.a = 0;
        for (float t = 0; t < fadeOutTime; t += Time.deltaTime)
        {
            spriteRenderer.color = Color.Lerp(spriteRenderer.color, endColor, t / fadeOutTime);
            yield return null;
        }
        // ������� ������
        Destroy(currentSprite);
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
