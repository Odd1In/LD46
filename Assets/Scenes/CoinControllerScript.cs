using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinControllerScript : MonoBehaviour
{
    private GamePackageController packageController;
    public float amount;
    
    // Start is called before the first frame update
    void Start()
    {
        packageController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GamePackageController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            packageController.PickupCoin(amount);
            packageController.SpawnCoin(1);
            Destroy(gameObject);
        }
    }
}
