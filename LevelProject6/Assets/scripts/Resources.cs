using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{
    [SerializeField] private int Air = 100;
    [SerializeField] private int Battery = 100;
    [SerializeField] private int AirMax = 100;
    [SerializeField] private int BatteryMax = 100;


    [SerializeField] private float AirDrain = 0.25f;
    [SerializeField] private float BatteryDrain = 0.25f;

    private bool AirDraining;
    private bool BatteryDraining;

    private float t;
    private float t2;

    // Start is called before the first frame update
    void Start()
    {
        AirDraining = true;
        BatteryDraining = true;
        t = AirMax;
        t2 = BatteryMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (AirDraining) {
            Air = (int)Mathf.Lerp(Air, 0, t);
            t += AirDrain * Time.deltaTime;
        }
        
        if (BatteryDraining) {
            Battery = (int)Mathf.Lerp(Battery, 0, t2);
            t2 += BatteryDrain * Time.deltaTime;
        }
    }

    public void AddAir(int gain)
    {
        Air += gain;
        if (Air > AirMax) {
            Air = AirMax;
        }
    }

    public void AddBattery(int gain)
    {
        Battery += gain;
        if (Battery > BatteryMax) {
            Battery = BatteryMax;
        }
    }

}
