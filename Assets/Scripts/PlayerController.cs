using UnityEngine;
using UnityEngine.UI;
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
 
    [Header("Scene Settings")]
    public string nameRestartScene;

    [Header("Player Hearts")]
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;


    // Private Settings.
    private Animator restartGameAnimation;
    private Animator camAnim;
    private float moveInput;
    private bool bodyRight = true;
    private Rigidbody2D rb;



    private void Start()
    {
        /*GetComponent<CursorVisible>().Cursors(false);*/
        playerAnimator = GetComponent<Animator>();
        camAnim = GameObject.Find("Cinematic Camera").GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        restartGameAnimation = GameObject.Find("Global Light 2D").GetComponent<Animator>();
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

        HeartsPlayerCheck();


    }

    private void HeartsPlayerCheck()
    {
        if (healthPlayer == 100)
        {
            hearts[2].sprite = emptyHeart;
        }

        if (healthPlayer == 80)
        {
            Destroy(GameObject.Find("heart (3)"));
        }

        if (healthPlayer == 60)
        {
            hearts[1].sprite = emptyHeart;
        }

        if (healthPlayer == 40)
        {
            Destroy(GameObject.Find("heart (2)"));
        }

        if (healthPlayer == 20)
        {
            hearts[0].sprite = emptyHeart;
        }

        if (healthPlayer == 0)
        {
            Destroy(GameObject.Find("heart (1)"));
        }
    }
    private void DieCharacter()
    {
        if (healthPlayer <= 0)
        {
            playerAnimator.SetInteger("State", 6);
            restartGameAnimation.SetTrigger("Is_Die");
            Invoke("GameRestart", 2f);
        }

    }
    private void RunAndWalkSpeed()
    {
        // Walk.
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
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
            camAnim.SetTrigger("cameraAnimation");


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


