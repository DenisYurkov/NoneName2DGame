using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Squirrel : MonoBehaviour
{
    public GameObject pressF;
    public Animator countAnimator;
    public GameObject[] acorns;
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {       
       if (collision.gameObject.tag == "Player")
        {

            if (Input.GetKeyDown(KeyCode.F))
            {
                switch (this.gameObject.tag)
                {
                    case "Acorn":
                        Destroy(this.gameObject);
                        Debug.Log("regergegergerge");
                        GameObject.Find("Count").GetComponent<Counter>(). count += 1;  
                        break;
                    case "Squirrel":
                        if (GameObject.Find("Count").GetComponent<Counter>().count == 0)
                        {

                            countAnimator.SetTrigger("isTrue");
                            this.GetComponent<BoxCollider2D>().enabled = false;
                            acorns = GameObject.FindGameObjectsWithTag("Acorn");
                            for (int i = 0; i < acorns.Length; i++)
                            {
                                acorns[i].GetComponent<BoxCollider2D>().enabled = true;
                            }
                        }
                        else {
                            countAnimator.SetTrigger("isTrue");
                            Destroy(GameObject.Find("Squirrel"));
                        }
                        break;
                }
                        
            }
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

