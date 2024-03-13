using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleBehavior : MonoBehaviour
{
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        if (LevelManager.gameStart)
        {
            rb.isKinematic = false;
        }
        if (LevelManager.isGameOver)
        {
            rb.isKinematic = true;
        }
    }
}
