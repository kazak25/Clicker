using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using EventBase = SimpleEventBus.Events.EventBase;

public class GetProfitEvent : EventBase
{
    public int _profit { get; }

    public GetProfitEvent(int profit)
    {
        _profit = profit;
    }
}
