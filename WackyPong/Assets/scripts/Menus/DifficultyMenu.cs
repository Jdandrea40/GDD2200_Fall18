using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyMenu : MenuManager
{
    bool twoPlayers;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SinglePlayerStart()
    {

    }

    void TwoPlayerStart()
    {
        twoPlayers = true;
    }
}
