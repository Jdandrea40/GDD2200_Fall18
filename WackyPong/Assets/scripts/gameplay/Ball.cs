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

    float maxAngle;         // maximum angle allowed
    float minAngle;         // minimum angle allowed
    
	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start()
	{
        // gets Rigidbody2D Componenet
        rb2d = GetComponent<Rigidbody2D>();

        // Angle selection support
        float angleSelect = Random.value;
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
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        /// Adds a force and direction to the ball
        rb2d.AddForce(direction * ConfigurationUtils.BallImpulseForce, ForceMode2D.Impulse);
    }
	
	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
		
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
        Destroy(gameObject);
    }
}
