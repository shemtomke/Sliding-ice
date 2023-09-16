using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float power = 10f;
    public float maxDrag = 5f;
    public Rigidbody2D rb;
    public GameObject[] dragRender;

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
    }
    void DragStart()
    {

    }
    void Dragging()
    {

    }
    void DragRelease()
    {

    }
}