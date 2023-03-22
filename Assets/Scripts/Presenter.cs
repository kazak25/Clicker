using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presenter : MonoBehaviour
{
   [SerializeField] private SaveSystem _saveSystem;
   [SerializeField] private BusinessSystem _businessSystem;
   [SerializeField] private ProfitSystem _profitSystem;
   [SerializeField] private ConfigSystem _configSystem;
   [SerializeField] private UpgradeSystem _upgradeSystem;

   private void BusinessInitialize()
   {
       var settings = _businessSystem._levelSettings;
       _configSystem.Initialize(settings.GetCurrentLevel,settings.GetBasicPrice,settings.GetBaseIncome,
           settings.GetImprovement1,settings.GetImprovement2);
   }
}
