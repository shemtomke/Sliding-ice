using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float radius;
    public Vector2 pos;
    public bool isWithinRange;

    private void Start()
    {
        pos = transform.position;

        // Get the radius of the target

    }
    // as you get further away the less points - perferction! (radius)

    // player has completed the level - hit the red circle.


}