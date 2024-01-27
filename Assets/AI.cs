using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Micosmo.SensorToolkit;

public class AI : MonoBehaviour
{
    [Range(1, 5)] public int retaredMeter;
    public LOSSensor lineOfSightSensor;
    public Sensor rangeSensor;

    // Start is called before the first frame update
    void Start()
    {

    }



    public void OnSomeDetection()
    {
        Debug.Log("detection test");
    }
}
