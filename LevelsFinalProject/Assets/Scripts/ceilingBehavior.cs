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
    GameObject godRay;
    Rigidbody carRB;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        roomEntered = GameObject.FindGameObjectWithTag("EnterRoom");
        car = GameObject.FindGameObjectWithTag("WholeCar");
        godRay = GameObject.FindGameObjectWithTag("Godray");
        godRay.SetActive(false);
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
            godRay.SetActive(true);
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
        if(isClosing && Vector3.Distance(transform.position, closedPosition) < 0.3)
        {
            godRay.SetActive(false);
        }
    }

    public void OpenDoor()
    {
        isOpening = true;
    }
}
