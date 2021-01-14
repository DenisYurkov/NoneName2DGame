using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    [Header("Life and Damage Enemy")]
    public float healthEnemy;
    public float damageEnemy;
    
    [Header("Animator and AI Enemy")]
    public Animator animatorEnemy;
    public AIPath enemyAI;

    [Header("Transform Settings Enemy")]
    public float valueEnemyChangeYTransformToDie;
    public Transform enemyTransform;


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
            animatorEnemy.SetTrigger("ZombiDie");
            Destroy(enemyAI);
            enemyTransform.position = new Vector2(enemyTransform.position.x, valueEnemyChangeYTransformToDie);
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
