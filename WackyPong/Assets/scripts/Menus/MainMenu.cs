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
    /// Quits the game
    /// </summary>
    public void QuitGame()
    {
        menuManager.GoToMenu(MenuName.QuitGame);
    }
}


