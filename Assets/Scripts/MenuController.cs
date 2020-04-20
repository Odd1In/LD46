using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button tutorialButton;
    [SerializeField] private Button quitButton;

    [SerializeField] private TextMeshProUGUI textGamepad;
    // Start is called before the first frame update
    void Start()
    {
        quitButton.onClick.AddListener(QuitGame);
        tutorialButton.onClick.AddListener(GoToTutorial);
        playButton.onClick.AddListener(PlayGame);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetJoystickNames()[0] != "")
        {
            textGamepad.text = "Controller: "+ Input.GetJoystickNames()[0];
        }
        else
        {
            textGamepad.text = "No controllers detected";
        }
        
    }

    void QuitGame()
    {
        Debug.Log("EXIT GAME");
        Application.Quit();
    }

    void GoToTutorial()
    {
        SceneManager.LoadScene(2);
    }
    void PlayGame()
    {
        SceneManager.LoadScene(3);
    }
}
