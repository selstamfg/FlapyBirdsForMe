using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    public float moveDuration = 1f;
    public float zoomDuration = 1f;
    public float initialZoom = 2f;
    public float remoteZoom = 5f;
    public float remoteZoomDuration = 12f;

    private bool isMoving = false;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Camera mainCamera;
    private Coroutine zoomOutCoroutine;

    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        mainCamera = Camera.main;
        mainCamera.orthographicSize = initialZoom;
    }

    void OnEnable()
    {
        BirdFly.onTouchedEye += Eye;

        // If the zoomOutCoroutine is already running, just update the remoteZoomDuration parameter
        if (isMoving)
        {
            zoomOutCoroutine = StartCoroutine(ZoomOutCoroutine());
        }
    }



    //void OnEnable()
    //{
    //    BirdFly.onTouchedEye += Eye;

    //    // If the remoteZoomCoroutine is already running, just update the remoteZoomDuration parameter
    //    if (zoomOutCoroutine != null && isMoving)
    //    {
    //        StopCoroutine(zoomOutCoroutine);
    //        zoomOutCoroutine = StartCoroutine(ZoomOutCoroutine());
    //    }
    //}
    //void OnEnable()
    //{
    //    BirdFly.onTouchedEye += Eye;
    //}

    //void OnDisable()
    //{
    //    BirdFly.onTouchedEye -= Eye;
    //}

    void Update()
    {
        if (isMoving)
        {
            Vector3 targetPosition = originalPosition - transform.forward * mainCamera.orthographicSize;

            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime / moveDuration);

            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                zoomOutCoroutine = StartCoroutine(ZoomOutCoroutine());
            }
        }
    }

    IEnumerator ZoomIn(float duration)
    {
        Vector3 startPosition = transform.position;
        Quaternion startRotation = transform.rotation;
        float startZoom = mainCamera.orthographicSize;

        float elapsed = 0f;
        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(startPosition, originalPosition, elapsed / duration);
            transform.rotation = Quaternion.Lerp(startRotation, originalRotation, elapsed / duration);

            mainCamera.orthographicSize = Mathf.Lerp(startZoom, initialZoom, elapsed / duration);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = originalPosition;
        transform.rotation = originalRotation;
        mainCamera.orthographicSize = initialZoom;

        isMoving = false;
    }

    IEnumerator ZoomOutCoroutine()
    {
        isMoving = true;

        // Zoom the camera out to the remote zoom level
        float elapsed = 0f;
        while (elapsed < zoomDuration)
        {
            mainCamera.orthographicSize = Mathf.Lerp(initialZoom, remoteZoom, elapsed / zoomDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        mainCamera.orthographicSize = remoteZoom;

        // Wait for the remote zoom duration
        yield return new WaitForSeconds(remoteZoomDuration);

        // Zoom the camera back in to the initial zoom level
        zoomOutCoroutine = StartCoroutine(ZoomIn(zoomDuration));
    }

    //void Eye()
    //{
    //    // Stop the zoomOutCoroutine if it is running
    //    if (zoomOutCoroutine != null)
    //    {
    //        StopCoroutine(zoomOutCoroutine);
    //    }

    //    // Zoom the camera out to the remote zoom level
    //    zoomOutCoroutine = StartCoroutine(ZoomOutCoroutine());
    //}

    void Eye()
    {
        // If the zoomOutCoroutine is already running, just return
        if (isMoving)
        {
            return;
        }

        // Stop the zoomOutCoroutine if it is running
        if (zoomOutCoroutine != null)
        {
            StopCoroutine(zoomOutCoroutine);
        }

        // Zoom the camera out to the remote zoom level
        zoomOutCoroutine = StartCoroutine(ZoomOutCoroutine());
    }

    private void OnDisable()
    {
        BirdFly.onTouchedEye -= Eye;
    }
}
