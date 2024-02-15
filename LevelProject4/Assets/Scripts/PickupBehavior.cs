using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehavior : MonoBehaviour
{
    public static int items_gathered;

    // Start is called before the first frame update
    void Start()
    {
        items_gathered = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (IsPlayerNearby())
            {
                Destroy(gameObject);
                items_gathered++;
            }
        }
    }

    bool IsPlayerNearby()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < 0.3f)
            {
                return true;
            }
        }
        return false;
    }
}
