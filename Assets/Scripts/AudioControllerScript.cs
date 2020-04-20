using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioControllerScript : MonoBehaviour
{
    private AudioSource[] audioSources;
    private bool muted;
    // Start is called before the first frame update
    void Start()
    {
        muted = false;
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(1);
    }

    private void OnLevelWasLoaded(int level)
    {

       
        
        if(FindObjectsOfType<AudioSource>().Length > 0)
        {
            audioSources = FindObjectsOfType<AudioSource>();
        }
        else
        {
            audioSources = null;
        }
        
        
    }
    private void Awake()
    {
        
       
    }

    // Update is called once per frame
    void Update()
    {
        //audioSource.mute = muted;
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (muted)
            {
                muted = false;
            }
            else
            {
                muted = true;
            }
        }
        if(audioSources != null)
        {
            foreach (AudioSource audio in audioSources)
            {
                audio.mute = muted;
            }
        }
        

    }

}
