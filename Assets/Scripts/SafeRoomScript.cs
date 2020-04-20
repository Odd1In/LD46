using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeRoomScript : MonoBehaviour
{
    private GameObject player;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            playerController.inSafeRoom = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            playerController.inSafeRoom = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (playerController.inSafeRoom == false)
            {
                playerController.inSafeRoom = true;
            }
        }
        
    }
}
