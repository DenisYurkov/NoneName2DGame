using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Puzzles : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pressF;
    public GameObject letter;
    private bool check = false;

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "Player"){
            if (check == true) { 
            if (Input.GetKeyDown(KeyCode.F)) {
                
                letter.SetActive(true);
            }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            check = true;
            pressF.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            check = false;
            pressF.SetActive(false);
           
        }
    }
}
