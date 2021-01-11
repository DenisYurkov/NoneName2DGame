using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float healthEnemy;
    public Animator animatorEnemy;

    // Start is called before the first frame update
    void Start()
    {
        animatorEnemy = GetComponent<Animator>();
        animatorEnemy.SetBool("isRunning", true);

    }

    // Update is called once per frame
    void Update()
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
            //TakeDamageEnemy(damageEnemy);
            //GetComponent<PlayerController>().hitCharacter();
            animatorEnemy.SetTrigger("ZombiHit");
            animatorEnemy.SetTrigger("ZombiAttack");
        }
    }


}
