using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpAmount = 5f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //rb.AddForce(transform.forward * 5);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 forceVector = new Vector3(moveHorizontal, 0.0f, 0);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.AddForce(forceVector * speed * 2);
        }
        else
        {
            rb.AddForce(forceVector * speed);
        }
        /*
        if (!LevelManager.isGameOver)
        {

        }
        else
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        */

    }

}
