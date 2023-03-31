using System.Collections;
using System.Collections.Generic;
using SimpleEventBus.Events;
using UnityEngine;

public class GetProfitEvent : EventBase
{
    public ProfitSystem ProfitSystem;

    public GetProfitEvent(ProfitSystem profitSystem)
    {
        ProfitSystem = profitSystem;
    }
    public ProfitSystem GetProfit()
    {
        return ProfitSystem;
    }

}
