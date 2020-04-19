using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 positionOffset;
    public Vector3 rotationOffset;
    // Start is called before the first frame update
    void Start()
    {
        positionOffset = transform.position - playerTransform.position;
        rotationOffset = transform.rotation.eulerAngles;
       // playerTransform = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(rotationOffset);
        transform.position = playerTransform.position + positionOffset;
    }
}
