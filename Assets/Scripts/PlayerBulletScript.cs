using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletScript : MonoBehaviour
{
    public float lifespan;
    public float age;
    [HideInInspector] public float speed;
    private Rigidbody rb;
    [HideInInspector] public float damage;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // rb.AddForce(transform.forward * speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        age += Time.deltaTime;
        if (age >= lifespan)
        {
            Destroy(gameObject);
            age = 0;
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
    
        

        
        if (collision.collider.transform.tag == "Enemy")
        {
            Debug.Log("Enemy!");
            EnemyController enemy;
            enemy = collision.gameObject.GetComponent<EnemyController>();
            enemy.health -= damage;
            
            Destroy(gameObject);
        }
    }
}

