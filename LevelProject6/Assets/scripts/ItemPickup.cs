using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{   
    [SerializeField] private bool Air = true;

    public int Gain = 10;

    private int touched = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && touched == 0)
        {
            touched++;
            var PlayerResources = other.gameObject.GetComponent<Resources>();

            if (Air)
            {
                PlayerResources.AddAir(Gain);
            } else {
                PlayerResources.AddBattery(Gain);
            }
            
            Destroy(gameObject);
        }
        else
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), other);
        }
    }
}
