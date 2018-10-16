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

    // spawn timer support
    Timer spawnTimer;
    bool ballSpawn = true;

    Vector3 ballCollider;
    Vector2 bottomLeftCorner;
    Vector2 topRightCorner;

    Collider2D overlapSpawn;
    
	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start()
	{
        // Gets ball colider component
        ballCollider = prefabBall.GetComponent<BoxCollider2D>().bounds.size;

        // Gets top and bottom corners of ball
        bottomLeftCorner = new Vector2(0 - ballCollider.x / 2, 0 - ballCollider.y / 2);
        topRightCorner = new Vector2(0 + ballCollider.x / 2, 0 + ballCollider.y / 2);

        // Setups up intial random spawn timer
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = Random.Range(ConfigurationUtils.MinBallSpawnTime,
            ConfigurationUtils.MaxBallSpawnTime + 1);
        spawnTimer.Run();	
	}
	
    /// <summary>
    /// Spawns a new prefab ball
    /// </summary>
    public void SpawnBall()
    {
        if (overlapSpawn != null)
        {
            ballSpawn = false;
        }
        else
        {
            Instantiate(prefabBall);
        }

    }

	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{

        overlapSpawn = Physics2D.OverlapArea(bottomLeftCorner, topRightCorner);
        if (overlapSpawn != null)
        {
            ballSpawn = false;
        }
        else
        {
            ballSpawn = true;
        }

        // Checks if finished, spawns ball, then resets spawn timer
		if (spawnTimer.Finished)
        {
            SpawnBall();
            spawnTimer.Duration = Random.Range(ConfigurationUtils.MinBallSpawnTime, 
                ConfigurationUtils.MaxBallSpawnTime + 1);
            spawnTimer.Run();
        }
	}
}
