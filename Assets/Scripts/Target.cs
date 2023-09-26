using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject victoryUI;

    public bool isWithinRange;
    public GameObject player;
    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        victoryUI.SetActive(false);
        gameOverUI.SetActive(false);
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
            victoryUI.SetActive(true);
        }
    }
    void GameOver()
    {
        if (player.GetComponent<Player>().isStop && player.GetComponent<Player>().isDoneDragging)
        {
            // GameOver GameObject set to true
            gameOverUI.SetActive(true);
        }
    }
}