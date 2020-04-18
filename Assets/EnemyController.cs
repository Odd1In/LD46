using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.transform.position;

        
        if (agent.remainingDistance > 20f)
        {
            agent.isStopped = true;
        }
        else
        {
            agent.isStopped = false;
            if (agent.remainingDistance < 4f)
            {
                agent.isStopped = true;
            }
            else
            {
                agent.isStopped = false;
            }
        }

    }
}
