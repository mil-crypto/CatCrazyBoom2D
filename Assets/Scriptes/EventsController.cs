using System;
using UnityEngine;

public class EventsController : MonoBehaviour
{
    public static event Action <int> AddScoreEvent;
    public static event Action CreatePrefEvent;
    public static event Action ExploseEvent;
    public static event Action RestartEvent;
    public static event Action <Vector2> OnTriggerCatEvent;
    public static event Action OnTriggerWallEvent;
    public static void InvokeAddScoreEvent(int score)
    {
        AddScoreEvent?.Invoke(score);
    }
    public static void InokeCreatePrefEvent()
    {
        CreatePrefEvent?.Invoke();
    }

    public static void InvokeExploseEvent()
    {
        ExploseEvent?.Invoke();
    }

    public static void InvokeRestartEvent()
    {
        RestartEvent?.Invoke();
    }

    public static void InvokeOnTriggerCatEvent(Vector2 catPos)
    {
        OnTriggerCatEvent?.Invoke(catPos);
    }

    public static void InvokeOnTriggerWallEvent()
    {
        OnTriggerWallEvent?.Invoke();
    }
}

