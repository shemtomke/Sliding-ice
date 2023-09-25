using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float moveForce = 10.0f; // The force with which the object moves away

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Calculate the direction away from the collision point
        Vector2 awayDirection = (transform.position - (Vector3)collision.contacts[0].point).normalized;

        // Apply an instantaneous force in the opposite direction
        rb.AddForce(awayDirection * moveForce, ForceMode2D.Impulse);
    }
}