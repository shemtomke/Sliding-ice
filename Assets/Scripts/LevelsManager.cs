using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsManager : MonoBehaviour
{
    public GameObject[] levelObject;
    public Sprite lockedLevel;

    private void Start()
    {
        for (int i = 0; i < levelObject.Length; i++)
        {
            if (i != 0)
            {
                levelObject[i].GetComponent<Image>().sprite = lockedLevel;
                continue;
            }
        }
    }
}
