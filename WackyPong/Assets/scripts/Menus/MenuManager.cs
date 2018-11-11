using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    /// <summary>
    /// Menu Navigation method
    /// </summary>
    public void GoToMenu(MenuName menuNames)
    {
        switch (menuNames)
        {
            case MenuName.HelpMenu:
                {
                    SceneManager.LoadScene("help menu");
                    break;
                }
            case MenuName.MainMenu:
                {
                    SceneManager.LoadScene("main menu");
                    break;
                }
            case MenuName.PauseGame:
                {
                    if (Time.timeScale == 1)
                    {
                        Time.timeScale = 0;
                    }
                    else
                    {
                        Time.timeScale = 1;
                    }

                    break;
                }
            case MenuName.QuitGame:
                {
                    Application.Quit();
                    Debug.Log("The game has been closed LOSER!");

                    break;
                }
            case MenuName.PlayGame:
                {
                    SceneManager.LoadScene("gameplay");
                    break;
                }
        }
    }
    
    // Used to traverse Menu System
    void OpenHelpMenu()
    {

    }

    // starts single play
    void GoToDifficultyMenu()
    {

    }

    void GoToPauseMenu()
    {

    }
}
