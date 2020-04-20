using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackagePickupController : MonoBehaviour
{
    private GamePackageController packageController;
    private GameUIController gameUIController;
    private bool inArea;
    // Start is called before the first frame update
    void Start()
    {
        packageController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GamePackageController>();
        gameUIController = packageController.GetComponent<GameUIController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inArea)
        {
            if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Space))
            {
                packageController.PickupPackage();
                gameUIController.ChangeTempText("");
                inArea = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        gameUIController.ChangeTempText("Press Space to pickup");
        inArea = true;
    }

    private void OnTriggerExit(Collider other)
    {
        gameUIController.ChangeTempText("");
        inArea = false;
    }
}
