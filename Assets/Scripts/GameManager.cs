using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("GameOver")]


    [Header("Victory")]


    [Header("Main Menu")]


    [Header("Levels")]


    Player player;
    Target target;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        target = FindObjectOfType<Target>();
    }
    private void Update()
    {
        GameStatus();
    }
    void GameStatus()
    {
        if(target.isWithinRange)
        {
            Debug.Log("Win!");
        }
        else
        {
            Debug.Log("Loose!");
        }
    }
}
