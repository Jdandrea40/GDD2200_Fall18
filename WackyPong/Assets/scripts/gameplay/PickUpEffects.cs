using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickUpEffects : Ball
{
    protected PickUpEffectsEnum ballType;
    float freezeDuration;

    FreezerEffectsActivatedEvent freezerEffectActivated;
    SpeedUpEffectActiveEvent speedUpEffectActiveEvent;

    protected BallDiedEvent ballDiedEvent;

    // Used for intitalizing the parent Start method
    public override void Start()
    {
        base.Start();
        // Applies the freeze duration to freezer effect
        if (ballType == PickUpEffectsEnum.FreezerEffect )
        {
            freezeDuration = ConfigurationUtils.FreezerEffectDuration;
        }


        freezerEffectActivated = new FreezerEffectsActivatedEvent();
        speedUpEffectActiveEvent = new SpeedUpEffectActiveEvent();
        ballDiedEvent = new BallDiedEvent();

        EventManager.FreezerEffectInvoker(this);
        EventManager.BallDiedInvoker(this);
    }

    /// <summary>
    /// Freezer Effect Listener Creation
    /// </summary>
    /// <param name="listener"></param>
    public void AddFreezerEffectActivatedListener(UnityAction<ScreenSide, float> listener)
    {
        freezerEffectActivated.AddListener(listener);
    }

    /// <summary>
    /// SpeedUp Effect Listener Creation
    /// </summary>
    /// <param name="listener"></param>
    public void AddSpeedEffectActiveListener(UnityAction<int> listener)
    {
        speedUpEffectActiveEvent.AddListener(listener);
    }
    //public void AddBallDiedListener(UnityAction listener)
    //{
    //    ballDiedEvent.AddListener(listener);
    //}



    // Update is called once per frame
    void Update () {
		
	}

    /// <summary>
    /// PickUp collison checking method
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("RightPaddle"))
        {
            freezerEffectActivated.Invoke(ScreenSide.Right, freezeDuration);
            Destroy(gameObject);
            ballDiedEvent.Invoke();

        }
        else if (collision.gameObject.CompareTag("LeftPaddle"))
        {
            freezerEffectActivated.Invoke(ScreenSide.Left, freezeDuration);
            Destroy(gameObject);
            ballDiedEvent.Invoke();
        }
       
    }


}
