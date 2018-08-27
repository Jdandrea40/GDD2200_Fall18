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

    

    void FixedUpdate()
    {
        if(Input.GetAxisRaw("Paddle1") != 0)
        {
            transform.Translate(new Vector3(0, Input.GetAxisRaw("Paddle1") * paddleSpeed * Time.deltaTime, 0));
            Debug.Log("Input registered");
        }
        else
        {
            paddleSpeed = 0;
        }
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
	{
		
	}
	
}
