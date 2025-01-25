using System;
using UnityEngine;

public static class EventsSystem 
{
    public static Action<Transform> OnRegisterPlayerEvent;

    public static void OnRegisterPlayer(Transform player)
    {
        OnRegisterPlayerEvent?.Invoke(player);
    }
}
