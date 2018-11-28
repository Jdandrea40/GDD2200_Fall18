using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A paddle
/// </summary>
public class Paddle : MonoBehaviour
{
    // Saved for efficiency
    Rigidbody2D rb2d;

    // Gets Enumeration
    [SerializeField]
    ScreenSide screenSide;

    // Box Collider Support
    BoxCollider2D bc2d;
    float colliderHalfHeight;
    float colliderHalfWidth;

    Timer freezeTimer;
    float freezeDuration;
    bool isFrozen;

    const float BounceAngleHalfRange = 60 * Mathf.Deg2Rad;      // const value saved for paddle bounce

    BoxCollider2D ballColl;                                     // ball collider support

    HitsAddedEvent hitsAddedEvent;                              // Event Manager Support
    BallDiedEvent ballDiedEvent;
    FreezerEffectsActivated freezerEffectsActivatedEvent;

    //public void AddFreezerEffectActivatedListener(UnityAction<ScreenSide, float> listener)
    //{
    //    freezerEffectsActivatedEvent.AddListener(listener);
    //}
    // Adds a listener to the paddle for Hits Calculations
    public void AddHitsAddedListener(UnityAction<ScreenSide, int> listener)
    {
        hitsAddedEvent.AddListener(listener);
    }
    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        // Gets Rigidbody2D compnent
        rb2d = gameObject.GetComponent<Rigidbody2D>();

        // Gets BoxCollider2D component
        bc2d = GetComponent<BoxCollider2D>();

        // Get half bc2d height
        colliderHalfHeight = bc2d.size.y / 2;
        colliderHalfWidth = bc2d.size.x / 2;

        freezeDuration = ConfigurationUtils.FreezerEffectDuration;
        freezeTimer = gameObject.AddComponent<Timer>();
        freezeTimer.Duration = freezeDuration * Time.deltaTime;
        isFrozen = false;

        // Support for event manager system
        hitsAddedEvent = new HitsAddedEvent();
        ballDiedEvent = new BallDiedEvent();

        EventManager.AddPointsInvoker(this);
        EventManager.FreezerEffectListener(FreezePaddle);
    }

    /// <summary>
    /// Called 50 times per second
    /// </summary>
    void FixedUpdate()
    {
        if (freezeTimer.Finished)
        {
            isFrozen = false;
        }
        // saved for efficiency
        float leftPaddleInput = Input.GetAxisRaw("LeftPaddle");
        float rightPaddleInput = Input.GetAxisRaw("RightPaddle");

        // Handles input and movement of Left Paddle
        if (leftPaddleInput != 0 && gameObject.CompareTag("LeftPaddle") && isFrozen == false)
        {
            Vector2 position = rb2d.position;
            position.y += leftPaddleInput * ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.deltaTime;
            position.y = CalculateClampedY(position.y);

            rb2d.MovePosition(position);
        }

        // Handles input and movement of Right Paddle
        if (rightPaddleInput != 0 && gameObject.CompareTag("RightPaddle") && isFrozen == false)
        {
            Vector2 position = rb2d.position;
            position.y += rightPaddleInput * ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.deltaTime;
            position.y = CalculateClampedY(position.y);

            rb2d.MovePosition(position);
        }
    }

    /// <summary>
    /// Keeps paddle in playfield by calculating new y position
    /// </summary>
    /// <param name="y"></param>
    /// <returns></returns>
    float CalculateClampedY(float y)
    {
        // sets Top Screen Bounds
        if (y + colliderHalfHeight > ScreenUtils.ScreenTop)
        {
            y = ScreenUtils.ScreenTop - colliderHalfHeight;
        }
        // sets Bottom Screen Bounds
        if (y - colliderHalfHeight < ScreenUtils.ScreenBottom)
        {
            y = ScreenUtils.ScreenBottom + colliderHalfHeight;
        }
        return y;
    }

    /// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.CompareTag("Ball") && FrontHitCollision(coll)) 
        {
            
            // calculate new ball direction
            float ballOffsetFromPaddleCenter =
                coll.transform.position.y - transform.position.y;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                colliderHalfHeight;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;

            // angle modification is based on screen side
            float angle;
            if (screenSide == ScreenSide.Left)
            {
                angle = angleOffset;
            }           
            else
            {
                angle = (float)(Mathf.PI - angleOffset);
            }
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            
            // Adds hits score to appropriate player side
            hitsAddedEvent.Invoke(screenSide, Ball.Hits);

            // tell ball to set direction to new direction
            Ball ballScript = coll.gameObject.GetComponent<Ball>();
            ballScript.SetDirection(direction);
        }

        // checks for a pickup collision
        if (coll.gameObject.CompareTag("PickUp"))
        {
            FreezePaddle(screenSide, freezeDuration);
        }
    }



    /// <summary>
    /// Checks for a proper Front Collision
    /// </summary>
    /// <param name="coll"></param>
    /// <returns></returns>
    bool FrontHitCollision(Collision2D coll)
    {
        // Tolerance allowed for proper collision
        const float tolerance = 0.05f;

        // Gets the contact points of the ball
        ContactPoint2D contactPoint1 = coll.GetContact(0);
        ContactPoint2D contactPoint2 = coll.GetContact(1);

        // returns the value on collison
        return Mathf.Abs(contactPoint1.point.x - contactPoint2.point.x) < tolerance;
    }

    /// <summary>
    /// Freeze paddle method
    /// </summary>
    /// <param name="side"></param>
    /// <param name="freezeDuration"></param>
    void FreezePaddle(ScreenSide side, float freezeDuration)
    {
        if (isFrozen == false)
        {
            freezeTimer.Duration = freezeDuration;
        }
        else
        {
            freezeTimer.Duration = freezeTimer.Duration + freezeDuration;
        }

        freezeTimer.Run();
        isFrozen = true;

    }
}
