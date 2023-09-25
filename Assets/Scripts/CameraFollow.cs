using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform
    public Vector3 offset = new Vector3(0f, 0f, -10f);
    public float minY, maxY;
    public float minX, maxX;
    void FixedUpdate()
    {
        if (player != null)
        {
            // Calculate the new camera position
            Vector3 targetPosition = player.position + offset;

            // Limit the camera's Y-axis position to a maximum value
            targetPosition.y = Mathf.Clamp(targetPosition.y, minY, maxY);

            // Limit the camera's X-axis position to the defined range
            targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);

            // Smoothly move the camera towards the target position using Lerp
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 10f);
        }
    }
}