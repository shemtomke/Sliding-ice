using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float power = 10f;
    public float maxDrag = 5f;
    public Rigidbody2D rb;

    Touch touch;
    Vector2 dragStartPos;

    private void Update()
    {
        Move();
    }
    void Move()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                DragStart();
            }
            if (touch.phase == TouchPhase.Moved)
            {
                Dragging();
            }
            if (touch.phase == TouchPhase.Moved)
            {
                DragRelease();
            }
        }

        // Check if the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            DragStart();
        }

        // Check if the left mouse button is held down and moving
        if (Input.GetMouseButton(0))
        {
            Dragging();
        }

        // Check if the left mouse button was released
        if (Input.GetMouseButtonUp(0))
        {
            DragRelease();
        }
    }
    void DragStart()
    {
        dragStartPos = Camera.main.ScreenToWorldPoint(touch.position);
        Debug.Log("Dragging Start!");
    }
    void Dragging()
    {
        Debug.Log("Dragging!");
    }
    void DragRelease()
    {
        Debug.Log("Dragging Released!");
        Vector2 drafReleasePos = Camera.main.ScreenToWorldPoint(touch.position);
        Vector2 force = dragStartPos - drafReleasePos;
        Vector2 clampedForce = Vector2.ClampMagnitude(force, maxDrag) * power;

        rb.AddForce(clampedForce, ForceMode2D.Impulse);
    }
}