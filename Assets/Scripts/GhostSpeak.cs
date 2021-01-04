using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpeak : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ghostText;
    public GameObject ghostSay;
    public GameObject ghost;
    public Animator ghostAnimator;


    public void Start()
    {
        ghostAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
        HideGhostText();
        if (collision.gameObject.tag == "Player")
        {
            ghostText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                ghostSay.SetActive(true);
                ghostAnimator.SetTrigger("GhostHide");
                HideGhostSay();
            }

        }
    }

    private void GhostDestroy()
    {
        Destroy(ghost, 5f);
    }

    private void HideGhostText()
    {
        Destroy(ghost, 2f);
    }

    private void HideGhostSay()
    {
        Destroy(ghost, 4f);
    }

}
