using System.Collections;
using System.Collections.Generic;
using System.Security;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    public Transform attackPos;
    public LayerMask WhatIsEnemies;

    public float healthPlayer;
    public int damagePlayer;
    public int damageEnemy;

    public float walkSpeed;
    public float runSpeed;
    public float startTimeBtwAttack;
    public float attackRange;

    [Header("Player Animator")]
    public Animator playerAnimator;
    // public Animator camAnim;

    // Private Settings.
    private float timeBtwAttack;
    private float moveInput;
    private bool bodyRight = true;
    private Rigidbody2D rb;


    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
       /* camAnim = GetComponent<Animator>();*/
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {   
        OnAttack();
        DieCharacter();
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * walkSpeed, rb.velocity.y);
        RunAndWalkSpeed();

        // Flip Logic!
        if (bodyRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (bodyRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    public void DieCharacter()
    {
        if (healthPlayer <= 0)
        {
            playerAnimator.SetTrigger("PlayerDie");
        }
    }
    public void RunAndWalkSpeed()
    {
        // Walk.
        if (!Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            walkSpeed = 4f;
            playerAnimator.SetTrigger("Is_Walk");
            RoleCharacter();
        }

        // Run.
        if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            walkSpeed = runSpeed;
            playerAnimator.SetTrigger("Is_Running");
        }
    }

    public void RoleCharacter()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            playerAnimator.SetBool("Is_Role", true);

        }
        if (!Input.GetKeyDown(KeyCode.LeftAlt))
        {
            playerAnimator.SetBool("Is_Role", false);
        }
    }
    public void Flip()
    {
        bodyRight = !bodyRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    public void OnAttack()
    {
        if (timeBtwAttack <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerAnimator.SetTrigger("Attack");
               // camAnim.SetTrigger("cameraAnimation");

                Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, WhatIsEnemies);
                for (int i = 0; i < enemies.Length; i++)
                {
                    enemies[i].GetComponent<Enemy>().TakeDamagePlayer(damagePlayer);
                }
            }
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            playerAnimator.SetTrigger("PlayerHit");
            healthPlayer -= damageEnemy;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}


