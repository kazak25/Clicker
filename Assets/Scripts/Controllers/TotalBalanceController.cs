using System;
using Events;
using GameView;
using SimpleEventBus.Disposables;
using UnityEngine;

namespace Systems
{
   public class TotalBalanceController : MonoBehaviour
   {
      [SerializeField] private BalanceView _balanceView;
      [SerializeField] private ProfitSystem _profitSystem;
      
      private float _totalBalance;
      private CompositeDisposable _subscription;
      public void IncreaseProfit(GetIncomeEvent data)
      {
         _totalBalance += data.Profit;
      }
 
      private void Start()
      {
         var eventDataRequest = new GetProfitEvent(this,_profitSystem);
         EventStream.Game.Publish(eventDataRequest);
         _subscription = new CompositeDisposable()
         {
            EventStream.Game.Subscribe<GetIncomeEvent>(IncreaseProfit),

         };
      }

      public void Initialize(float newBalance)
      {
         _totalBalance = newBalance;
      }
      public float GetBalance()
      {
         return _totalBalance;
      }

      public void ResetBalance()
      {
         _totalBalance = 0f;
      }
      public void DecreaseTotalBalance(float price)
      {
         _totalBalance -= price;
      }

      private void OnDestroy()
      {
         _subscription?.Dispose();
      }

      private void Update()
      {
         _balanceView.View(this);
      }
   }
}
