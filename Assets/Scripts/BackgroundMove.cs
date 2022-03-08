using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This code handles the background animation
public class BackgroundMove : MonoBehaviour
{
    public float maxTime = 3f;
    protected Vector3 Pos1;
    protected Vector3 Pos2;
    public GameObject toLerp;
    public float curTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //Pos is set to current position
        Pos1 = transform.position;

        //Position 2 is set x y that corrisponds to the size of one of the background tiles
        Pos2 = new Vector3(transform.position.x - 504, transform.position.y - 340, 290);

        //Starts a loop that will reset position
        StartCoroutine(RecursiveMove());

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    //Moves the background tiles to -504, -340 in (maxTime) seconds, curTime will be set in the IEnumerator
    public void Move()
    {
        curTime = Mathf.Clamp(curTime + Time.deltaTime, 0f, maxTime);

        toLerp.transform.position = Vector3.Lerp(Pos1, Pos2, curTime / maxTime);
    }

    //Reset position back to the start when this is called and wait (maxTime)
    IEnumerator RecursiveMove()
    {
        curTime = 0.0f;
        yield return new WaitForSeconds(maxTime);
        StartCoroutine(RecursiveMove());
    }
}

