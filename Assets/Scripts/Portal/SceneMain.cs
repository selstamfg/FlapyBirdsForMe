using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMain : MonoBehaviour
{
    public GameObject[] sceneCanvases;

    private int currentCanvasIndex = 0;
    public RectTransform _whiteSpritePrefab;
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

        _whiteSpritePrefab.gameObject.SetActive(true);

        LeanTween.alpha(_whiteSpritePrefab, 0, 0);
        LeanTween.alpha(_whiteSpritePrefab, 1, 0.25f).setOnComplete(() =>
        {
            LeanTween.delayedCall(gameObject, 0.5f, () =>
            {
                LeanTween.alpha(_whiteSpritePrefab, 0, 0.25f).setOnComplete(() =>
                {
                    _whiteSpritePrefab.gameObject.SetActive(false);
                });
            });
        });

        //whiteSprite = Instantiate(_whiteSpritePrefab);
        //whiteSprite.transform.position = Camera.main.transform.position + Camera.main.transform.forward;
        //StartCoroutine(FadeOut(whiteSprite.GetComponent<SpriteRenderer>()));
        //  _squareReset.transform.parent = transform;
        //  StartCoroutine(FadeOut(_squareReset.GetComponent<SpriteRenderer>().material));
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
    //private IEnumerator FadeOut(Material material)
    //{
    //    // ������������� ��������� ������������ ����
    //    material.color = new Color(0, 0, 0, 1);

    //    // ������������� �������� ������������ ����
    //    Color endColor = new Color(0, 0, 0, 0);

    //    // �������� ������������ ���� �� �������
    //    for (float t = 0; t < fadeOutTime; t += Time.deltaTime)
    //    {
    //        material.color = Color.Lerp(material.color, endColor, t/fadeOutTime);
    //        yield return null;
    //    }

    //    // ������� ������ ���
    //    Destroy(_squareReset);
    //}


    private void OnEnable()
    {
        Portal.onTouchedPortal += Reset;
    }
    private void OnDisable()
    {
        Portal.onTouchedPortal -= Reset;
        LeanTween.cancel(gameObject);
        if (_whiteSpritePrefab != null)
            LeanTween.cancel(_whiteSpritePrefab.gameObject);
    }
}
