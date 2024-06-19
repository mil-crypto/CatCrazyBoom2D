using System;
using UnityEngine;

public class FloorEndGame : MonoBehaviour
{
    public static event Action EndGameAction;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string colTag = collision.gameObject.tag;
        switch (colTag)
        {
            case "snow1":
                EndGameAction?.Invoke();
                break;
            case "snow2":
                EndGameAction?.Invoke();
                break;
            case "snow3":
                EndGameAction?.Invoke();
                break;
            case "snow4":
                EndGameAction?.Invoke();
                break;
            case "snow5":
                EndGameAction?.Invoke();
                break;
            case "snow6":
                EndGameAction?.Invoke();
                break;
            case "snow7":
                EndGameAction?.Invoke();
                break;
            case "snow8":
                EndGameAction?.Invoke();
                break;
            case "snow9":
                EndGameAction?.Invoke();
                break;
            case "snow10":
                EndGameAction?.Invoke();
                break;
        }
    }
}
