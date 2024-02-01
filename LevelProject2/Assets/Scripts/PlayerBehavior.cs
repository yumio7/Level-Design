using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float speed = 2f;
    private Transform camtf;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        camtf = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float moveY = Input.GetAxis("Jump");

        Vector3 forceVector = new Vector3(moveHorizontal, moveY, moveVertical);
        forceVector = camtf.TransformDirection(forceVector);

        rb.AddForce(forceVector * speed);
    }
}
