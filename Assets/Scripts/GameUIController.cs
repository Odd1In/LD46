using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUIController : MonoBehaviour
{
    public enum textObjects
    {
        energyNeeded = 1,
        energyHolding = 2,
        timer = 3,
        temp = 4
    }
    private PlayerController playerController;
    private GamePackageController gamePackageController;

    [SerializeField] private TextMeshProUGUI txtEnergyHolding;
    [SerializeField] private TextMeshProUGUI txtEnergyNeeded;
    [SerializeField] private TextMeshProUGUI txtTimer;
    [SerializeField] private TextMeshProUGUI txtTempText;
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

        if(txtTimer.text != Mathf.Round(gamePackageController.timeRemaining).ToString())
        {
            txtTimer.text = Mathf.Round(gamePackageController.timeRemaining).ToString();
            txtEnergyNeeded.text = "Energy Target: " + gamePackageController.energyTransferred.ToString() + "/" + gamePackageController.energyNeedeedString;
        }
    }

    public void ChangeTempText(string text)
    {
                txtTempText.text = text;
    }

    
}
