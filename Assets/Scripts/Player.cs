using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float health;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public float heal;
    public GameObject panel;
    void Start()
    {
        
    }
    private void FixedUpdate() 
    {
        if (health > numOfHearts) 
        {
            health = numOfHearts;
        }
        health += Time.deltaTime * heal;
        for (int i = 0; i < hearts.Length; i++) 
        {
            if (i < Mathf.RoundToInt(health))
            {
                hearts[i].sprite = fullHeart;
            }
            else 
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else 
            {
                hearts[i].enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            panel.SetActive(true);
            Destroy(gameObject);
        }
    }
}
