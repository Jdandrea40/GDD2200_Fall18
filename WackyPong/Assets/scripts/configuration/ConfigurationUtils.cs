using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    #region Fields

    static ConfigurationData configurationData;
    
    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return configurationData.PaddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the standard ball hit amount
    /// </summary>
    public static float BallImpulseForce
    {
        get { return configurationData.BallImpulseForce; }
    }
    /// <summary>
    /// Gets the standard ball hit amount
    /// </summary>
    public static int StandardBallHit
    {
        get { return configurationData.StandardBallHit; }
    }

    /// <summary>
    /// Gets Bonus Ball hit amount
    /// </summary>
    public static int BonusBallHit
    {
        get { return configurationData.BonusBallHit; }
    }

    /// <summary>
    /// Gets bonus ball points amount
    /// </summary>
    public static int BonusBallPoints
    {
        get { return configurationData.BonusBallPoints; }
    }

    /// <summary>
    /// Gets the Ball Lifetime Amount
    /// </summary>
    public static float BallLifetime
    {
        get { return configurationData.BallLifeTime; }
    }

    /// <summary>
    /// Gets minimum spawn time
    /// </summary>
    public static float MinBallSpawnTime
    {
        get { return configurationData.MinBallSpawnTime; }
    }

    /// <summary>
    /// Gets maximum spawn time
    /// </summary>
    public static float MaxBallSpawnTime
    {
        get { return configurationData.MaxBallSpawnTime; }
    }

    /// <summary>
    /// Gets Standard Ball Spawn Rate
    /// </summary>
    public static float StandardBallSpawnRate
    {
        get { return configurationData.StandardBallSpawnRate; }
    }
    /// <summary>
    /// Gets Bonus Ball Spawn Rate
    /// </summary>
    public static float BonusBallSpawnRate
    {
        get { return configurationData.BonusBallSpawnRate; }
    }
    /// <summary>
    /// Gets PickUp Effect Spawn Rate
    /// </summary>
    public static float PickUpEffectSpawnRate
    {
        get { return configurationData.PickUpEffectSpawnRate; }
    }
    #endregion

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        configurationData = new ConfigurationData();
    }
}
