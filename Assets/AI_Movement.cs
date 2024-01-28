using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Movement : MonoBehaviour
{
    public enum states
    {
        idle,
        patrolling,
        chasing,
        spin,
        spinPatrol
    }

    private Transform player;
    public Transform[] targets;
    private int index;
    private NavMeshAgent agent;
    private bool patrolTargetSet = false;
    public states stateMachineAI;
    public float spinrate;
    private bool hasStarted = false;
    public int patrolDelayTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //agent.destination = player.position;


        switch (stateMachineAI)
        {
            case states.idle:
                //Stops the enemy movement
                if (patrolTargetSet)
                {
                    patrolTargetSet = false;
                }
                agent.destination = gameObject.transform.position;
                break;
            case states.patrolling:
                // Code that has the AI move from point to point. Can add as many targets as we want.
                if (!hasStarted)
                {
                    StartCoroutine(delay());
                }
                
                
                break;
            case states.chasing:
                //Will make the AI chase the player
                if (patrolTargetSet)
                {
                    patrolTargetSet = false;
                }
                agent.destination = playerController.instance.transform.position;
                break;
            case states.spin:
                //spins the AI in a circle
                if (patrolTargetSet)
                {
                    patrolTargetSet = false;
                    
                }
                transform.Rotate(0, spinrate, 0);
                break;

            case states.spinPatrol:
                transform.Rotate(0, spinrate, 0);
                StartCoroutine(delay());
                
                break;
        }

    }
    public void setChase()
    {
        stateMachineAI = states.chasing;
    }
    public void setPatrol()
    {
        stateMachineAI = states.patrolling;
    }
    public void setIdle()
    {
        stateMachineAI = states.idle;
    }
    public void setSpin()
    {
        stateMachineAI = states.spin;
    }
    public void setSpinPatrol()
    {
        stateMachineAI = states.spinPatrol;
    }

    IEnumerator delay()
    {
        hasStarted = true;
        
        while (hasStarted)
        {
            if (!patrolTargetSet)
            {
                agent.destination = targets[index].position;
                patrolTargetSet = true;
                hasStarted = false;
            }

            if (Vector3.Distance(gameObject.transform.position, targets[index].position) < 2)
            {
                
                index++;
                if (index >= targets.Length)
                {
                    index = 0;
                }
                yield return new WaitForSeconds(patrolDelayTimer);
                agent.SetDestination(targets[index].position);
                hasStarted = false;
            }
            yield return null;
        }
        

        
    }
}


