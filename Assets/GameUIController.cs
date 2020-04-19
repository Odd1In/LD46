using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUIController : MonoBehaviour
{
    enum textObjects
    {
        energyNeeded,
        energyHolding
    }
    private PlayerController playerController;
    private GamePackageController gamePackageController;

    [SerializeField] private TextMeshProUGUI txtEnergyHolding;
    [SerializeField] private TextMeshProUGUI txtEnergyNeeded;
    // Start is called before the first frame update
    void Start()
    {
        gamePackageController = GetComponent<GamePackageController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gamePackageController.packageInTransit)
        {
            txtEnergyHolding.enabled = true;
            txtEnergyHolding.SetText("Energy Holding: " + gamePackageController.TotalHolding() + "kW");
        }
        else
        {
            txtEnergyHolding.enabled = false;
        }
    }

    
}
