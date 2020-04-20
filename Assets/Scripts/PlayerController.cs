using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    private AudioSource shootAudio;
    [SerializeField] private float playerSpeed;
    private Vector3 leftStickInput;
    private Vector3 rightStickInput;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletDamage;

    private GamePackageController gamePackageController;


    public bool inSafeRoom;
    private Vector3 oldMousePosition;

    [SerializeField] private float cooldown;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gamePackageController = GameObject.Find("GameController").GetComponent<GamePackageController>();
        oldMousePosition = Input.mousePosition;
        timer = cooldown;

        shootAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        
        GetPlayerInput();
        if (gamePackageController.inGame)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                GameObject b;
                PlayerBulletScript bulletScript;
                Rigidbody bulletRb;
                b = Instantiate(bullet);
                bulletScript = b.GetComponent<PlayerBulletScript>();
                b.transform.position = transform.position + transform.forward;
                bulletScript.damage = 1;
                b.transform.rotation = transform.rotation;
                bulletRb = b.GetComponent<Rigidbody>();
                bulletRb.AddForce(transform.forward * bulletSpeed * Time.deltaTime);
                shootAudio.Play();
            }
            if (Input.GetAxis("Fire1") > 0.3f)
            {
                if (timer <= 0)
                {
                    timer = cooldown;
                    GameObject b;
                    PlayerBulletScript bulletScript;
                    Rigidbody bulletRb;
                    b = Instantiate(bullet);
                    bulletScript = b.GetComponent<PlayerBulletScript>();
                    b.transform.position = transform.position + transform.forward;
                    bulletScript.damage = 1;
                    b.transform.rotation = transform.rotation;
                    bulletRb = b.GetComponent<Rigidbody>();
                    bulletRb.AddForce(transform.forward * bulletSpeed * Time.deltaTime);
                    shootAudio.Play();
                }

            }
        }

        
        
        
    }

    private void GetPlayerInput()
    {
        leftStickInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rightStickInput = new Vector3(Input.GetAxis("R_Horizontal"), 0, Input.GetAxis("R_Vertical"));
    }

    private void FixedUpdate()
    {
        Vector3 curMovement = leftStickInput * playerSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + curMovement);
        //rb.AddForce(curMovement.magnitude * transform.forward);
        //Debug.Log(curMovement.magnitude * transform.forward);
        // rb.transform.position = (curMovement * transform.forward);
        MouseRotation();
        ControllerRotation();
        

    }

    private void ControllerRotation()
    {
        if (rightStickInput.magnitude > 0.4f)
        {
            Vector3 curRotation = Vector3.left * rightStickInput.x + Vector3.forward * rightStickInput.z;
            Quaternion playerRotation = Quaternion.LookRotation(curRotation, Vector3.up);
            transform.rotation = playerRotation;
        }
    }

    private void MouseRotation()
    {
        
        if (Input.mousePosition != oldMousePosition)
        {
            //Mouse rotation
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 point = hit.point;
                point.y = 0.5f;

                transform.LookAt(point);

                // Do something with the object that was hit by the raycast.
            }
        }
        oldMousePosition = Input.mousePosition;

    }


    public void LoseHealth(float damage)
    {
        gamePackageController.RemoveEnergy(damage);
    }


    
}
