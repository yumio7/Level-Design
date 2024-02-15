using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering;

public class RevealFog : MonoBehaviour
{
    [SerializeField] private Volume fog;
    [SerializeField] private Light dirLight;

    [SerializeField] private float fogStart = 1.0f;
    [SerializeField] private float fogEnd = 0.015f;
    [SerializeField] private float deltaTime = 0.1f;

    private Quaternion lightStart;
    private Quaternion lightEnd;
    [SerializeField] private float lightSpeed = 0.09f;

    private float t;
    private float t2;

    // Start is called before the first frame update
    void Start()
    {
        t = 0;
        t2 = 0;
        //lightStart = new Quaternion(0.0838665515f,0.0369701125f,-0.0940774083f,-0.991337001f);
        lightStart = new Quaternion(0.0865746737f,0.037227001f,-0.0939760208f,-0.991104186f);
        lightEnd = new Quaternion(-0.0886491835f,0.0201622788f,-0.0990496203f,-0.990920842f);

        dirLight.transform.rotation = lightStart;
    }

    // Update is called once per frame
    void Update()
    {
        if (PickupBehavior.items_gathered >= 3) {
            fog.weight = Mathf.Lerp(fogStart, fogEnd, t);
            t += deltaTime * Time.deltaTime;

            dirLight.transform.rotation = Quaternion.Lerp(lightStart, lightEnd, t2);
            t2 += lightSpeed * Time.deltaTime;
        }
    }


}
