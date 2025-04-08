using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public int facingDirection = 1;

    public Rigidbody2D rb;
    public Animator anim;

    //start called before first frame
    void Start()
    {
        //get the rigidbody component
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    //update called 50x per frame
    void FixedUpdate()
    {
        //get the horizontal input
        float horizontal = Input.GetAxis("Horizontal");
        //get the vertical input
        float vertical = Input.GetAxis("Vertical");

        if(horizontal > 0 && transform.localScale.x < 0 || horizontal < 0 && transform.localScale.x > 0)

        anim.SetFloat("horizontal", Mathf.Abs(horizontal));
        anim.SetFloat("vertical", Mathf.Abs(vertical));

        //move the player
        rb.linearVelocity = new Vector2(horizontal * speed, vertical * speed);
          // Flip the character if moving left/right
        if (horizontal > 0 && facingDirection < 0 || horizontal < 0 && facingDirection > 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        //flip the player
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        
    }
}
