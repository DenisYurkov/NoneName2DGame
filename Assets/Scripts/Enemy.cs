using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private float timeBtwAttack;
    public float startBtwAttack;
    public int health;
    public GameObject bloodEffect;
    public int damage;
    public bool playerInSightRange;
    public bool playerInAttackRange;
    private Player player;
    private Animator anim;
    public float speed;
    public float distance;
    private bool movingRight = true;
    public Transform groundDetection;
    private Transform target;
    public float stoppingDistance;
    public LayerMask whatIsPlayer;

    public float sightRange;
    public float attackRange;


    private void Update()
    {
        playerInSightRange = Physics2D.OverlapCircle(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics2D.OverlapCircle(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();


        if (health <= 0) 
        {
            
            Destroy(gameObject);
        }
    }
    public void Patroling() 
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
    public void ChasePlayer() 
    {
        if (Vector2.Distance(transform.position, target.position) >  stoppingDistance) 
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    public void TakeDamage(int damage) 
    {
 
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        health -= damage;
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            if (timeBtwAttack <= 0)
            {
                anim.SetTrigger("Hit");
            }
            else 
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
    }
    public void OnEnemyAttack()
    {
        Instantiate(bloodEffect, player.transform.position, Quaternion.identity);
        player.health -= damage;
        timeBtwAttack = startBtwAttack;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}

