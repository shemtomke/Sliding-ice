using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsManager : MonoBehaviour
{
    public int currentLvl = 1;
    public string lastLevel;

    public GameObject[] levelObject;
    public Sprite[] levelsSprites;
    public Sprite lockedLevel;

    private void Start()
    {
        for (int i = 0; i < levelObject.Length; i++)
        {
            if (i != 0)
            {
                levelObject[i].GetComponent<Image>().sprite = lockedLevel;
                levelObject[i].GetComponent<Button>().interactable = false;
                continue;
            }
        }
    }
    private void Update()
    {
        for (int i = 0; i < levelObject.Length; i++)
        {
            if(currentLvl == i)
            {
                levelObject[i].GetComponent<Image>().sprite = levelsSprites[i];
                levelObject[i].GetComponent<Button>().interactable = true;
            }
        }
    }
    public void Level(int lvl)
    {
        SceneManager.LoadScene(lvl);
    }
    public void NextLevel()
    {
        if (SceneManager.GetActiveScene().name != lastLevel)
            currentLvl++;
    }
}