using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragRender : MonoBehaviour
{
    public List<Sprite> topDragUINotifications;
    public List<Sprite> dragDots;

    public Sprite defaultDrag;

    public Image topDragNotification;
    public GameObject dragDot;

    private void Start()
    {
        topDragNotification.sprite = defaultDrag;
    }

}
