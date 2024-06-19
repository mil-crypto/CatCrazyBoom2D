using System;
using UnityEngine;

public class EventsController : MonoBehaviour
{
    public static event Action <int> AddScoreEvent;
    public static event Action CreatePrefEvent;
    public static event Action ExploseEvent;
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
}
