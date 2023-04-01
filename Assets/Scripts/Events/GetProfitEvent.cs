using SimpleEventBus.Events;
using Systems;

namespace Events
{
    public class GetProfitEvent : EventBase
    {
        public ProfitSystem ProfitSystem { get; }

        public GetProfitEvent(ProfitSystem profitSystem)
        {
            ProfitSystem = profitSystem;
        }
        public ProfitSystem GetProfit()
        {
            return ProfitSystem;
        }

    }
}
