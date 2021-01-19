using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LetterText : MonoBehaviour
{
    public GameObject letterText;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) {
            switch (this.gameObject.tag) {
                case "Follow":
                    letterText.GetComponent<TextMeshProUGUI>().text = "Follow the ghost.";
                    break;
                case "Where":
                    letterText.GetComponent<TextMeshProUGUI>().text = "I need to find his.";
                    break;
            }
        }

    }
}
