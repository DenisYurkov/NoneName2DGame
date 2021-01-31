using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Squirrel : MonoBehaviour
{
    public GameObject pressF;
    public Animator countAnimator;
    public Animator squirrelAnimator;

    private GameObject[] acorns;
    public GameObject squirrelSay;
    public GameObject thankYouForHelp;

    // Start is called before the first frame update

    private void Start()
    {
        squirrelAnimator = GetComponent<Animator>();
    }

    private void HideAnimationSquirrel()
    {
        squirrelAnimator.SetTrigger("Is_Hide");
    }

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
                        GameObject.Find("Count").GetComponent<Counter>(). count += 1;  
                        break;
                    case "Squirrel":
                        if (GameObject.Find("Count").GetComponent<Counter>().count == 0)
                        {
                            countAnimator.SetTrigger("isTrue");
              
                            acorns = GameObject.FindGameObjectsWithTag("Acorn");
                            for (int i = 0; i < acorns.Length; i++)
                            {
                                acorns[i].GetComponent<BoxCollider2D>().enabled = true;
                            }
                        }
                        else {
                            countAnimator.SetTrigger("isTrue");
                        }
                        break;
                }
                pressF.SetActive(false);
                squirrelSay.SetActive(true);
                Destroy(squirrelSay, 9f);
            }
        }    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pressF.SetActive(true);
        }

        if (collision.gameObject.tag == "Player" && GameObject.Find("Count").GetComponent<Counter>().count == 3)
        {
            pressF.SetActive(false);
            Destroy(GameObject.Find("Count"), 3f);
            thankYouForHelp.SetActive(true);
            Invoke("HideAnimationSquirrel", 8f);
            Destroy(thankYouForHelp, 9f);
            Destroy(GameObject.Find("Squirrel"), 13f);
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

