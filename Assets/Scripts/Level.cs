using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    LevelsManager lvlManager;

    private void Start()
    {
        lvlManager = FindObjectOfType<LevelsManager>();
    }
    private void Update()
    {
        int lvlIndex = Int32.Parse(this.name);
        Debug.Log(lvlIndex);
        if (lvlManager.currentLvl >= lvlIndex)
        {
            this.GetComponent<Image>().sprite = lvlManager.levelsSprites[lvlIndex-1];
            this.GetComponent<Button>().interactable = true;
        }
        else
        {
            this.GetComponent<Image>().sprite = lvlManager.lockedLevel;
            this.GetComponent<Button>().interactable = false;
        }
    }
}