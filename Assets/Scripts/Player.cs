using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float power;
    public float maxDrag;
    public Rigidbody2D rb;

    Touch touch;
    Vector2 dragStartPos;

    DragRender dragRender;

    private void Start()
    {
        dragRender = FindObjectOfType<DragRender>();
    }

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
        dragStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log("Dragging Start!");
    }
    void Dragging()
    {
        Vector2 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // use touch position
        float distance = Vector2.Distance(dragStartPos, currentPos);
        maxDrag += distance;

        Debug.Log("Dragging Distance: " + distance);

        int dist = Mathf.FloorToInt(distance);
        dragRender.topDragNotification.sprite = dragRender.topDragUINotifications[dist];
        dragRender.dragDot.GetComponent<SpriteRenderer>().sprite = dragRender.dragDots[dist];
    }
    void DragRelease()
    {
        Debug.Log("Dragging Released!");
        rb.AddForce(Vector2.up * (power * maxDrag), ForceMode2D.Impulse);
    }
}