using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneInTime : MonoBehaviour
{
    [Header("Loading Scene Setting")]
    public string sceneName;
    public float timeForShowScene;

 
    // Update is called once per frame
    private void Update()
    {
        Invoke("ShowScene", timeForShowScene);
    }

    public void ShowScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
