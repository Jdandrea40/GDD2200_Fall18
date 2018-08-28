using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A ball
/// </summary>
public class Ball : MonoBehaviour
{
    // saved for efficiency
    float ballImpulse = ConfigurationUtils.BallImpulseForce;
    Rigidbody2D rb2d;

	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start()
	{
        // gets Rigidbody2D Componenet
        rb2d = GetComponent<Rigidbody2D>();

        //transform.position = new Vector3(Random.Range(135, 225), transform.position.y, transform.position.z);
        //Vector2 direction = transform.forward;
        //direction = new Vector2(1, direction.y);
        //rb2d.AddForce(direction * ballImpulse);

        Vector2 direction = new Vector2(Random.Range(135, 225), transform.position.y);
        rb2d.AddForce(-direction * ballImpulse);

	}
	
	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
		
	}
}
