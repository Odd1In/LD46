using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyObject;
    [Space]
    [Header("Spawn Locations")]
    [SerializeField] private Transform spawn1;
    [SerializeField] private Transform spawn2;
    [SerializeField] private Transform spawn3;
    [SerializeField] private Transform spawn4;

    [Header("Waypoints")]
    [SerializeField] private Transform[] waypointsArea1;
    [SerializeField] private Transform[] waypointsArea2;
    [SerializeField] private Transform[] waypointsArea3;

    private float timer;
    private float spawnTime;
    private int enemyCount;
    private int enemyLimit;
    // Start is called before the first frame update
    void Start()
    {
        enemyLimit = 20;
        spawnTime = 2f;
        timer = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            SpawnEnemy();
            timer = spawnTime;
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            SpawnEnemy();
        }
    }

    public GameObject SpawnEnemy(int area = 0, float speed = 5, float health = 5, float cooldown = 0.2f, float bulletSpeed = 550f, float bulletDamage = 5f, float bulletLifespan = 2f)
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if(enemyCount > enemyLimit - 1)
        {
            Debug.Log("Too much enemies");
            return null;
        }
        if (area > 3)
        {
            Debug.Log("Not a valid area code");
            return null;
        }
        //AREA AND SPAWN POINT
        Transform spawnPoint;
        int spawnIndex;
        spawnPoint = null;
        spawnIndex = 0;
        if(area == 0)
        {
            area = Random.Range(1, 4);
            Debug.Log(area);
            
        }
        if(area == 2)
        {
            spawnIndex = Random.Range(2, 4);
        }
        if(area == 1)
        {
            spawnIndex = area; 
        }
        if(area == 3)
        {
            spawnIndex = 4;
        }
        
        switch (spawnIndex)
        {
            case 1:
                spawnPoint = spawn1;
                break;
            case 2:
                spawnPoint = spawn2;
                break;
            case 3:
                spawnPoint = spawn3;
                break;
            case 4:
                spawnPoint = spawn4;
                break;
            default:
                break;
        }
        GameObject obj;
        obj = Instantiate(enemyObject);
        EnemyController enemy;
        enemy = obj.GetComponent<EnemyController>();
        //obj.transform.position = spawnPoint.position;
        obj.transform.position = new Vector3(obj.transform.position.x, 0.58f, obj.transform.position.z);
        enemy.speed = speed;
        enemy.health = health;
        enemy.cooldownTime = cooldown;
        enemy.bulletSpeed = bulletSpeed;
        enemy.bulletDamage = bulletDamage;
        enemy.bulletLifespan = bulletLifespan;


        //obj.GetComponent<NavMeshAgent>().updatePosition = false;
        obj.GetComponent<NavMeshAgent>().Warp(spawnPoint.position);
        Debug.Log("Area " + area + "\n SpawnPoint:" + spawnIndex);
        
        
        return obj;
        
    }
}
