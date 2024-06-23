using System;
using UnityEngine;

public class EventsController : MonoBehaviour
{
    public static event Action <int> AddScoreEvent;
    public static event Action RestartEvent;
    public static event Action <GameObject> OnTriggerCatEvent;
    public static event Action OnTriggerWallEvent;
    public static event Action EndlevelEvent;
    public static void InvokeAddScoreEvent(int score)
    {
        AddScoreEvent?.Invoke(score);
    }
    public static void InvokeRestartEvent()
    {
        RestartEvent?.Invoke();
    }

    public static void InvokeOnTriggerCatEvent(GameObject obj)
    {
        OnTriggerCatEvent?.Invoke(obj);
    }

    public static void InvokeOnTriggerWallEvent()
    {
        OnTriggerWallEvent?.Invoke();
    }

    public static void InvokeEndLevelEvent()
    {
        EndlevelEvent?.Invoke();
    }
}

