using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ceilingBehavior : MonoBehaviour
{
    public Vector3 openPosition;
    public float slideSpeed = 1.0f;
    private Vector3 closedPosition;
    private bool isOpening = false;
    private bool isClosing = false;
    GameObject player;
    GameObject roomEntered;
    GameObject car;
    Rigidbody carRB;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        roomEntered = GameObject.FindGameObjectWithTag("EnterRoom");
        car = GameObject.FindGameObjectWithTag("Car");
        carRB = car.GetComponent<Rigidbody>();
        carRB.isKinematic = true;
        closedPosition = transform.position;
        openPosition = closedPosition;
        openPosition.x = closedPosition.x - 4;
    }

    void Update()
    {
        if (Vector3.Distance(player.transform.position, roomEntered.transform.position) < 0.5)
        {
            OpenDoor();
        }
        if (isOpening && !isClosing)
        {
            transform.position = Vector3.Lerp(transform.position, openPosition, slideSpeed * Time.deltaTime);
        }
        if(Vector3.Distance(transform.position, openPosition) < 0.7)
        {
            carRB.isKinematic = false;
        }
        if(Vector3.Distance(transform.position, openPosition) < 0.1)
        {
            isClosing = true;
        }
        if (isClosing)
        {
            transform.position = Vector3.Lerp(transform.position, closedPosition, slideSpeed * Time.deltaTime);
        }
    }

    public void OpenDoor()
    {
        isOpening = true;
    }
}
