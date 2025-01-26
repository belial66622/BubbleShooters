using System;
using UnityEngine;

public static class EventsSystem
{
    public static Action<Transform> OnRegisterPlayerEvent;

    public static Action<Transform,int> OnSpawnXpEvent;

    public static Action<int,player> OnGetXpEvent;

    public static Action<int> OnTimeCountEvent;
    
    public static Action OnPausedEvent;
    public static void OnRegisterPlayer(Transform player)
    {
        OnRegisterPlayerEvent?.Invoke(player);
    }
    public static void OnPaused()
    { 
        OnPausedEvent?.Invoke();
    }
    public static void OnTimeCount(int bebek)
    { 
        OnTimeCountEvent?.Invoke(bebek);
    }

    public static void OnSpawnXp(Transform GetXp, int xp)
    {
        OnSpawnXpEvent?.Invoke(GetXp,xp);
    }

    public static void OnGetXp(int xp,player control)
    {
        OnGetXpEvent?.Invoke(xp,control);
    }
}
