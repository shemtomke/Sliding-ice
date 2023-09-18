using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform

    public Vector3 offset = new Vector3(0f, 0f, -10f); // Adjust this to set the camera's offset from the player

    void FixedUpdate()
    {
        if (player != null)
        {
            // Calculate the new camera position
            Vector3 targetPosition = player.position + offset;

            // Smoothly move the camera towards the target position using Lerp
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5f);
        }
    }
}
