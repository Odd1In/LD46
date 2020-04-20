using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject player;
    PlayerController playerController;
    public GameObject bullet;
    private float timer;
    [SerializeField] public float cooldownTime;
    public float health = 5;
    public float bulletLifespan;
    public float bulletSpeed;
    public float bulletDamage;
    public int area;
    public float speed;
    public Vector3[] waypoints;


    //Stupid variable
    private float waitToUpdatePosition;
    // Start is called before the first frame update
    void Start()
    {
        waitToUpdatePosition = 1f;
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();


    }
    // Update is called once per frame
    void Update()
    {
        waitToUpdatePosition -= Time.deltaTime;
        if(waitToUpdatePosition <= 0)
        {
        //    agent.updatePosition = true;
        }
        agent.speed = speed;
        agent.destination = player.transform.position;

        
        if (agent.remainingDistance > 130f)
        {
            agent.isStopped = true;
        }
        else
        {
            if (playerController.inSafeRoom)
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

                if (agent.remainingDistance < 15f)
                {
                    timer -= Time.deltaTime;
                    if (timer <= 0)
                    {
                        timer = cooldownTime;
                        ShootBullet();
                    }

                }
            }
            
        }

        if(health <= 0)
        {
            Destroy(gameObject);
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
        bulletScript.damage = 5f;
    }
}
