using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBehavior : MonoBehaviour
{
    public float bounceForce = 5f;
    public bool isRandom = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      //  GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.grey, Mathf.PingPong(Time.time, 1));

    }

    private void OnCollisionEnter(Collision collision)
    {
        float random = Random.Range(0, 100) / 50; //0~2
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 bounceDirection = -collision.GetContact(0).normal;
            if (isRandom)
            {
                rb.AddForce(bounceDirection * (bounceForce + random), ForceMode.Impulse);
            }
            else
            {
                rb.AddForce(bounceDirection * (bounceForce), ForceMode.Impulse);
            }
        }
    }
}
