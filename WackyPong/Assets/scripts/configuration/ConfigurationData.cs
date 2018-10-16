using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationDataAssets.csv";

    // configuration data
    static float paddleMoveUnitsPerSecond = 10;
    static float ballImpulseForce = 5;
    static int standardBallHit = 1;
    static float ballLifeTime = 10;
    static float minBallSpawnTime = 5;
    static float maxBallSpawnTime = 10;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }
    }

    /// <summary>
    /// Gets the standard ball hit amount
    /// </summary>
    /// <value>standard ball hit</value>
    public int StandardBallHit
    {
        get { return standardBallHit; }
    }

    /// <summary>
    /// Gets the ball Lifetime
    /// </summary>
    /// <value>ball lifetime</value>
    public float BallLifeTime
    {
        get { return ballLifeTime; }
    }

    /// <summary>
    /// Gets Minimum Ball Spawn Rates
    /// </summary>
    /// <value>min spawn time</value>
    public float MinBallSpawnTime
    {
        get { return minBallSpawnTime; }
    }

    /// <summary>
    /// Gets Maximum Ball Spawn Rates
    /// </summary>
    /// <value>max spawn time</value>
    public float MaxBallSpawnTime
    {
        get { return maxBallSpawnTime; }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        // Sets Reader to null 
        StreamReader input = null;

        // Tries to Open File if available
        try
        {
            // the file that will be opened
            input = File.OpenText(Path.Combine(
                Application.streamingAssetsPath, ConfigurationDataFileName));

            // Stores taken values
            string names = input.ReadLine();
            string values = input.ReadLine();

            // Sets approprite values to be used
            SetConfigData(values);

            
        }
        // Catches if try fails
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        // closes file
        finally
        {
            if (input != null)
            {
                input.Close();
            }
        }
    }
    
    /// <summary>
    /// Method for spliting csv file values
    /// </summary>
    /// <param name="csvValues"></param>
    void SetConfigData (string csvValues)
    {
        // splits "values"
        string[] values = csvValues.Split(',');

        // Parses strings to approprite data types
        ballImpulseForce = float.Parse(values[0]);
        paddleMoveUnitsPerSecond = float.Parse(values[1]);
        standardBallHit = int.Parse(values[2]);
        ballLifeTime = float.Parse(values[3]);
        minBallSpawnTime = float.Parse(values[4]);
        maxBallSpawnTime = float.Parse(values[5]);

    }

    #endregion
}
