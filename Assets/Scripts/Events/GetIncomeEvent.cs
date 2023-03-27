using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using EventBase = SimpleEventBus.Events.EventBase;

public class GetIncomeEvent : EventBase
{
    public int _profit { get; }

    public GetIncomeEvent(int profit)
    {
        _profit = profit;
    }
}
