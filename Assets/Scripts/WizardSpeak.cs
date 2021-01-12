using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardSpeak : MonoBehaviour
{
    [Header("GameObject Wizard")]
    public GameObject playerGhost;

    [Header("UI")]
    public GameObject wizardText;
    public GameObject wizardSay;

    [Header("GhostPlayer Animator")]
    public Animator ghostPlayerAnimator;
 
    private void Start()
    {
        ghostPlayerAnimator = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            wizardText.SetActive(true);
            Invoke("DisableWizardText", 1f);
            if (Input.GetKeyDown(KeyCode.F))
            {
                Destroy(wizardText);
                wizardSay.SetActive(true);
                Invoke("GhostPlayerAnimation", 4f);
                Invoke("DisableWizardSay", 6f);
                Destroy(wizardSay, 7f);
                Destroy(playerGhost, 8f);
            }
        }
    }

    private void DisableWizardText()
    {
        wizardText.SetActive(false);
    }
    private void DisableWizardSay()
    {
        wizardSay.SetActive(false);
    }

    private void GhostPlayerAnimation()
    {
        ghostPlayerAnimator.SetTrigger("PlayerGhostHide");
    }
}
