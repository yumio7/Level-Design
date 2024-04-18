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

    // Start is called before the first frame update
    void Start()
    {
        carWindshield = GameObject.FindGameObjectWithTag("Windshield");
        postWindshield = GameObject.FindGameObjectWithTag("Postwindshield");
        wheels = GameObject.FindGameObjectsWithTag("Wheel");
        postWheels = GameObject.FindGameObjectsWithTag("Postwheels");
        carTop = GameObject.FindGameObjectsWithTag("Top");
        postTop = GameObject.FindGameObjectWithTag("Posttop");
        car = GameObject.FindGameObjectWithTag("Car");

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

        if (Input.GetMouseButtonDown(0) && distance <= 2 && IsCarInView() && count < 3)
        {
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

    bool IsCarInView()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("Car"))
            {
                return true;
            }
        }

        return false;
    }
}
