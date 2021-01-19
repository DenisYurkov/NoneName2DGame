using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    public Transform attackPos;
    public LayerMask WhatIsEnemies;

    public float healthPlayer;
    public int damagePlayer;

    public float walkSpeed;
    public float runSpeed;
    public float attackRange;

    [Header("Player Animator")]
    public Animator playerAnimator;
    // public Animator camAnim;

    [Header("Scene Settings")]
    public string nameRestartScene;
    
    // Private Settings.
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
        playerAnimator.SetInteger("State", 0);
        rb.velocity = new Vector2(moveInput * walkSpeed, rb.velocity.y);
        RunAndWalkSpeed();
        RoleCharacter();

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

    private void DieCharacter()
    {
        if (healthPlayer <= 0)
        {
            playerAnimator.SetInteger("State", 6);
        }

    }
    private void RunAndWalkSpeed()
    {
        // Walk.
        if (!Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            playerAnimator.SetInteger("State", 1);
        }

        // Run.
        if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            walkSpeed = runSpeed;
            playerAnimator.SetInteger("State", 2);
        }

    }

    private void RoleCharacter()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            playerAnimator.SetInteger("State", 3);
        }
    }
    private void Flip()
    {
        bodyRight = !bodyRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void OnAttack()
    {
   
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnimator.SetInteger("State", 4);
            // camAnim.SetTrigger("cameraAnimation");
            

            Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, WhatIsEnemies);
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<Enemy>().animatorEnemy.SetTrigger("ZombiHit");
                enemies[i].GetComponent<Enemy>().TakeDamagePlayer(damagePlayer);

            }
        }
    }

    private void GameRestart()
    {

        SceneManager.LoadScene(nameRestartScene);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}


