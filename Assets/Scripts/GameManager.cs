using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Sprite mute, unmute;
    public Sprite vibrate, unVibrate;
    public AudioSource bgMusic;

    bool isMute;
    bool isVibrate;

    Player player;
    Target target;
    static GameManager instance;

    private void Awake()
    {
        // Check if an instance already exists
        if (instance == null)
        {
            // If not, set this instance as the singleton
            instance = this;

            // Mark this GameObject to persist across scene changes
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this duplicate
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        player = FindObjectOfType<Player>();
        target = FindObjectOfType<Target>();

        isMute = false;
        isVibrate = true;
    }
    private void Update()
    {
        bgMusic.mute = isMute ? true : false;
    }
    public void Sound(GameObject soundObj)
    {
        isMute = !isMute;

        soundObj.GetComponent<Image>().sprite = isMute ? mute : unmute;
    }
    public void Vibrate(GameObject vibrateObj) 
    {
        isVibrate = !isVibrate;

        vibrateObj.GetComponent<Image>().sprite = isVibrate ? vibrate : unVibrate;
    }
    public void Language()
    {

    }
}