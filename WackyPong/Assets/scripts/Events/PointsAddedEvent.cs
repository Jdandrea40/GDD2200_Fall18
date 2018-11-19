using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Event for adding score to appropriate side
/// </summary>
public class PointsAddedEvent : UnityEvent<ScreenSide, int>
{

}
