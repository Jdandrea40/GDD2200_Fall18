using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    // Text change support
    [SerializeField]
    Text leftText;
    [SerializeField]
    Text rightText;
    [SerializeField]
    Text scoreText;

    static Paddle paddle;

	// Use this for initialization
	void Start ()
    {
        paddle = GetComponent<Paddle>();

        //Text leftText = leftTextBox.GetComponent<Text>();

        // Changes HUD text to include hit count
        leftText.text = "Left Hit Count: ";
        rightText.text = "Right Hit Count: ";
    }

    void AddHits(ScreenSide side)
    {
        if (side == ScreenSide.Left)
        {
            leftText.text = "Left Hit Count: " + hits;
        }
        if (side == ScreenSide.Right)
        {
            rightText.text = "Right Hit Count: " + hits;
        }
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
