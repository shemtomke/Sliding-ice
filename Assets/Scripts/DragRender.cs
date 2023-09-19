using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragRender : MonoBehaviour
{
    public List<Sprite> topDragUINotifications;

    [NonReorderable]
    public List<DotsRange> dragDotsRange;

    public Sprite defaultDrag;

    public Image topDragNotification;
    public GameObject dragDot;

    private void Start()
    {
        topDragNotification.sprite = defaultDrag;
    }

    void StartGame()
    {
        dragDot.SetActive(true);
        topDragNotification.gameObject.SetActive(true);
    }
}
[Serializable]
public class DotsRange
{
    public Sprite dots;
    public Vector3 dotsPos;
}