using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        // Freezes the Game
        Time.timeScale = 0;		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // pauses the game
    void PauseGame()
    {

    }

   /// <summary>
   /// Unpauses the game
   /// </summary>
   public void UnPauseGame()
    {
        // Unfreezes and then destorys the Pause Menu
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    /// <summary>
    /// Quits the Game and returns to Main Menu
    /// </summary>
    public void QuitGame()
    {
        // Unfreezes the game when quit
        Time.timeScale = 1;

        // Destroys the Pause Menu prefab
        Destroy(gameObject);

        // Goes to main menu via the Menu Manager
        MenuManager.GoToMenu(MenuName.MainMenu);

    }
}
