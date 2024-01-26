using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public Transform[] target1;
    private int index;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = target1[1].position;
    }

    // Update is called once per frame
    void Update()
    {
        //agent.destination = player.position;
        if (Vector3.Distance(gameObject.transform.position, target1[index].position) < 1)
        {
            index++;
            if(index >= target1.Length)
            {
                index = 0;
            }
            agent.SetDestination(target1[index].position);
        }
        
    }
}
