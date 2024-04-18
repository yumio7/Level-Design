using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSound1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().Play();
        GetComponent<Collider>().enabled = false;
    }
}
