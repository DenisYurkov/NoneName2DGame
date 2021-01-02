using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour
{
    [Header("UI")]
    public GameObject BgSet;
    public GameObject DarkBg;
    public GameObject BgMenu, AUSWin;

    private bool music = true;
    private float music_scale, sound_scale;
    public Slider sliderMusic, sliderSound;
    public Sprite music_on, music_off; 
    public Sprite Sound_on, Sound_off;
    public GameObject letter;


    private void Start()
    {

    }
    void Escape() {
        if (letter.activeSelf == false)
        {
          
            if (BgSet.activeSelf == true)
            {
                Time.timeScale = 1;
                BgSet.SetActive(false);
                BgMenu.SetActive(true);
                DarkBg.SetActive(false);
            }
            else
            {
                if (DarkBg.activeSelf == false)
                {

                    Time.timeScale = 0;
                    Cursor.lockState = CursorLockMode.Confined;

                    DarkBg.SetActive(true);
                
                }
                else
                {

                    Time.timeScale = 1;
                    Cursor.lockState = CursorLockMode.Locked;

                    DarkBg.SetActive(false);
                           
                }
            } 

        }
        else letter.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
           
        {
            if (AUSWin.activeSelf == false)
                Debug.Log("rgregregerhehr");
            Escape();
            
        }


       if (BgSet.activeSelf == true) { 
        GameObject.Find("Main Camera").GetComponent<AudioSource>().volume = sliderMusic.value;
        GameObject.Find("UI").GetComponent<AudioSource>().volume = sliderSound.value;
        if (sliderMusic.value == 0)
        {
            GameObject.Find("Music").GetComponent<Image>().sprite = music_off;
        }
        else
        {

            GameObject.Find("Music").GetComponent<Image>().sprite = music_on;

        }
            if (sliderSound.value == 0)
            {
                GameObject.Find("Sound").GetComponent<Image>().sprite = Sound_off;
            }
            else
            {

                GameObject.Find("Sound").GetComponent<Image>().sprite = Sound_on;

            }

        }

    }
    public void OnMouseUpAsButton() {
         switch (gameObject.name)
         {
            case "Try Again":
                SceneManager.LoadScene(1);
                Time.timeScale = 1;
                break;
            case "Main menu":
                SceneManager.LoadScene(0);
                Time.timeScale = 1;
                break;
            case "New game":
                SceneManager.LoadScene(1);
                Time.timeScale = 1;
                break;
            case "No":
                BgMenu.SetActive(true);
                AUSWin.SetActive(false);
                break;
            case "Yes":
                SceneManager.LoadScene(0);
                break;
            case "BackToMM":
                BgMenu.SetActive(false);
                AUSWin.SetActive(true);
                break;
            case "Return":
                Escape();
                break;
            case "Back":
                BgMenu.SetActive(true);
                BgSet.SetActive(false);
                break;
             case "Settings":
                BgMenu.SetActive(false);
                BgSet.SetActive(true);
                 break;
             case "Quit":
                Application.Quit();
                break;
            case "Music":
                if (music == true)
                {
                    GameObject.Find("Music").GetComponent<Image>().sprite = music_off;
                    music_scale = sliderMusic.value;
                    Debug.Log(music_scale);
                    sliderMusic.value = 0;
                    music = false;
                }
                else if (music == false)
                {
                    GameObject.Find("Music").GetComponent<Image>().sprite = music_on;
                    sliderMusic.value = music_scale;
                    music = true;
                }
                break;
            case "Sound":
                if (music == true)
                {
                    GameObject.Find("Sound").GetComponent<Image>().sprite = Sound_off;
                    sound_scale = sliderMusic.value;
                    Debug.Log(music_scale);
                    sliderSound.value = 0;
                    music = false;
                }
                else if (music == false)
                {
                    GameObject.Find("Sound").GetComponent<Image>().sprite = Sound_on;
                    sliderSound.value = sound_scale;
                    music = true;
                }
                break;
        }

    }

    
}
