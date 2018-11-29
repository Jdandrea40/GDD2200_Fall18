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
    static List<Ball> ballDiedInvoker = new List<Ball>();
    static List<UnityAction> ballDiedListener = new List<UnityAction>();

    // Invoker/Listener suppport for the balls Hits Added Event
    static List<Paddle> hitsAddedInvoker = new List<Paddle>();
    static List<UnityAction<ScreenSide, int>> hitsAddedListener = new List<UnityAction<ScreenSide, int>>();

    // Invoker/Listener suppport for the Finishing timer
    static Timer timerFinishedInvoker;
    static UnityAction timerFinishedListener;

    static List<PickUpEffects> freezerEffectInvoker = new List<PickUpEffects>();
    static List<UnityAction<ScreenSide, float>> freezerEffectListener = new List<UnityAction<ScreenSide, float>>();

    static List<PickUpEffects> speedUpEffectInvoker = new List<PickUpEffects>();
    static List<UnityAction<float, int>> speedUpEffectListener = new List<UnityAction<float, int>>();

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
    public static void AddHitsInvoker(Paddle invoker)
    {
        hitsAddedInvoker.Add(invoker);
        foreach (UnityAction<ScreenSide, int> listener in hitsAddedListener)
        {
            invoker.AddHitsAddedListener(listener);
        }
    }

    /// <summary>
    /// Listener method for hit total calculations
    /// </summary>
    /// <param name="listener"></param>
    public static void AddHitsListener(UnityAction<ScreenSide, int> listener)
    {
        hitsAddedListener.Add(listener);
        foreach (Paddle invoker in hitsAddedInvoker)
        {
            invoker.AddHitsAddedListener(listener);
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
        ballDiedInvoker.Add(invoker);
        foreach (UnityAction listener in ballDiedListener)
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
        ballDiedListener.Add(listener);
        foreach (Ball invoker in ballDiedInvoker)
        {
            invoker.AddBallDiedListener(listener);
        }
    }

    /// <summary>
    /// Freezer Effect Invoker
    /// </summary>
    /// <param name="invoker"></param>
    public static void FreezerEffectInvoker(PickUpEffects invoker)
    {
        freezerEffectInvoker.Add(invoker);
        foreach (UnityAction<ScreenSide, float> listener in freezerEffectListener)
        {
            invoker.AddFreezerEffectActivatedListener(listener);
        }
    }

    /// <summary>
    /// Freezer effect Listeners
    /// </summary>
    /// <param name="listener"></param>
    public static void FreezerEffectListener(UnityAction<ScreenSide, float> listener)
    {
        freezerEffectListener.Add(listener);
        foreach (PickUpEffects invoker in freezerEffectInvoker)
        {
            invoker.AddFreezerEffectActivatedListener(listener);
        }
    }

    /// <summary>
    /// SpeedUp Effect Invokers
    /// </summary>
    /// <param name="invoker"></param>
    public static void SpeedEffectInvoker(PickUpEffects invoker)
    {
        speedUpEffectInvoker.Add(invoker);
        foreach (UnityAction<float, int> listener in speedUpEffectListener)
        {
            invoker.AddSpeedEffectActiveListener(listener);
        }
    }

    /// <summary>
    /// SpeedUp Effect Listeners
    /// </summary>
    /// <param name="listener"></param>
    public static void SpeedUpEffectListener(UnityAction<float, int> listener)
    {
        speedUpEffectListener.Add(listener);
        foreach(PickUpEffects invoker in speedUpEffectInvoker)
        {
            invoker.AddSpeedEffectActiveListener(listener);
        }
    }
}
