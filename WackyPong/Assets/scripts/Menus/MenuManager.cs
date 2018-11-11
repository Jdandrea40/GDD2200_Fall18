using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager
{
    /// <summary>
    /// Menu Navigation method
    /// </summary>
    public static void GoToMenu(MenuName menuNames)
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
                    // Instantiates the Pause Menu via the Resources Folder in Unity
                    Object.Instantiate(Resources.Load("PauseMenu"));

                    break;
                }
            case MenuName.QuitGame:
                {
                    // Quits the game (Build Only)
                    Application.Quit();

                    // Console Print for testing
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
}
