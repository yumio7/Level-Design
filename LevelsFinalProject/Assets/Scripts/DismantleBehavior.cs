using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DismantleBehavior : MonoBehaviour
{
    GameObject carWindshield;
    GameObject postWindshield;
    GameObject[] wheels;
    GameObject[] postWheels;
    GameObject[] carTop;
    GameObject postTop;
    GameObject car;
    float distance;
    int count = 0;
    bool rayResult = false;

    // Start is called before the first frame update
    void Start()
    {
        carWindshield = GameObject.FindGameObjectWithTag("Windshield");
        postWindshield = GameObject.FindGameObjectWithTag("Postwindshield");
        wheels = GameObject.FindGameObjectsWithTag("Wheel");
        postWheels = GameObject.FindGameObjectsWithTag("Postwheel");
        carTop = GameObject.FindGameObjectsWithTag("Top");
        postTop = GameObject.FindGameObjectWithTag("Posttop");
        car = GameObject.FindGameObjectWithTag("WholeCar");

        postWindshield.SetActive(false);
        postTop.SetActive(false);

        foreach (GameObject g in postWheels)
        {
            g.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, car.transform.position);

        Debug.Log(distance);

        if (Input.GetMouseButtonDown(0) && distance <= 5 && rayResult && count < 3)
        {
            Debug.Log("fjdkfjdfd");

            if (count == 0)
            {
                carWindshield.SetActive(false);
                postWindshield.SetActive(true);
            }
            else if (count == 1)
            {
                foreach (GameObject w in wheels)
                {
                    w.SetActive(false);
                }

                foreach (GameObject o in postWheels)
                {
                    o.SetActive(true);
                }
            }
            else if (count == 2)
            {
                foreach (GameObject t in carTop)
                {
                    t.SetActive(false);
                }

                postTop.SetActive(true);
            }
            count++;
        }
    }

    private void FixedUpdate()
    {
        rayResult = IsCarInView();
    }

    bool IsCarInView()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("Car"))
            {
                Debug.Log("Please work ples");
                return true;
            }
        }

        return false;
    }
}
