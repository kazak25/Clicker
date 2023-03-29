using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using EventBase = SimpleEventBus.Events.EventBase;

public class GetIncomeEvent : EventBase
{
    public float _profit { get; }

    public GetIncomeEvent(float profit)
    {
        _profit = profit;
    }
}
