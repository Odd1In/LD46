using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePackageController : MonoBehaviour
{

    [SerializeField] private PackagePickupController packagePickup;
    [SerializeField] private PackageDropoffController packageDropoff;

    [HideInInspector] public bool packageInTransit;

    [SerializeField] private GameObject packagePrefab;
    private GameObject player;
    private List<GameObject> packages = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
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

    }
    public void DropPackage()
    {
        packageInTransit = false;
        Destroy(packages[packages.Count - 1]);
        packages.RemoveAt(packages.Count-1);
    }
}
public class Package : MonoBehaviour
{
    public int energy;
}