﻿using System.Collections;
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
    /// Gets the Ball Lifetime Amount
    /// </summary>
    public static float BallLifetime
    {
        get { return configurationData.BallLifeTime; }
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
