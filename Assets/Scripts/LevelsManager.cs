using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsManager : MonoBehaviour
{
    public int currentLvl = 1;
    public string lastLevel;
    string saveLevel = "LEVEL";

    public Sprite[] levelsSprites;
    public Sprite lockedLevel;

    private void Start()
    {
        currentLvl = PlayerPrefs.GetInt(saveLevel, 1);
    }
    public void Level(int lvl)
    {
        SceneManager.LoadScene(lvl);
    }
    public void NextLevel()
    {
        if (SceneManager.GetActiveScene().name != lastLevel)
            currentLvl++;

        PlayerPrefs.SetInt(saveLevel, currentLvl);
    }
    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}