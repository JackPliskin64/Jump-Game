using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Vector2 input;
    public float velocidad;
    public bool isGrounded;
    public float jumpForce;
    public Rigidbody2D rb;
    public Animator animator;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        input.x = Input.GetAxis("Horizontal");
        Move();
        SetAnimations();
        GameOver();
        Jump();
        

        if (input.x == 0)
        {
            animator.SetBool("isMoving", false);
        }
    }

    public void SetAnimations()
    {
            animator.SetFloat("moveX", input.x);

    }
    public void GameOver()
    {
        if(transform.position.y <= -5)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            SceneManager.LoadScene("YouWin");
        }
    }

    public void Move()
    {
                animator.SetBool("isMoving", true);
                transform.Translate(input * velocidad * Time.deltaTime); 
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            if (isGrounded)
            {
                isGrounded = false;
            }
            
        }  
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (!isGrounded)
            {
                isGrounded = true;
            }
        }
    }
}
