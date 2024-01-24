using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float speed = 5f;
    public bool thirdPerson = true;
    public GameObject firstPovCamera;
    public GameObject thirdPovCamera;

    // Start is called before the first frame update
    void Start()
    {
        firstPovCamera = GameObject.Find("FirstCamera");
        thirdPovCamera = GameObject.Find("ThirdCamera");
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
            transform.Rotate(0, -90, 0);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(0, 90, 0);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!thirdPerson)
            {
                thirdPovCamera.SetActive(false);
                firstPovCamera.SetActive(true);
                thirdPerson = true;
            } else
            {
                firstPovCamera.SetActive(false);
                thirdPovCamera.SetActive(true);
                thirdPerson = false;
            }
        }
        
    }
}
