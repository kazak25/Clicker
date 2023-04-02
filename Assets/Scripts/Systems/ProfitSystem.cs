using System.Collections;
using System.Collections.Generic;
using Configs;
using Controllers;
using Events;
using JetBrains.Annotations;
using Models;
using SimpleEventBus.Disposables;
using Systems;
using UnityEngine;

public class ProfitSystem : MonoBehaviour
{
   [SerializeField] private TotalBalanceController _totalBalanceController;
    public void ChangeIncome(BusinessModel model, ConfigSystem configSystem,ImprovementController[] improvementControllers)
    {
        if (_totalBalanceController.GetBalance() < model.GetCurrentLevelPrice) return;
        if (model.isLevelClick)
        {
            model.ChangeLEvel();
            model.ResetLevelClick();
        }

        _totalBalanceController.DecreaseTotalBalance(model.GetCurrentLevelPrice);
        ChangeCurrentIncome(model,configSystem,improvementControllers);
        var newLevelPrice = configSystem.GetNewLevelPrice(model.GetCurrentLevel, model.GetBasicPrice);
        model.ChangeLevelPrice(newLevelPrice);
    }

    public void ChangeCurrentIncome(BusinessModel model, ConfigSystem configSystem,ImprovementController[] improvementControllers)
    {
        var newIncome = configSystem.RecalculationIncome(model.GetCurrentLevel, model.GetBasicPrice,
            improvementControllers);
        model.ChangeProfit(newIncome);
    }
   
}
