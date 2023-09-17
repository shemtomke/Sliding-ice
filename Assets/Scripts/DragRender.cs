using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragRender : MonoBehaviour
{
    public List<Sprite> topDragUINotifications;
    public List<Sprite> dragDots;

    public Vector2 startDragPos;

    public Image topDragNotification;

    public Sprite defaultDrag;

    private void Start()
    {
        topDragNotification.sprite = defaultDrag;
    }

}
