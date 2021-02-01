using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueSystem : MonoBehaviour
{
    [Header("GameObject Person")]
    public GameObject person;

    [Header("UI")]
    public GameObject textButton;
    public GameObject personSay;

    [Header("Person Animator")]
    public Animator personAnimator;
    public string triggerName;

    [Header("Time To Hide")]
    public float invokeTextButton = 1f;
    public float invokePersonAnimation = 8f;
    public float invokePersonSay = 8f;
    public float destroyPersonSay = 9f;
    public float destroyPerson = 13f;

    [Header("Scene Manager")]
    public bool haveScene = false;
    public string sceneName;
    public float timeForLoadningScene;


    private void Start()
    {
        personAnimator = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            textButton.SetActive(true);
            Invoke("TextButton", invokeTextButton);
            if (Input.GetKey(KeyCode.F))
            {
                Destroy(textButton);
                personSay.SetActive(true);

                Invoke("PersonSay", invokePersonSay);
                Invoke("PersonAnimation", invokePersonAnimation);
                
                Destroy(personSay, destroyPersonSay);
                Destroy(person, destroyPerson);
                if (haveScene == true)
                {
                    Invoke("LoadingScene", timeForLoadningScene);
                }
            }
        }
    }

    private void TextButton()
    {
        textButton.SetActive(false);
    }

    private void PersonAnimation()
    {
        personAnimator.SetTrigger(triggerName);
    }

    private void PersonSay()
    {
        personSay.SetActive(false);
    }

    private void LoadingScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
