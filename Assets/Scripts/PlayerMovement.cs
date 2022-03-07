using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int playerSpeed = 10;
    public int playerJumpPower = 1250;
    private float moveX;
    private float moveY;
    public bool isGrounded;
    public float distanceToBottomOffPlayer = 1.8f;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerRaycast();


       

        if (GetComponent<Rigidbody2D>().velocity.y < -5.0f)
        {
            isGrounded = false;
        }
        
    }

    void PlayerMove()
    {
        //CONTROLS
        
        moveX = Input.GetAxis("Horizontal");
        transform.Rotate(new Vector3(0, 0, -(Input.GetAxis("Horizontal") * 1000 * Time.deltaTime)));


        if (GetComponent<Rigidbody2D>().angularVelocity > 50)
        {
            GetComponent<Rigidbody2D>().angularVelocity = 50;
        }
        if (GetComponent<Rigidbody2D>().angularVelocity < -50)
        {
            GetComponent<Rigidbody2D>().angularVelocity = -50;
        }

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            Jump();
        }

        //PLAYER DIRECTION
        if (moveX < 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (moveX > 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = false;

        }
        //PHYSICS

        
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump()
    {
        //JUMPING CODE
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        isGrounded = false;
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "coin")
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
        
        }

        void PlayerRaycast()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        }
    }

