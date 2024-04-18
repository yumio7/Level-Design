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
    GameObject inviDoor;
    int callOnce = 0;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        elevator = GameObject.FindGameObjectWithTag("Elevator");
        inviDoor = transform.GetChild(0).gameObject;
        closedPosition = transform.position;
        openPosition = closedPosition;
        openPosition.x = closedPosition.x + 2;
        Debug.Log(closedPosition);
    }

    void Update()
    {
        if(Vector3.Distance(player.transform.position, elevator.transform.position) < 0.5f)
        {
            OpenDoor();
        }
        if (isOpening)
        {
            inviDoor.SetActive(true);
            transform.position = Vector3.Lerp(transform.position, openPosition, slideSpeed * Time.deltaTime);
        }
        if(Vector3.Distance(transform.position, openPosition) < 0.1f)
        {
            if(callOnce == 0)
            {
                SceneManager.doorIsClosed();
                ding();
                callOnce++;
            }
        }
    }

    public void OpenDoor()
    {
        isOpening = true;
    }

    private void ding()
    {
        GetComponent<AudioSource>().Play();
    }
}
