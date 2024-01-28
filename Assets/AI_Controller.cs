using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Micosmo.SensorToolkit;


[RequireComponent(typeof(AI_Movement))]
public class AI_Controller : MonoBehaviour
{

    [Range(1, 5)] public int retaredMeter;
    public LOSSensor lineOfSightSensor;
    public Sensor rangeSensor;
    public AI_Movement movement;

    public GameObject player;

    [Header("Stats")]
    public float reactionTime;

    public MovementType movementType;
    public enum MovementType
    {
        Spin,
        Idle,
        Patrol,
        SpinPatrol,
    }

    public bool willChase;

    // Start is called before the first frame update
    void Start()
    {
        ReturnToDefaultMovement();

    }

    private void ReturnToDefaultMovement()
    {
        StopAllCoroutines();
        StartCoroutine(DefaultMovement());
    }
    private IEnumerator DefaultMovement()
    {
        //set movement to idle
        movement.setIdle();

        yield return new WaitForSecondsRealtime(reactionTime);

        switch (movementType)
        {
            case MovementType.Idle:
                movement.setIdle();
                break;
            case MovementType.Patrol:
                movement.setPatrol();
                break;
            case MovementType.Spin:
                movement.setSpin();
                break;
            case MovementType.SpinPatrol:
                movement.setSpinPatrol();
                break;
        }

        yield break;
    }



    public void PlayerEnterRange()
    {
        AI_Detection.instance.AddToList(this);
        Debug.Log(AI_Detection.instance.gameObject);
    }

    public void PlayerExitRange()
    {
        AI_Detection.instance.RemoveFromList(this);
    }


    private IEnumerator PLayerEnterLos()
    {

        if (willChase)
        {
            //set movement to idle
            movement.setIdle();
            yield return new WaitForSecondsRealtime(reactionTime);
            movement.setChase();
        }
    }

    public void PlayerEnterLOS()
    {
        StartCoroutine(PLayerEnterLos());
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
