using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Language : MonoBehaviour
{
    public string eng;
    public string port;
    public string rus;

    GameManager manager;

    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        if(manager.currentLanguage == Lang.eng)
        {
            this.GetComponent<Text>().text = eng;
        }
        else if(manager.currentLanguage == Lang.port) 
        {
            this.GetComponent<Text>().text = port;
        }
        else if( manager.currentLanguage == Lang.rus)
        {
            this.GetComponent<Text>().text = rus;
        }
    }
}
