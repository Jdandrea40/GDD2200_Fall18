using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A ball spawner
/// </summary>
public class BallSpawner : MonoBehaviour
{
    // Prefabs stored for specific ball spawning
    [SerializeField]
    GameObject standardBall;
    [SerializeField]
    GameObject bonusBall;
    [SerializeField]
    GameObject freezerEffect;
    [SerializeField]
    GameObject speedUpEffect;


    // spawn timer support
    Timer spawnTimer;
    bool ballSpawn = true;

    // Support for Free spawing
    Vector3 ballCollider;
    Vector2 bottomLeftCorner;
    Vector2 topRightCorner;
    Collider2D overlapSpawn;            // Collider support for free spawn
    
	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start()
	{
        // Gets ball colider component
        ballCollider = standardBall.GetComponent<BoxCollider2D>().bounds.size;

        // Gets top and bottom corners of ball
        bottomLeftCorner = new Vector2(0 - ballCollider.x / 2, 0 - ballCollider.y / 2);
        topRightCorner = new Vector2(0 + ballCollider.x / 2, 0 + ballCollider.y / 2);

        // Setups up intial random spawn timer (with listener)
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.AddTimerFinishedListener(SpawnTimerFinished);
        spawnTimer.Duration = Random.Range(ConfigurationUtils.MinBallSpawnTime,
            ConfigurationUtils.MaxBallSpawnTime + 1);
        spawnTimer.Run();

        // Adds Listener for Private Ball Spawning method
        EventManager.BallDiedListener(SpawnBall);
        EventManager.BallLostListener(SpawnBall);
	}
	
    /// <summary>
    /// Spawns a new prefab ball in collision free zone
    /// </summary>
    private void SpawnBall()
    {
        // Overlapping spawn check
        if (overlapSpawn != null)
        {
            ballSpawn = false;
        }
        else
        {
            // spawns pickup effects 20% of the time
            if (Random.value > ConfigurationUtils.PickUpEffectSpawnRate)
            {
                // 50% chance to spawn either SpeedUp or Freezer Effects
                // (original 20% = 10% for each)
                int pickUpType = Random.Range(0, 2);
                if (pickUpType < .5)
                {
                    Instantiate(freezerEffect);
                }
                else
                {
                    Instantiate(speedUpEffect);
                }
            }
            // spawns bonus balls 20% of the time
            else if (Random.value > ConfigurationUtils.BonusBallSpawnRate)
            {
                Instantiate(bonusBall);
            }
            // spawns standard balls 60% of the time
            else
            {
                Instantiate(standardBall);
            }
            
        }

    }

    /// <summary>
    /// Spawn timer finshed event method
    /// </summary>
    void SpawnTimerFinished()
    {
        SpawnBall();
        spawnTimer.Duration = Random.Range(ConfigurationUtils.MinBallSpawnTime,
            ConfigurationUtils.MaxBallSpawnTime + 1);
        spawnTimer.Run();

    }
	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
        // Checks for free space during spawning
        overlapSpawn = Physics2D.OverlapArea(bottomLeftCorner, topRightCorner);
        if (overlapSpawn != null)
        {
            ballSpawn = false;
        }
        else
        {
            ballSpawn = true;
        }
	}
}
