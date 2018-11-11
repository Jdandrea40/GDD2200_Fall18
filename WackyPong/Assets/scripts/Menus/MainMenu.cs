using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    MenuManager menuManager;
    MenuName menuName;

    private void Start()
    {
        menuManager = Camera.main.GetComponent<MenuManager>();
    }
    
    /// <summary>
    /// Starts the Game
    /// </summary>
    public void PlayGame()
    {
        menuManager.GoToMenu(MenuName.PlayGame);
    }

    /// <summary>
    /// Goes to Help Menu
    /// </summary>
    public void HelpMenu()
    {
        menuManager.GoToMenu(MenuName.HelpMenu);
    }

    /// <summary>
    /// Pauses and Resumes the game
    /// </summary>
    public void PauseGame()
    {
        menuManager.GoToMenu(MenuName.PauseGame);
    }

    /// <summary>
    /// Goes to Main Menu
    /// </summary>
    public void GoToMain()
    {
        menuManager.GoToMenu(MenuName.MainMenu);
    }

    /// <summary>
    /// Quits the game
    /// </summary>
    public void QuitGame()
    {
        menuManager.GoToMenu(MenuName.QuitGame);
    }
}


