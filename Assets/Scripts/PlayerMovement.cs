using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public int playerSpeed = 10;
    public int playerJumpPower;
    private float moveX;
    public bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        PlayerMove();


       
        //if the player is falling set grounded to false
        if (GetComponent<Rigidbody2D>().velocity.y < -5.0f)
        {
            isGrounded = false;
        }
        
    }

    void PlayerMove()
    {
        //CONTROLS

        //Gets unity built in Axis, Axis comes with Controller, WASD, and Arrow key movement support
        moveX = Input.GetAxis("Horizontal");

        //This spins the square in the direction of movement
        transform.Rotate(new Vector3(0, 0, -(Input.GetAxis("Horizontal") * 1000 * Time.deltaTime)));


        //All this here caps the amount the player can spin so it doesn't freak out
        if (GetComponent<Rigidbody2D>().angularVelocity > 50)
        {
            GetComponent<Rigidbody2D>().angularVelocity = 50;
        }
        if (GetComponent<Rigidbody2D>().angularVelocity < -50)
        {
            GetComponent<Rigidbody2D>().angularVelocity = -50;
        }

        //"Jump" is spacebar
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            Jump();
        }

        //PHYSICS, Constantly update the left right movements with move speed and the current moveX
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump()
    {
        //Jump code adds force upwards when jumping and sets grounded to false
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        isGrounded = false;
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        //Touching the floor
        if (col.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
        //PLayer hits an enemy and resets the scene
        if (col.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("SampleScene");

        }

    }


    void OnTriggerEnter2D(Collider2D col)
    {
        //If the player falls into the pit it also resets the scene
        if (col.gameObject.tag == "killzone")
        {
            SceneManager.LoadScene("SampleScene");
        }

    }
}

