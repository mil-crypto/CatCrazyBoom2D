using System;
using UnityEngine;
public class EventsController : MonoBehaviour
{
    public static event Action RestartEvent;
    public static event Action <GameObject> OnTriggerCatEvent;
    public static event Action <GameObject> OnTriggerWallEvent;
    public static event Action EndlevelEvent;
    public static event Action <Boolean> SoundsButtonPressedEvent;
    public static void InvokeRestartEvent()
    {
        RestartEvent?.Invoke();
    }

    public static void InvokeOnTriggerCatEvent(GameObject obj)
    {
        OnTriggerCatEvent?.Invoke(obj);
    }

    public static void InvokeOnTriggerWallEvent(GameObject obj)
    {
        OnTriggerWallEvent?.Invoke(obj);
    }

    public static void InvokeEndLevelEvent()
    {
        EndlevelEvent?.Invoke();
    }

    public static void InvokeSoundsButtonPressedEvent(Boolean sound)
    {
        SoundsButtonPressedEvent?.Invoke(sound);
    }
}

