using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField]/// mengizinkan private bisa diakses diinspector
    private Rigidbody2D rb;

    [SerializeField]
    private float speed = 12;

    private float hz;

    bool facingRight = true;

    private bool isGrounded = true;

    [SerializeField]
    private float jump = 8;

    [SerializeField]
    private int jumpCount;

    [SerializeField]
    private int jumpValue = 1;





    void Update()
    {
        move();
        if(Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
        {
            Jump();
        }
        if (isGrounded)
        {
            jumpCount = jumpValue;
        }
    }
    private void FixedUpdate()
    {
        setMove();
        setFlip();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isGrounded)
        {
            isGrounded = true;
        }
    }
    public void move()
    {
        hz = Input.GetAxisRaw("Horizontal");
    }
    public void setMove()
    {
        rb.velocity = new Vector2(hz * speed, rb.velocity.y);
    }

    public void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f,180f,0f);
    }
    public void setFlip()
    {
        if (hz < 0 && facingRight)
        {
            ; flip();
        }
        else if (hz > 0 && !facingRight)
        {
            flip();
        }
    }
    private void Jump()
    {
        rb.velocity = Vector2.up * jump;
        isGrounded = false;
        jumpCount--;
    }
}
