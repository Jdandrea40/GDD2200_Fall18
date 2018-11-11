using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    MenuName menuName;

    /// <summary>
    /// Starts the Game
    /// </summary>
    public void PlayGame()
    {
        MenuManager.GoToMenu(MenuName.PlayGame);
    }

    /// <summary>
    /// Goes to Help Menu
    /// </summary>
    public void HelpMenu()
    {
        MenuManager.GoToMenu(MenuName.HelpMenu);
    }

    /// <summary>
    /// Pauses and Resumes the game
    /// </summary>
    public void PauseGame()
    {
        MenuManager.GoToMenu(MenuName.PauseGame);
    }

    /// <summary>
    /// Goes to Main Menu
    /// </summary>
    public void GoToMain()
    {
        MenuManager.GoToMenu(MenuName.MainMenu);
    }

    /// <summary>
    /// Quits the game
    /// </summary>
    public void QuitGame()
    {
        MenuManager.GoToMenu(MenuName.QuitGame);
    }
}


