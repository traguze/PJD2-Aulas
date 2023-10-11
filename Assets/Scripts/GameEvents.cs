using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class FloatEvent : UnityEvent<float> { }
[System.Serializable]
public class IntFloatEvent : UnityEvent<int,float> { }
[System.Serializable]
public class BoolEvent : UnityEvent<bool> { }
public static class GameEvents
{
    public static UnityEvent OnGenericEvent = new UnityEvent();

    public static FloatEvent OnElapsedTime = new FloatEvent();
}
