using System;
using SimpleEventBus.Disposables;
using UnityEngine;

public class Profit : MonoBehaviour
{
   private float _totalBalance;
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

   public float GetBalance()
   {
      return _totalBalance;
   }

   public void DecreaseTotalBalance(float price)
   {
      _totalBalance -= price;
   }

   private void OnDestroy()
   {
      _subscription?.Dispose();
   }
}
