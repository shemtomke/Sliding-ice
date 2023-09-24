using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float power;
    public float maxDrag;
    public Rigidbody2D rb;

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
        // move the player right or left or up or down to meet the target

        // touch direction
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                
            }
            if (touch.phase == TouchPhase.Moved)
            {
                
            }
            if (touch.phase == TouchPhase.Moved)
            {
                
            }
        }

        // Check if the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Start dragging!");
        }
        // Check if the left mouse button is held down and moving
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Get where to drag!");
        }
        // Check if the left mouse button was released
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Drag to that position!");
        }
    }
}