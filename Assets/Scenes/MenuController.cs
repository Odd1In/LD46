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
        
    }

    void QuitGame()
    {
        Debug.Log("EXIT GAME");
        Application.Quit();
    }

    void GoToTutorial()
    {
        SceneManager.LoadScene(1);
    }
    void PlayGame()
    {
        SceneManager.LoadScene(2);
    }
}
