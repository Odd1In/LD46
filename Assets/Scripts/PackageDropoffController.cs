using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageDropoffController : MonoBehaviour
{

    private GamePackageController packageController;
    private GameUIController gameUIController;
    [SerializeField] private bool inArea;
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
                gameUIController.ChangeTempText("");
                packageController.DropPackage();
                inArea = false;
                
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            gameUIController.ChangeTempText("Press Space to drop");
            inArea = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (packageController.inTutorial)
            {
                gameUIController.ChangeTempText("Take this box to the green drop off point");
                inArea = false;
            }
            
        }
        
    }
}
