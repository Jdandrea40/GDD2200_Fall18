using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                    break;
                }
            case MenuName.MainMenu:
                {
                    break;
                }
            case MenuName.DifficultyMenu:
                {
                    break;
                }
            case MenuName.OptionsMenu:
                {
                    break;
                }
            case MenuName.QuitGame:
                {
                    Application.Quit();
                    Debug.Log("The game has been closed LOSER!");

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
