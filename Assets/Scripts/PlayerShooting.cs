using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public bool gunCooldown = false;
    public float shootSpeed;
    public GameObject bullet;
    GameObject newShot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        turning();
        if (Input.GetKey(KeyCode.F) && gunCooldown == false)
        {

            newShot = Instantiate(bullet);


            newShot.transform.position = transform.position + (transform.right * 2);
            newShot.transform.rotation = transform.rotation;
            Vector2 shootVector = (transform.right * shootSpeed);

            newShot.GetComponent<Rigidbody2D>().velocity = GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity + shootVector;

            StartCoroutine(gunCoolDown());
        }
    }

    void turning()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        transform.right = direction; 

    }

    IEnumerator gunCoolDown()
    {


        gunCooldown = true;
        yield return new WaitForSeconds(.1f);
        gunCooldown = false;


    }
}
