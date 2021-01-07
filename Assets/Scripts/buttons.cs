using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour
{
    [Header("UI")]
    public GameObject letter, BgMenu, AUSWin, BgSet, Menu;
    private bool music = true;
    private float music_scale, sound_scale;
    public Slider sliderMusic, sliderSound;
    public Sprite music_on, music_off; 
    public Sprite Sound_on, Sound_off;
    [Header("aanimator")]
    Animator curtain_animator;

    void Start()
    {
        curtain_animator = GameObject.Find("zanaves").GetComponent<Animator>();
    }
    void Escape() {
      
        if (letter.activeSelf == false)
        {
            Debug.Log("qqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqq");
            if (BgSet.activeSelf == true)   //condition if settings in menu is showed;
            {
  
                Time.timeScale = 1;
                BgSet.SetActive(false);
                BgMenu.SetActive(true);
                Menu.SetActive(false);
            }
            else
            {
                if (Menu.activeSelf == false)          //condition if menu is not showed;
                {

                    Time.timeScale = 0;
                    Cursor.lockState = CursorLockMode.Confined;
                    Debug.Log("hthrthrthrhr");
                    Menu.SetActive(true);
                
                }
                else                                       //condition if menu is showed;
                {
        
                    Time.timeScale = 1;                             
                    Cursor.lockState = CursorLockMode.Locked;

                    Menu.SetActive(false);
                           
                }
            } 

        }
        else letter.SetActive(false); //if letter is showed, close exactly letter;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //show or close menu, letter, puzzles
           
        {
            if (AUSWin.activeSelf == false)
            {
               
                curtain_animator.SetTrigger("ismenu");
                

            }
        }


       if (BgSet.activeSelf == true) {     //settings of game
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
    public void OnMouseUpAsButton() {  //button action
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
            case "BackToMM":                    //back to main menu
                BgMenu.SetActive(false);
                AUSWin.SetActive(true);
                break;
            case "Return":
                curtain_animator.SetTrigger("ismenu");
                
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
            case "Music":                       //music button and slider 
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
            case "Sound":                       //volume button and slider 
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
