using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GamePackageController : MonoBehaviour
{

    [SerializeField] private PackagePickupController packagePickup;
    [SerializeField] private PackageDropoffController packageDropoff;

    [HideInInspector] public bool packageInTransit;

    [SerializeField] private GameObject packagePrefab;
    private GameObject player;
    public List<GameObject> packages = new List<GameObject>();

    public float energyNeedeed;
    public float energyTransferred;
    [SerializeField] private TextMeshProUGUI energyNeededText;
    [HideInInspector] public string energyNeedeedString;

    private EnemySpawner enemySpawner;

    [SerializeField] private GameObject coinObject;
    private List<Vector3> coinSpawnLocations = new List<Vector3>();

    [SerializeField] private float initialTime;
    public float timeRemaining;

    private GameUIController gameUIController;

    public bool inGame;
    // Start is called before the first frame update
    void Start()
    {
        inGame = true;
        player = GameObject.FindGameObjectWithTag("Player");
        enemySpawner = GetComponent<EnemySpawner>();
        timeRemaining = initialTime;

        energyNeedeedString = energyNeedeed.ToString()+"kW";

        gameUIController = GetComponent<GameUIController>();


        GameObject[] coinSpawnLocationObjects;
        coinSpawnLocationObjects = GameObject.FindGameObjectsWithTag("Coin Spawn");
        foreach (var coinSpawnLocationObject in coinSpawnLocationObjects)
        {
            coinSpawnLocations.Add(coinSpawnLocationObject.transform.position);
        }

        SpawnCoin(4);
    }

    // Update is called once per frame
    void Update()
    {
        RemoveTime();
        if (packageInTransit)
        {
            packagePickup.gameObject.SetActive(false);
            packageDropoff.gameObject.SetActive(true);
        }
        else
        {
            packageDropoff.gameObject.SetActive(false);
            packagePickup.gameObject.SetActive(true);
        }

        if(inGame == false)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    private void RemoveTime()
    {
        if (inGame)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 0)
            {
                EndGame();
            }
        }
        
    }

    public void PickupCoin(float amount)
    {
        if((timeRemaining + amount) <= 99)
        {
            timeRemaining += amount;
        }
        
    }
    private void EndGame()
    {
        gameUIController.ChangeTempText("You lost!\nPress 'Enter' to exit");
        inGame = false;
    }

    private void WinGame()
    {
        gameUIController.ChangeTempText("You won!\nTime:"+timeRemaining+"\nPress 'Enter' to exit");
        inGame = false;
    }
    
    public void PickupPackage() //Spawn Package
    {
        GameObject obj;
        Package package;
        packageInTransit = true;
        obj = Instantiate(packagePrefab);
        obj.transform.parent = player.transform;
        obj.transform.localPosition = new Vector3(0, packages.Count+1, 0);
        package = obj.AddComponent<Package>();
        package.energy = 100;
        packages.Add(obj);
        enemySpawner.SpawnEnemy(1);
        enemySpawner.SpawnEnemy(1);
        enemySpawner.SpawnEnemy(2);
        enemySpawner.SpawnEnemy(2);
        enemySpawner.SpawnEnemy(3);
        enemySpawner.SpawnEnemy(3);
    }
    public void DropPackage()
    {

        energyTransferred += packages[packages.Count - 1].GetComponent<Package>().energy;
        packageInTransit = false;
        Destroy(packages[packages.Count - 1]);
        packages.RemoveAt(packages.Count-1);

        if(energyTransferred >= energyNeedeed)
        {
            WinGame();
        }
    }

    public void RemovePackages(int index)
    {
        packageInTransit = false;
        Destroy(packages[index]);
        packages.RemoveAt(index);
    }

    public float TotalHolding()
    {
        float total = 0;
        foreach (var package in packages)
        {
            total += package.GetComponent<Package>().energy;

        }
        return total;
    }

    public void RemoveEnergy(float amount)
    {
        if (packageInTransit)
        {
            float total = TotalHolding();
            if (total - amount <= 0)
            {
                RemovePackages(0);
            }
            else
            {
                Package topPackage = packages[packages.Count - 1].GetComponent<Package>();
                topPackage.energy -= amount;
            }
        }
        
    }

    public void SpawnCoin(int count = 1)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject coin;
            coin = Instantiate(coinObject);
            coin.transform.position = coinSpawnLocations[Random.Range(0, coinSpawnLocations.Count)];
            Debug.Log("Spawn Coin");
        }
        
    }
}


public class Package : MonoBehaviour
{
    public float energy;
}