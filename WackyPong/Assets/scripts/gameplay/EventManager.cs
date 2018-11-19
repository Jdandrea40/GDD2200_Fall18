using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Class used to manage invokers and listeners throughout code
/// </summary>
public static class EventManager
{
    // Invoker/Listener suppport for the balls Point Added Event
    static List<Ball> pointsAddedInvoker = new List<Ball>();
    static List<UnityAction<ScreenSide, int>> pointsAddedListener = new List<UnityAction<ScreenSide, int>>();

    // Invoker/Listener suppport for the off screen balls
    static Ball ballLostInvoker;
    static UnityAction ballLostListener;

    // Invoker/Listener suppport for death timer 
    static Ball ballDiedInvoker;
    static UnityAction ballDiedListener;

    // Invoker/Listener suppport for the balls Hits Added Event
    static Paddle hitsAddedInvoker;
    static UnityAction<ScreenSide, int> hitsAddedListener;

    // Invoker/Listener suppport for the Finishing timer
    static Timer timerFinishedInvoker;
    static UnityAction timerFinishedListener;

    /// <summary>
    /// Invoker method added for Scoring
    /// </summary>
    /// <param name="invoker"></param>
    public static void AddPointsAddedInvoker(Ball invoker)
    {

        pointsAddedInvoker.Add(invoker);
        foreach(UnityAction<ScreenSide, int> listener in pointsAddedListener)
        {
            invoker.AddPointsAddedListener(listener);
        }
    }

    /// <summary>
    /// Listener method for scoring
    /// </summary>
    /// <param name="listener"></param>
    public static void AddPointsAddedListener(UnityAction<ScreenSide, int> listener)
    {

        pointsAddedListener.Add(listener);
        foreach(Ball invoker in pointsAddedInvoker)
        {
            invoker.AddPointsAddedListener(listener);
        }
    }

    /// <summary>
    /// Invoker method for hit total calculations
    /// </summary>
    /// <param name="invoker"></param>
    public static void AddPointsInvoker(Paddle invoker)
    {
        hitsAddedInvoker = invoker;
        if (hitsAddedListener != null)
        {
            invoker.AddHitsAddedListener(hitsAddedListener);
        }
    }

    /// <summary>
    /// Listener method for hit total calculations
    /// </summary>
    /// <param name="listener"></param>
    public static void AddHitsListener(UnityAction<ScreenSide, int> listener)
    {
        hitsAddedListener = listener;
        if (hitsAddedInvoker != null)
        {
            hitsAddedInvoker.AddHitsAddedListener(listener);
        }
    }

    /// <summary>
    /// Invoker method for lost balls
    /// </summary>
    /// <param name="invoker"></param>
    public static void BallLostInvoker(Ball invoker)
    {
        ballLostInvoker = invoker;
        if (ballLostListener != null)
        {
            invoker.AddBallLostListener(ballLostListener);
        }
    }

    /// <summary>
    /// Listener method for lost balls
    /// </summary>
    /// <param name="listener"></param>
    public static void BallLostListener(UnityAction listener)
    {
        ballLostListener = listener;
        if (ballLostInvoker != null)
        {
            ballLostInvoker.AddBallLostListener(listener);
        }
    }


    /// <summary>
    /// Invoker method for dead balls
    /// </summary>
    /// <param name="invoker"></param>
    public static void BallDiedInvoker(Ball invoker)
    {
        ballDiedInvoker = invoker;
        if (ballDiedListener != null)
        {
            invoker.AddBallDiedListener(ballLostListener);
        }
    }

    /// <summary>
    /// Listener method dead balls
    /// </summary>
    /// <param name="listener"></param>
    public static void BallDiedListener(UnityAction listener)
    {
        ballDiedListener = listener;
        if (ballDiedInvoker != null)
        {
            ballLostInvoker.AddBallDiedListener(listener);
        }
    }
}
