using System.Collections.Generic;
using UnityEngine;

public class Presenter : MonoBehaviour
{
    
   [SerializeField] private Profit profit;
   [SerializeField] private ConfigSystem _configSystem;
   [SerializeField] private BalanceView _balanceView;
   
   
   private void Start()
   {
       _balanceView.Initialize(profit);
   }

   private void BusinessInitialize()
   {
       // var settings = businessParameters._levelSettings;
       // _configSystem.Initialize(settings.GetCurrentLevel,settings.GetBasicPrice,settings.GetBaseIncome,
       //     settings.GetImprovement1,settings.GetImprovement2);
   }
}
