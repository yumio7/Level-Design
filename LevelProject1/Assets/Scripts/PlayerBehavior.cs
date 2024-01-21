using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(0, 0, speed);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Translate(0, 0, -speed);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(-speed, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(speed, 0, 0);
        }
    }
}
