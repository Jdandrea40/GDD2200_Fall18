using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A ball spawner
/// </summary>
public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabBall;

	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start()
	{       
		
	}
	
    /// <summary>
    /// Spawns a new prefab ball
    /// </summary>
    public void SpawnBall()
    {
        Instantiate(prefabBall);

    }
	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
		
	}
}
