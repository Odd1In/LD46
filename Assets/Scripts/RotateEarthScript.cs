using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RotateEarthScript : MonoBehaviour
{
    public float rotateSpeed;
    [SerializeField] private float initialRotateSpeed;
    private AudioSource audioSource;
    private float defaultPitch;
    private float audioPitch;
    // Start is called before the first frame update
    void Start()
    {
        defaultPitch = 1;
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("menu"))
        {
            audioSource = GameObject.Find("Audio").GetComponent<AudioSource>();
        }
    }
        // Update is called once per frame
        void Update()
        {


            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("menu"))
            {

                audioSource.pitch = defaultPitch + (Input.GetAxis("Vertical") / 5);
                Debug.Log(Input.GetAxis("Horizontal"));
                if (Input.GetAxis("Horizontal") >= 0.2f || Input.GetAxis("Horizontal") <= -0.2f)
                {
                    rotateSpeed = Input.GetAxis("Horizontal") * -25 * initialRotateSpeed;
                }
                else
                {
                    rotateSpeed = initialRotateSpeed;
                }

            }
            transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
        }
    }

