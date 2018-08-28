using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A paddle
/// </summary>
public class Paddle : MonoBehaviour
{
    // Saved for efficiency
    [SerializeField]
    int paddleSpeed = 5;     // Serialized to allow Inspector Changes

    Rigidbody2D rb2d;

    


    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
	{

        rb2d = gameObject.GetComponent<Rigidbody2D>();
	}

    

    void Update()
    {
        float paddleInput1 = Input.GetAxisRaw("Paddle1");

        if(paddleInput1 != 0)
        {
            Vector2 position = rb2d.position;
            position.y += paddleInput1 * paddleSpeed * Time.deltaTime;
            rb2d.MovePosition(position);
        }

    }	
}
