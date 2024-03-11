using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerPlayer : MonoBehaviour
{
    //toc do
    public float moveSpeed = 10f;
    //luc nhay
    public float jumpForce = 20f;
    //input tu ban phim
    private float i_move;
    private Rigidbody2D rb;
    //bien kiem tra 
    private bool isGrounded;
    public Transform _isGrounded;
    public LayerMask land;
    // Số lần nhảy 2
    private bool DoubleJump;
    //quay nguoi
    private bool isturn = true;
    //animation
    public Animator animator;
    public AudioClip jumpSound; // âm thanh nhảy
    private AudioSource audioSource;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        move();
    }
    void move()
    {
        isGrounded = Physics2D.OverlapCircle(_isGrounded.position, 0.2f,land);
       
        // Di chuyển
        i_move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2 (i_move * moveSpeed, rb.velocity.y);
        animator.SetFloat("move",Mathf.Abs(i_move));

        if(isturn == true && i_move < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            isturn = false;
        }

        if(isturn == false && i_move > 0){
            transform.localScale = new Vector3(1, 1, 1);
            isturn = true;
        }

        // Nhảy 
        if(isGrounded && !Input.GetKey(KeyCode.Space))
        {
            DoubleJump = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded || DoubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                DoubleJump = !DoubleJump;
                animator.SetTrigger(DoubleJump ? "doublejump" : "jump");
                if (jumpSound != null)
                {
                    audioSource.PlayOneShot(jumpSound);
                }
            }
        }

    }
}
