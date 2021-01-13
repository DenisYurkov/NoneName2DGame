using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float healthEnemy;
    public Animator animatorEnemy;
    public float damageEnemy;

    // Start is called before the first frame update
    void Start()
    {
        animatorEnemy = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (healthEnemy <= 0)
        {
            // animatorEnemy.SetTrigger("EnemyDie");
            Destroy(gameObject);
        }
    }

    public void TakeDamagePlayer(int damagePlayer)
    {
        healthEnemy -= damagePlayer;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animatorEnemy.SetTrigger("ZombiAttack");
            collision.GetComponent<PlayerController>().playerAnimator.SetInteger("State", 5);
            collision.GetComponent<PlayerController>().healthPlayer -= damageEnemy;
        }
    }


}
