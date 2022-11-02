using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject text;
    public GameObject appear;
    public void button()
    {
        text.SetActive(false);
        appear.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Kitchen");
    }

    public void EndGame()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
