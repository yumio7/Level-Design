using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSideGears : MonoBehaviour
{
    public float spin = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(spin * Time.deltaTime, 0, 0);
    }
}
