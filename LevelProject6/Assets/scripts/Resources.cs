using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class Resources : MonoBehaviour
{
    private float Air;
    private float Battery;
    [SerializeField] private int AirMax = 100;
    [SerializeField] private int BatteryMax = 100;

    [SerializeField] private GameObject flashlight;

    [SerializeField] private float AirDrain = 0.0001f;
    [SerializeField] private float BatteryDrain = 0.0001f;

    private bool AirDraining;
    private bool BatteryDraining;
    private bool lightout;

    [SerializeField] private TextMeshProUGUI airText;
    [SerializeField] private TextMeshProUGUI batteryText;

    // Start is called before the first frame update
    void Start()
    {
        Air = AirMax;
        Battery = BatteryMax;
        AirDraining = true;
        BatteryDraining = true;
        lightout = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (AirDraining) {
            Air -= AirDrain * Time.deltaTime;
        }
        
        if (BatteryDraining) {
            Battery -= BatteryDrain * Time.deltaTime;
        }

        if (Battery < 0)
            Battery = 0;

        //if (Air <= 0)
            //GameOver();

        airText.text = "Air " + ((int)Air).ToString("N");
        batteryText.text = ((int)Battery).ToString("N") + " Bat";

        lightout = (Battery <= 0);
        flashlight.SetActive(!lightout);
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

    private void ToggleLight()
    {
        flashlight.SetActive(!flashlight.activeSelf);
    }
}
