﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    [SerializeField] private float playerSpeed;
    private Vector3 leftStickInput;
    private Vector3 rightStickInput;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInput();
        
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
}