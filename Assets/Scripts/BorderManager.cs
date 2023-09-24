using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderManager : MonoBehaviour
{
    public GameObject borderPrefab;

    public float borderyOffset;
    public float borderxOffset;

    [Header("Left Border")]
    public Vector2 startPosLeft;
    public Vector2 endPosLeft;

    [Header("Right Border")]
    public Vector2 startPosRight;
    public Vector2 endPosRight;

    private Camera mainCamera;
    private void Start()
    {
        mainCamera = Camera.main;

        float halfCameraWidth = mainCamera.orthographicSize * mainCamera.aspect;

        // Calculate minX and maxX based on the camera's position and size
        float minX = mainCamera.transform.position.x - halfCameraWidth;
        float maxX = mainCamera.transform.position.x + halfCameraWidth;

        float leftOffset = minX + borderxOffset;
        float rightOffset = maxX - borderxOffset;

        startPosLeft.x = leftOffset;
        endPosLeft.x = leftOffset;

        startPosRight.x = rightOffset;
        endPosRight.x = rightOffset;

        GenerateLeftBorder();
        GenerateRightBorder();
    }
    void GenerateLeftBorder()
    {
        float distance = Vector2.Distance(startPosLeft, endPosLeft);
        int numberOfPrefabs = Mathf.CeilToInt(distance / borderyOffset);

        Vector2 direction = (endPosLeft - startPosLeft).normalized;

        // Get the transform of the GameObject where this script is attached
        Transform parentTransform = transform;

        for (int i = 0; i < numberOfPrefabs; i++)
        {
            Vector2 position = startPosLeft + direction * i * borderyOffset;
            GameObject instantiatedObject = Instantiate(borderPrefab, position, Quaternion.identity);

            // Set the parent of the instantiated object to the script's GameObject
            instantiatedObject.transform.SetParent(parentTransform);
        }
    }
    void GenerateRightBorder()
    {
        float distance = Vector2.Distance(startPosRight, endPosRight);
        int numberOfPrefabs = Mathf.CeilToInt(distance / borderyOffset);

        Vector2 direction = (endPosRight - startPosRight).normalized;

        // Get the transform of the GameObject where this script is attached
        Transform parentTransform = transform;

        for (int i = 0; i < numberOfPrefabs; i++)
        {
            Vector2 position = startPosRight + direction * i * borderyOffset;
            GameObject instantiatedObject = Instantiate(borderPrefab, position, Quaternion.identity);

            // Set the parent of the instantiated object to the script's GameObject
            instantiatedObject.transform.SetParent(parentTransform);
        }
    }
}
