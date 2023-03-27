using System;
using SimpleEventBus.Disposables;
using UnityEngine;

public class Profit : MonoBehaviour
{
   private int _totalBalance;
   private CompositeDisposable _subscription;
   public void IncreaseProfit(GetIncomeEvent data)
   {
      _totalBalance += data._profit;
   }

   private void Start()
   {
      var eventDataRequest = new GetProfitEvent(this);
      EventStream.Game.Publish(eventDataRequest);
      
      _subscription = new CompositeDisposable()
      {
         EventStream.Game.Subscribe<GetIncomeEvent>(IncreaseProfit),

      };
   }

   public int GetBalance()
   {
      return _totalBalance;
   }

   public void DecreaseTotalBalance(int price)
   {
      _totalBalance -= price;
   }

   private void OnDestroy()
   {
      _subscription?.Dispose();
   }
}
