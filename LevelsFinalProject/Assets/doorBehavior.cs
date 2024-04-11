using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorBehavior : MonoBehaviour
{
    public Vector3 openPosition;
    public float slideSpeed = 1.0f;
    private Vector3 closedPosition; 
    private bool isOpening = false;
    GameObject player;
    GameObject elevator;
    int callOnce = 0;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        elevator = GameObject.FindGameObjectWithTag("Elevator");
        closedPosition = transform.position;
        openPosition = closedPosition;
        openPosition.x = closedPosition.x - 2;
    }

    void Update()
    {
        if(Vector3.Distance(player.transform.position, elevator.transform.position) < 0.5)
        {
            OpenDoor();
        }
        if (isOpening)
        {
            transform.position = Vector3.Lerp(transform.position, openPosition, slideSpeed * Time.deltaTime);
        }
        if(Vector3.Distance(transform.position, openPosition) < 0.2)
        {
            if(callOnce == 0)
            {
                SceneManager.doorIsClosed();
                callOnce++;
            }
        }
    }

    public void OpenDoor()
    {
        isOpening = true;
    }
}
