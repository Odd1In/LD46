using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackagePickupController : MonoBehaviour
{
    private GamePackageController packageController;
    private bool inArea;
    // Start is called before the first frame update
    void Start()
    {
        packageController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GamePackageController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inArea)
        {
            if (Input.GetButtonDown("Jump"))
            {
                packageController.PickupPackage();
                Debug.Log("UP");
                inArea = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Press Y to pickup");
        inArea = true;
    }

    private void OnTriggerExit(Collider other)
    {
        inArea = false;
    }
}
