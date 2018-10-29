using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBalls : Ball
{
    PickUpEffectsEnum pickUpEffects;

    PickUpEffects pickupCollected;

	// Use this for initialization
	void Start ()
    {
       pickupCollected = pickupCollected.GetComponent<PickUpEffects>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
