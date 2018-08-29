using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A paddle
/// </summary>
public class Paddle : MonoBehaviour
{
    // Saved for efficiency
    float paddleSpeed = ConfigurationUtils.PaddleMoveUnitsPerSecond;
    Rigidbody2D rb2d;

    // Gets Enumeration
    [SerializeField]
    ScreenSide screenSide;

    // Box Collider Support
    BoxCollider2D bc2d;
    float halfHeight;

    const float BounceAngleHalfRange = 60 * Mathf.Deg2Rad;      // const value saved for paddle bounce


    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
	{
        // Gets Rigidbody2D compnent
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        
        //Gets BoxCollider2D component
        bc2d = GetComponent<BoxCollider2D>();

        // Get half bc2d height
        halfHeight = bc2d.size.y / 2; 
	}
    
    /// <summary>
    /// Called 50 times per second
    /// </summary>
    void FixedUpdate()
    {
        // saved for efficiency
        float leftPaddleInput = Input.GetAxisRaw("LeftPaddle");
        float rightPaddleInput = Input.GetAxisRaw("RightPaddle");

        // Handles input and movement of Left Paddle
        if(leftPaddleInput != 0 && gameObject.CompareTag("LeftPaddle"))
        {
            Vector2 position = rb2d.position;
            position.y += leftPaddleInput * paddleSpeed * Time.deltaTime;
            position.y = CalculateClampedY(position.y);

            rb2d.MovePosition(position);
        }

        // Handles input and movement of Right Paddle
        if(rightPaddleInput != 0 && gameObject.CompareTag("RightPaddle"))
        {
            Vector2 position = rb2d.position;
            position.y += rightPaddleInput * paddleSpeed * Time.deltaTime;
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
        if (y + halfHeight > ScreenUtils.ScreenTop)
        {
            y = ScreenUtils.ScreenTop - halfHeight;
        }
        // sets Bottom Screen Bounds
        if (y - halfHeight < ScreenUtils.ScreenBottom)
        {
            y = ScreenUtils.ScreenBottom + halfHeight;
        }
        return y;
    }

    /// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball"))
        {
            // calculate new ball direction
            float ballOffsetFromPaddleCenter =
                coll.transform.position.y - transform.position.y;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                halfHeight;
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

            // tell ball to set direction to new direction
            Ball ballScript = coll.gameObject.GetComponent<Ball>();
            ballScript.SetDirection(direction);
        }
    }
}
