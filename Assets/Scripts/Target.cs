using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public bool isWithinRange;
    public GameObject player;
    public GameManager gameManager;

    private void Start()
    {
        gameManager.victoryUI.SetActive(false);
        gameManager.gameOverUI.SetActive(false);
    }
    private void Update()
    {
        DetectRange();
    }
    void DetectRange()
    {
        // Get the bounds of the detector and target objects
        Bounds targetBounds = this.GetComponent<SpriteRenderer>().bounds;
        Bounds playerBounds = player.GetComponent<SpriteRenderer>().bounds;

        // Check if the target object's bounds are fully or partially inside the detector's bounds
        isWithinRange = targetBounds.Contains(playerBounds.min) && targetBounds.Contains(playerBounds.max);

        if (isWithinRange)
        {
            Victory();
        }
        else
        {
            GameOver();
        }
    }
    void Victory()
    {
        if(player.GetComponent<Player>().isStop && player.GetComponent<Player>().isDoneDragging)
        {
            // Victory GameObject set to true
            gameManager.victoryUI.SetActive(true);
        }
    }
    void GameOver()
    {
        if (player.GetComponent<Player>().isStop && player.GetComponent<Player>().isDoneDragging)
        {
            // GameOver GameObject set to true
            gameManager.gameOverUI.SetActive(true);
        }
    }
}