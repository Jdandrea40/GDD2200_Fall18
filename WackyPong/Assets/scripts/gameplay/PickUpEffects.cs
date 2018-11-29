using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickUpEffects : Ball
{
    // PickUp Support
    protected PickUpEffectsEnum ballType;
    float freezeDuration;
    int speedUpEffectSpeed;
    float speedUpDuration;

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
        if (ballType == PickUpEffectsEnum.SpeedUpEffect)
        {
            speedUpEffectSpeed = ConfigurationUtils.SpeedUpEffectForce;
        }

        // Event manager support
        freezerEffectActivated = new FreezerEffectsActivatedEvent();
        speedUpEffectActiveEvent = new SpeedUpEffectActiveEvent();
        ballDiedEvent = new BallDiedEvent();

        // makes this class an invoker of following event
        EventManager.FreezerEffectInvoker(this);
        //EventManager.BallDiedInvoker(this);
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
    public void AddSpeedEffectActiveListener(UnityAction<float, int> listener)
    {
        speedUpEffectActiveEvent.AddListener(listener);
    }

    /// <summary>
    /// PickUp collison checking method
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Checks for specific pick up ball types and then invokes for Right Paddle
        if (collision.gameObject.CompareTag("RightPaddle"))
        {
            // Freezer Effect (Right Side)
            //if (collision.gameObject.CompareTag("FreezeEffect"))
            if(ballType == PickUpEffectsEnum.FreezerEffect)
            {
                freezerEffectActivated.Invoke(ScreenSide.Right, freezeDuration);
                ballDiedEvent.Invoke();
            }
            // Speed Up Effect
            //if (collision.gameObject.CompareTag("SpeedUpEffect"))
            if (ballType == PickUpEffectsEnum.SpeedUpEffect)
            {
                //speedUpEffectActiveEvent.Invoke(speedUpDuration, speedUpEffectSpeed);
                SpeedUpActive(speedUpDuration, speedUpEffectSpeed);
                ballDiedEvent.Invoke();
                Destroy(gameObject);
            }
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("LeftPaddle"))
        {
            // Freezer Effect (Left Side)
            //if (collision.gameObject.CompareTag("FreezeEffect"))
            if (ballType == PickUpEffectsEnum.FreezerEffect)
            {
                freezerEffectActivated.Invoke(ScreenSide.Left, freezeDuration);
                ballDiedEvent.Invoke();
            }
            // Speed Up Effect
            //if (collision.gameObject.CompareTag("SpeedUpEffect"))
            if (ballType == PickUpEffectsEnum.SpeedUpEffect)
            {
                //speedUpEffectActiveEvent.Invoke(speedUpDuration, speedUpEffectSpeed);
                SpeedUpActive(speedUpDuration, speedUpEffectSpeed);
                ballDiedEvent.Invoke();
                Destroy(gameObject);
            }
            Destroy(gameObject);
        }

    }


}
