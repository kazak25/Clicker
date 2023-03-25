using System;
using SimpleEventBus.Disposables;
using UnityEngine;

public class Profit : MonoBehaviour
{
   private int _totalBalance;
   private CompositeDisposable _subscription;
   public void IncreaseProfit(GetProfitEvent data)
   {
      _totalBalance += data._profit;
   }

   private void Start()
   {
      _subscription = new CompositeDisposable()
      {
         EventStream.Game.Subscribe<GetProfitEvent>(IncreaseProfit),

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
