using System.Collections;
using System.Collections.Generic;
using SimpleEventBus.Events;
using UnityEngine;

public class GetProfitEvent : EventBase
{
    public Profit _Profit;

    public GetProfitEvent(Profit profit)
    {
        _Profit = profit;
    }
    public Profit GetProfit()
    {
        return _Profit;
    }

}
