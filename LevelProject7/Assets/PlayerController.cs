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
        GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.grey, Mathf.PingPong(Time.time, 1));
    }

    private void FixedUpdate()
    {
        
        if (!LevelManager.isGameOver && LevelManager.gameStart)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");

            Vector3 forceVector = new Vector3(moveHorizontal, 0.0f, 0);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.AddForce(forceVector * speed * 2);
            }
            else
            {
                rb.AddForce(forceVector * speed);
            }
        }
        else
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

    }

}
