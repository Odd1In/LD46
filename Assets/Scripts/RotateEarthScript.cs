using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RotateEarthScript : MonoBehaviour
{
    public float rotateSpeed;
    [SerializeField] private float initialRotateSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("menu"))
        {
            Debug.Log(Input.GetAxis("Horizontal"));
            if(Input.GetAxis("Horizontal") >= 0.2f || Input.GetAxis("Horizontal") <= -0.2f)
            {
                rotateSpeed = Input.GetAxis("Horizontal") * -10 * initialRotateSpeed;
            }
            else
            {
                rotateSpeed = initialRotateSpeed;
            }
            
        }
        transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
    }
}
