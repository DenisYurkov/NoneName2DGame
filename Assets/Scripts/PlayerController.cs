using System.Collections;
using System.Collections.Generic;
using System.Security;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    public float speed;
    public float jumpForce;
    public float checkRadius;
    
    [Header("Player Position")]
    public Transform feetPos;
    public LayerMask whatIsGround;

    [Header("Player Animator")]
    public Animator playerAnimator;

    // Private Settings.
    private float moveInput;
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
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        RunAndWalk();
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // Flip Logic!
        if (bodyRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (bodyRight == true && moveInput < 0)
        {
            Flip();
        }

        if (moveInput == 0)
        {
            playerAnimator.SetBool("isRunning", false);
        }
        else
        {
            playerAnimator.SetBool("isRunning", true);
        }
    }

    public void Jump()
    {
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        // Animation.
        if (isGrounded == true)
        {
            playerAnimator.SetBool("isJumping", false);
        }
        else
        {
            playerAnimator.SetBool("isJumping", true);
        }
    }

    public void RunAndWalk()
    {
        // Run.
        if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            speed = 10f;
        }
        // Walk.
        else if (!Input.GetKeyDown(KeyCode.LeftShift) && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)))
        {
            speed = 4f;
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
