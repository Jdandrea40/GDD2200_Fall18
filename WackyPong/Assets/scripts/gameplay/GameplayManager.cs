using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gameplay manager
/// </summary>
public class GameplayManager : MonoBehaviour
{
	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start()
	{
		
	}
	
	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
        // Checks for Escape Key in order to pause the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Pauses game via Menu Manager
            MenuManager.GoToMenu(MenuName.PauseGame);
        }
		
	}

}
