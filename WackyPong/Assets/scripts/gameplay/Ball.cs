using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A ball
/// </summary>
public class Ball : MonoBehaviour
{
    // Ball type Serialization/Support
    [SerializeField]
    PickUpEffectsEnum ballType;
    BoxCollider2D ballCollider;
    float ballHalfWidth;
    int score;
    static int hits;
    bool speedUpActive;
     
    // saved for efficiency
    Rigidbody2D rb2d;

    // angle support
    float maxAngle;         // maximum angle allowed
    float minAngle;         // minimum angle allowed

    // Screen side support
    ScreenSide screenSide;

    // Spawner support
    BallSpawner ballSpawner;
    Vector2 direction;

    // Timer support
    Timer deathTimer;
    Timer startTimer;

    // Event Manager Support
    PointsAddedEvent pointsAddedEvent;
    BallLostEvent ballLostEvent;
    BallDiedEvent ballDiedEvent;

    #region Properties

    /// <summary>
    /// Hit property to allow hit increase in HUD
    /// </summary>
    public static int StandardBallHits
    {
        get { return ConfigurationUtils.StandardBallHit; }
    }

    /// <summary>
    /// Score property for a standard ball
    /// </summary>
    public static int StandardBallScore
    {
        get { return ConfigurationUtils.StandardBallHit; }
    }

    /// <summary>
    /// Hit property for Bonus Ball
    /// </summary>
    public static int BonusBallHits
    {
        get { return ConfigurationUtils.BonusBallHit; }
    }

    /// <summary>
    /// Score property for Bonus Ball
    /// </summary>
    public static int BonusBallScore
    {
        get { return ConfigurationUtils.BonusBallPoints; }
    }

    /// <summary>
    /// Hit property based on ball type
    /// </summary>
    public static int Hits
    {
        get { return hits; }
    }

    public static int SpeedUpActiveSpeed
    {
        get { return ConfigurationUtils.SpeedUpEffectForce; }
    }
    #endregion

    /// <summary>
    /// Use this for initialization
    /// </summary>
    public virtual void Start()
	{
        speedUpActive = false;

        // gets Rigidbody2D Componenet
        rb2d = GetComponent<Rigidbody2D>();

        // Ball Collider Support
        ballCollider = gameObject.GetComponent<BoxCollider2D>();
        ballHalfWidth = ballCollider.size.x / 2;

        // Initializes Events 
        pointsAddedEvent = new PointsAddedEvent();
        ballLostEvent = new BallLostEvent();
        ballDiedEvent = new BallDiedEvent();

        // Adds appropriate invokers to the ball
        EventManager.AddPointsAddedInvoker(this);
        EventManager.BallLostInvoker(this);
        EventManager.BallDiedInvoker(this);

        // Angle selection support
        float angleSelect = Random.value;

        // Death Timer (with invoker)
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.AddTimerFinishedListener(BallDeathTimer);
        deathTimer.Duration = ConfigurationUtils.BallLifetime;
        deathTimer.Run();

        // Start Timer (with invoker)
        startTimer = gameObject.AddComponent<Timer>();
        startTimer.AddTimerFinishedListener(BallStartTimer);
        startTimer.Duration = 1;
        startTimer.Run();

        // Gets ball spawner component
        ballSpawner = Camera.main.GetComponent<BallSpawner>();

        // Applies points and hits for Bonus Balls
        if (ballType == PickUpEffectsEnum.BonusBall)
        {
            score = BonusBallScore;
            hits = BonusBallHits;
        }

        // If not a Bonus Ball, Standard points are issued
        else if (ballType == PickUpEffectsEnum.StandardBall)
        {
            score = StandardBallScore;
            hits = StandardBallHits;
        }

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
    /// Ball Death timer Event Method
    /// </summary>
    public virtual void BallDeathTimer()
    {
        Destroy(gameObject);
        ballDiedEvent.Invoke();
    }

    #region Events
    /// <summary>
    /// Ball start event method
    /// </summary>
    void BallStartTimer()
    {
        if (ballType != PickUpEffectsEnum.SpeedUpEffect && speedUpActive == false)
        {
            rb2d.AddForce(direction * ConfigurationUtils.BallImpulseForce, ForceMode2D.Impulse);
        }
    }

    /// <summary>
    /// Adds listener to increment score to appropriate side
    /// </summary>
    public void AddPointsAddedListener(UnityAction<ScreenSide, int> listener)
    {
        pointsAddedEvent.AddListener(listener);
    }
    /// <summary>
    /// listener for lost ball
    /// </summary>
    /// <param name="listener"></param>
    public void AddBallLostListener(UnityAction listener)
    {
        ballLostEvent.AddListener(listener);
    }

    /// <summary>
    /// listener for dead ball
    /// </summary>
    /// <param name="listener"></param>
    public void AddBallDiedListener(UnityAction listener)
    {
        ballDiedEvent.AddListener(listener);
    }
    #endregion

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
        if (transform.position.x + ballHalfWidth < ScreenUtils.ScreenLeft ||
            transform.position.x + ballHalfWidth > ScreenUtils.ScreenRight)
        {
            // Checks for screen side to apply appropriate scoring
            // Ball goes off Right --- Scores + for Left
            if (transform.position.x > 0)
            {
                pointsAddedEvent.Invoke(ScreenSide.Left, score);
                ballLostEvent.Invoke();
                deathTimer.Stop();
            }
            // Ball goes off Left --- Score + for Right
            else if (transform.position.x < 0)
            {
                pointsAddedEvent.Invoke(ScreenSide.Right, score);
                ballLostEvent.Invoke();
                deathTimer.Stop();
            }
            Destroy(gameObject);
        }
    }
}
