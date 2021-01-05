using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpeak : MonoBehaviour
{
    [Header("GameObject Ghost")]
    public GameObject ghost;

    [Header("UI")]
    public GameObject ghostText;
    public GameObject ghostSay;

    [Header("Ghost Animator")]
    public Animator ghostAnimator;


    private void Start()
    {
        ghostAnimator = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ghostText.SetActive(true);
            Invoke("DisableGhostText", 1f);
            if (Input.GetKeyDown(KeyCode.F))
            {
                Destroy(ghostText);
                ghostSay.SetActive(true);
                Invoke("GhostAnimation", 3f);
                Destroy(ghostSay, 2f);
                Destroy(ghost, 4f);
            }
        }
    }

    private void DisableGhostText()
    {
        ghostText.SetActive(false);
    }

    private void GhostAnimation()
    {
        ghostAnimator.SetTrigger("GhostHide");
    }
}
