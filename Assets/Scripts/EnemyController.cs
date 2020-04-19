﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject player;
    public GameObject bullet;
    private float timer;
    [SerializeField]private float cooldownTime;
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

            if(agent.remainingDistance < 10f)
            {
                timer -= Time.deltaTime;
                if(timer <= 0)
                {
                    timer = cooldownTime;
                    ShootBullet();
                }
                
            }
        }

    }

    private void ShootBullet()
    {
        GameObject b;
        BulletScript bulletScript;
        Rigidbody bulletRb;
        b = Instantiate(bullet);
        b.transform.position = transform.position;
        b.transform.LookAt(player.transform.position);
        bulletRb = b.GetComponent<Rigidbody>();
        bulletRb.AddForce((player.transform.position - transform.position) * 8000f * Time.deltaTime);
        bulletScript = b.GetComponent<BulletScript>();
        bulletScript.speed = 500f;
        bulletScript.lifespan = 2f;
    }
}