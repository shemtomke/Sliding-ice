using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour
{
    public float loadingTime;
    public GameObject menuUI, loadUI;
    private void Start()
    {
        StartCoroutine(Load());
    }
    IEnumerator Load()
    {
        yield return new WaitForSeconds(loadingTime);

        menuUI.SetActive(true);
        loadUI.SetActive(false);
    }
}