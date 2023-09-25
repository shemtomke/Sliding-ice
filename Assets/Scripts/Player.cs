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

    Touch touch;
    Vector2 dragStartPos;

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
        }
        else
        {
            isStop = false;
        }
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
        dragStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log("Dragging Start!");
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
        Debug.Log("Dragging Released!");
        rb.AddForce(Vector2.up * (power * maxDrag), ForceMode2D.Impulse);
        dragRender.dragDot.SetActive(false);
        dragRender.topDragNotification.gameObject.SetActive(false);
        isDoneDragging = true;
    }
    void Slide()
    {
        Vector2 targetPosition = Vector2.zero; // Initialize the target position as (0, 0) or your desired default position

        // Touch input handling
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // Store the touch start position as the target
                targetPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                // Calculate the direction vector from the current touch position to the target position
                Vector2 direction = (touch.position - targetPosition).normalized;

                // Move the player in the calculated direction
                transform.Translate(direction * slideForce * Time.deltaTime);
            }
        }

        // Mouse input handling
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Start dragging!");
            targetPosition = (Vector2)Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            Debug.Log("Get where to drag!");

            Vector2 direction = ((Vector2)Input.mousePosition - targetPosition).normalized;
            transform.Translate(direction * slideForce * Time.deltaTime);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Drag to that position!");
            targetPosition = Vector2.zero; // Reset the target position after releasing the mouse button
        }
    }
}