using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Micosmo.SensorToolkit;

public class AI_Controller : MonoBehaviour
{

    [Range(1, 5)] public int retaredMeter;
    public LOSSensor lineOfSightSensor;
    public Sensor rangeSensor;

    public static GameObject player;
    public static AI_Detection detection;

    public MovementType movementType;
    public enum MovementType
    {
        Spin,
        Idle,
        Patrol,
    }

    public bool willSpin;
    public bool willChase;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private IEnumerator ReturnToDefaultMovement()
    {
        //set movement to idle

        yield return new WaitForSeconds(0.5f);

        switch (movementType)
        {
            case MovementType.Idle:
                break;
            case MovementType.Patrol:
                break;
            case MovementType.Spin:
                break;
        }

        yield break;
    }
    public void PlayerEnterRange()
    {
        
    }

    public void PlayerExitRange()
    {

    }

    public void PlayerEnterLOS()
    {
        if (willChase)
        {

        }
    }

    public void PlayerLeaveLOS()
    {
        ReturnToDefaultMovement();
    }

    public float GetPlayerVisibility()
    {
        return lineOfSightSensor.GetResult(player).Visibility;
    }



}
