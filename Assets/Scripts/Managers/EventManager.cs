using System;
using System.Collections.Generic;

public static class EventManager
{
    public static Dictionary<MotherEvents, Action> MotherEventsList = new Dictionary<MotherEvents, Action>();
    public static Dictionary<SonEvents, Action> SonEventsList = new Dictionary<SonEvents, Action>();

    private static Random _random;
    public static void Init()
    {
        _random = new Random();
        
        foreach (MotherEvents e in Enum.GetValues(typeof(MotherEvents)))
        {
            MotherEventsList.Add(e, new Action(Empty));
        }
        foreach (SonEvents e in Enum.GetValues(typeof(SonEvents)))
        {
            SonEventsList.Add(e, new Action(Empty));
        }
    }

    public static int Next(int limit)
    {
        return _random.Next(limit);
    }

    static void Empty()
    {
    }
}


public enum MotherEvents
{
    seekTimeout,
    fall,
    cook,
    WC,
    mirror,
    prank
}

public enum SonEvents
{
    hideTimeout,
    fall,
    prank,
    trap
}
