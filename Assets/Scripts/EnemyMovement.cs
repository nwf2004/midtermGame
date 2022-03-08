using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public float swapFrequency;
    public int EnemySpeed;
    public int XMoveDirection;

    void Start()
    {
        //Starts a recursive IEnumerator
        StartCoroutine(switchDirectionRecursive());
    }

    // Update is called once per frame
    void Update()
    {
        //Moves the enemy in the direction of XMoveDirection by the set speed, speed can be set per enemy
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
    }

    IEnumerator switchDirectionRecursive()
    {
        //After an amount of seconds have passed, switch move directions
        yield return new WaitForSeconds(swapFrequency);
        Flip();
        StartCoroutine(switchDirectionRecursive());
    }

    //This code switches the current movement direction
    void Flip()
    {
        if (XMoveDirection > 0)
        {
            XMoveDirection = -1;
        }
        else { XMoveDirection = 1; }
    }



}

