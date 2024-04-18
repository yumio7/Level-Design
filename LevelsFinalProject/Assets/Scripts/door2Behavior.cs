using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door2Behavior : MonoBehaviour
{
    public Vector3 openPosition;
    public float slideSpeed = 0.5f;
    private Vector3 closedPosition;
    private bool isOpening = false;
    private bool isClosing = false;
    GameObject player;
    GameObject elevator;
    GameObject inviDoor;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        elevator = GameObject.FindGameObjectWithTag("SecondFloor");
        //inviDoor = transform.GetChild(0).gameObject;
        closedPosition = transform.position;
        openPosition = closedPosition;
        openPosition.x = closedPosition.x - 2;
    }

    void Update()
    {
        if(Vector3.Distance(player.transform.position, elevator.transform.position) < 0.5)
        {
            isOpening = true;
        }
        if (isOpening && !isClosing)
        {
            transform.position = Vector3.Lerp(transform.position, openPosition, slideSpeed * Time.deltaTime);
        }
        
        if(Vector3.Distance(player.transform.position, elevator.transform.position) > 2 && isOpening)
        {
            //isClosing = true;
        }
        if (isClosing)
        {
            //inviDoor.SetActive(true);
            transform.position = Vector3.Lerp(transform.position, closedPosition, slideSpeed * Time.deltaTime);
        }
    }


}
