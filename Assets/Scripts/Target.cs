using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public bool isWithinRange;
    public GameObject player;

    private void Start()
    {
        
    }
    private void Update()
    {
        DetectVictory();
    }
    void DetectVictory()
    {
        // Get the bounds of the detector and target objects
        Bounds targetBounds = this.GetComponent<SpriteRenderer>().bounds;
        Bounds playerBounds = player.GetComponent<SpriteRenderer>().bounds;

        // Check if the target object's bounds are fully or partially inside the detector's bounds
        isWithinRange = targetBounds.Contains(playerBounds.min) && targetBounds.Contains(playerBounds.max);

        if (isWithinRange)
        {
            Debug.Log("Target object is fully or partially inside the detector's bounds.");
        }
        else
        {
            Debug.Log("Target object is outside the detector's bounds.");
        }
    }
}