using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzles : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pressF;
    public GameObject letter;
    public GameObject activePanel;
    public GameObject panelWithLevers;
    public GameObject door;
    public Sprite leverActive;
    public Sprite leverDeactive;
    public Sprite doorOpen;
    public bool[] leversBool = new bool[4];
    public GameObject[] levers = new GameObject[4];
    public int i;
    // Update is called once per frame

    private void Start()
    {
        door = GameObject.Find("Door");
    }
    void ChangeTheSprite() {
        if (this.GetComponent<Image>().sprite == leverActive)
        {
            this.GetComponent<Image>().sprite = leverDeactive;
        }
        else
        {
            this.GetComponent<Image>().sprite = leverActive;
            TrueOrFalse();
        }
    }
    void TrueOrFalse() {
        Debug.Log(i);

        if ((levers[i].GetComponent<Image>().sprite == leverActive) && (levers[i - 1].GetComponent<Image>().sprite == leverActive))
        {
            if (levers[4].GetComponent<Image>().sprite == leverActive)
            {
                panelWithLevers.GetComponent<BoxCollider2D>().enabled = false;
                activePanel.SetActive(false);
     
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                door.GetComponent<SpriteRenderer>().sprite = doorOpen;
                door.GetComponent<BoxCollider2D>().enabled = false;
            }
          

        }
        else
        {
            for (i = 0; i < 5; i++)
            {
                levers[i].GetComponent<Image>().sprite = leverDeactive;

            }
        }
    }
    public void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "lever":
                i = 0;
                ChangeTheSprite();
                break;
            case "lever1":
                i = 1;
                ChangeTheSprite();
                break;
            case "lever2":
                i = 2;
                ChangeTheSprite();
                break;
            case "lever3":
                i = 3;
                ChangeTheSprite();
                break;
            case "lever4":
                i = 4;
                ChangeTheSprite();
                break;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (gameObject.name)
        {
            case "letter on land":
                if (collision.gameObject.tag == "Player")
                {

                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        GameObject.Find("F").SetActive(false);
                        letter.SetActive(true);
                        Time.timeScale = 0;
                        Cursor.lockState = CursorLockMode.Confined;

                    }
                }
                break;
            case "panel with levers":
                if (collision.gameObject.tag == "Player")
                {

                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        GameObject.Find("F").SetActive(false);
                        activePanel.SetActive(true);
                        Time.timeScale = 0;
                        Cursor.lockState = CursorLockMode.Confined;

                    }
                }
                break;
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pressF.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pressF.SetActive(false);
           
        }
    }
}
