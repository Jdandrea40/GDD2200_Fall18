using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    // Text change support
    [SerializeField]
    GameObject leftTextDisplay;
    [SerializeField]
    GameObject rightTextDisplay;
    [SerializeField]
    GameObject scoreTextDisplay;


    // Pause Menu Support
    [SerializeField]
    GameObject pauseMenu;


    // string change support
    static Text leftTextHits;
    static int leftHits = 0;

    // string change support
    static Text rightTextHits;
    static int rightHits = 0;

    // string change support
    static Text scoreText;
    static int p1Score = 0;
    static int p2Score = 0;

	// Use this for initialization
	void Start ()
    {
        // Resets Scores on Start
        p1Score = 0;
        p2Score = 0;
        leftHits = 0;
        rightHits = 0;

        // Gets Text Component
        leftTextHits = leftTextDisplay.GetComponent<Text>();
        rightTextHits = rightTextDisplay.GetComponent<Text>();
        scoreText = scoreTextDisplay.GetComponent<Text>(); 


        // Changes HUD text to include hit count
        leftTextHits.text = "Facts Checked (Left): " + leftHits;
        rightTextHits.text = "Facts Checked (Right): " + rightHits;
        scoreText.text = p1Score + " - " + p2Score;

    }

    /// <summary>
    /// Add hits method to accrue Hit Count
    /// </summary>
    /// <param name="side"></param>
    /// <param name="hits"></param>
    public static void AddHits(ScreenSide side, int hits)
    {
        // Ledt Side scoring
        if (side == ScreenSide.Left)
        {
            leftHits += hits;
            leftTextHits.text = "Facts Checked (Left): " + leftHits;
        }
        // Right side scoring
        else
        {
            rightHits += hits;
            rightTextHits.text = "Facts Checked (Right) " + rightHits;
        }
    }

    /// <summary>
    /// Adds score to approproiate player
    /// </summary>
    /// <param name="side"></param>
    /// <param name="score"></param>
    public static void AddScore(ScreenSide side, int score)
    {
        // Right side scoring
        if (side == ScreenSide.Left)
        {
            p1Score += score;
            scoreText.text = p1Score + " - " + p2Score;
        }
        // :eft side scoring
        else
        {
            p2Score += score;
            scoreText.text = p1Score + " - " + p2Score;
        }
    }

    void CalculateScore(ScreenSide side, int score)
    {

    }
}
