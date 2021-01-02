using System.Collections;
using System.Collections.Generic;
using System.Security;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    public float walkSpeed;
    public float jumpForce;
    public float checkRadius;
    public float runSpeed;

    [Header("Player Position")]
    public Transform feetPos;
    public LayerMask whatIsGround;

    [Header("Player Animator")]
    public Animator playerAnimator;

    // Private Settings.
    private float moveInput;
    private const float DOUBLE_CLICK = .2f;
    private float lastClickTime;
    private bool bodyRight = true;
    private bool isGrounded;
    private Rigidbody2D rb;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {   
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        Jump();
        WeakAndStrongHit();
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

    public void Jump()
    {
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        // Animation Jump.
        if (isGrounded == true)
        {
            playerAnimator.SetBool("Is_Jumping", false);
        }
        else
        {
            playerAnimator.SetBool("Is_Jumping", true);
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

    public void WeakAndStrongHit()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerAnimator.SetTrigger("Weak_Hit");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            playerAnimator.SetTrigger("Strong_Hit");
        }
    }
    public void Flip()
    {
        bodyRight = !bodyRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
