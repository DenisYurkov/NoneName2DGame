using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManeMenu : MonoBehaviour
{



    public void LoadStart()
    {
        Debug.Log("Start");
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadOptions()
    {
        Debug.Log("Options");
        SceneManager.LoadScene("Options");
    }
}