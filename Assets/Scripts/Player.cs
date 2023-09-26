using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float slideForce;
    public float power;
    public float maxDrag;
    public Rigidbody2D rb;

    public float stopThreshold = 0.01f;
    public bool isStop = false;
    public bool isDoneDragging = false; 
    public bool isSliding = false;

    Touch touch;
    Vector2 dragStartPos;
    Vector2 touchStartPos;

    DragRender dragRender;

    private void Start()
    {
        dragRender = FindObjectOfType<DragRender>();
    }

    private void Update()
    {
        if (!isDoneDragging)
            Move();
        else
            Slide();

        // Check if the velocity magnitude is below the stop threshold
        if (rb.velocity.magnitude < stopThreshold)
        {
            isStop = true;
            rb.velocity = Vector3.zero;
        }
        else
        {
            isStop = false;
        }
    }
    void Move()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Get the first touch

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    DragStart();
                    break;

                case TouchPhase.Moved:
                    Dragging();
                    break;

                case TouchPhase.Ended:
                    DragRelease();
                    break;
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
        dragStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    void Dragging()
    {
        Vector2 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float distance = Vector2.Distance(dragStartPos, currentPos);
        maxDrag = distance;

        int dist1 = Mathf.FloorToInt((distance * dragRender.topDragUINotifications.Count) / 5);
        int dist2 = Mathf.FloorToInt((distance * dragRender.dragDotsRange.Count) / 5);

        if (dist1 >= 0 && dist1 < dragRender.topDragUINotifications.Count)
        {
            dragRender.topDragNotification.sprite = dragRender.topDragUINotifications[dist1];
        }

        if (dist2 >= 0 && dist2 < dragRender.dragDotsRange.Count)
        {
            dragRender.dragDot.GetComponent<SpriteRenderer>().sprite = dragRender.dragDotsRange[dist2].dots;
            dragRender.dragDot.transform.localPosition = dragRender.dragDotsRange[dist2].dotsPos;
        }
    }
    void DragRelease()
    {
        rb.AddForce(Vector2.up * (power * maxDrag), ForceMode2D.Impulse);
        dragRender.dragDot.SetActive(false);
        dragRender.topDragNotification.gameObject.SetActive(false);
        isDoneDragging = true;
    }
    void Slide()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && !isSliding)
            {
                touchStartPos = Camera.main.ScreenToWorldPoint(touch.position);
                isSliding = true;
            }
            else if (isSliding && touch.phase == TouchPhase.Moved)
            {
                Vector2 touchCurrentPos = Camera.main.ScreenToWorldPoint(touch.position);
                Vector2 slideDirection = touchCurrentPos - touchStartPos;

                // You can choose to restrict sliding to a specific direction if needed.
                // For example, to only slide horizontally, you can set slideDirection.y = 0;

                rb.velocity += slideDirection.normalized * slideForce; // Add slide velocity to the existing velocity
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isSliding = false; // Stop sliding when the touch is released
            }
        }
        else if (Input.GetMouseButton(0)) // Check for mouse input
        {
            if (!isSliding)
            {
                touchStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                isSliding = true;
            }
            else
            {
                Vector2 touchCurrentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 slideDirection = touchCurrentPos - touchStartPos;

                // You can choose to restrict sliding to a specific direction if needed.
                // For example, to only slide horizontally, you can set slideDirection.y = 0;

                rb.velocity += slideDirection.normalized * slideForce; // Add slide velocity to the existing velocity
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isSliding = false; // Stop sliding when the mouse button is released
        }
    }
}