using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A ball
/// </summary>
public class Ball : MonoBehaviour
{
    // saved for efficiency
    Rigidbody2D rb2d;

    // Timer support
    Timer deathTimer;
    Timer startTimer;

    // angle support
    float maxAngle;         // maximum angle allowed
    float minAngle;         // minimum angle allowed

    // Screen side support
    ScreenSide screenSide;

    BallSpawner ballSpawner;
    Vector2 direction;

    #region Properties
    /// <summary>
    /// Hit property to allow hit increase in HUD
    /// </summary>
    public static int Hits
    {
        get { return ConfigurationUtils.StandardBallHit; }
    }

    /// <summary>
    /// Score property for a standard ball
    /// </summary>
    public static int Score
    {
        get { return ConfigurationUtils.StandardBallHit; }
    }
    #endregion

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
	{
        // gets Rigidbody2D Componenet
        rb2d = GetComponent<Rigidbody2D>();
        
        // Angle selection support
        float angleSelect = Random.value;

        // Death Timer
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = ConfigurationUtils.BallLifetime;
        deathTimer.Run();

        // Start Timer
        startTimer = gameObject.AddComponent<Timer>();
        startTimer.Duration = 1;
        startTimer.Run();

        // Gets ball spawner component
        ballSpawner = Camera.main.GetComponent<BallSpawner>();
        

        // Sets min and max angle off of Random.Range
        if (angleSelect < 0.5f)
        {
            // sets left side angle to radians
            minAngle = 135 * Mathf.Deg2Rad;
            maxAngle = 225 * Mathf.Deg2Rad;
        }
        else
        {
            // sets right side angle to radians
            minAngle = -45f * Mathf.Deg2Rad;
            maxAngle = 45f * Mathf.Deg2Rad;
        }

        // randomly selects from the min and max angles
        float angle = Random.Range(minAngle, maxAngle);

        // sets new direction
        direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
    }
	
	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
        // End of DeathTimer Support
        if (deathTimer.Finished)
        {
            ballSpawner.SpawnBall();
            Destroy(gameObject);
        }
        if (startTimer.Finished)
        {
            // stops timer
            startTimer.Stop();
            /// Adds a force and direction to the ball
            rb2d.AddForce(direction * ConfigurationUtils.BallImpulseForce, ForceMode2D.Impulse);
        }
    }

    /// <summary>
    /// Sets Ball Direction
    /// </summary>
    /// <param name="direction"></param>
    public void SetDirection(Vector2 direction)
    {
        Vector2 velocity = rb2d.velocity.magnitude * direction;
        rb2d.velocity = velocity;

    }

    /// <summary>
    /// Destroys ball when offscreen
    /// </summary>
    private void OnBecameInvisible()
    {
        // Regulates scoring
        if (gameObject.transform.position.x > ScreenUtils.ScreenLeft && !deathTimer.Finished)
        {
            HUD.AddScore(ScreenSide.Right, Ball.Score);
        }
        else if (gameObject.transform.position.x < ScreenUtils.ScreenRight && !deathTimer.Finished)
        {
            HUD.AddScore(ScreenSide.Left, Ball.Score);
        }
        // Destroys ball if outside screen bounds
        if (gameObject.transform.position.x > ScreenUtils.ScreenLeft || 
            gameObject.transform.position.x < ScreenUtils.ScreenRight)
        {
            // checks for whether death timer is 
            // reason for destruction
            if (!deathTimer.Finished)
            {
                ballSpawner.SpawnBall();
                deathTimer.Stop();
            }
        }
        Destroy(gameObject);
    }
}
