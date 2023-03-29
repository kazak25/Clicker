using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class ConfigSystem : MonoBehaviour
{
    [SerializeField] private BusinessConfig _businessConfig;

    private BusinessModel[] _businessModels;
    private ImprovementModel[] _improvementModels;
    public void CreateBusinessModels()
    {
        _businessModels = new BusinessModel[_businessConfig.ConfigBusinessModel.Length];

        for (var i = 0; i < _businessConfig.ConfigBusinessModel.Length; i++)
        {
            var businessName = _businessConfig.ConfigBusinessModel[i].Name;
            var incomeDelay = _businessConfig.ConfigBusinessModel[i].IncomeDelay;
            var level = _businessConfig.ConfigBusinessModel[i].Level;
            var income = _businessConfig.ConfigBusinessModel[i].Income;
            var price = _businessConfig.ConfigBusinessModel[i].Price;
                
            var businessImproves = CreateBusinessImproveModels(i);

            _businessModels[i] = new BusinessModel(businessName, incomeDelay, level, income, income, price, businessImproves);
        }
    }
    private ImprovementModel[] CreateBusinessImproveModels(int index)
    {
        var businessImproves = new ImprovementModel[_businessConfig.ConfigBusinessModel[index].TypesImprovement.Length];
        for (var j = 0; j < businessImproves.Length; j++)
        {
            var businessImproveName = _businessConfig.ConfigBusinessModel[index].TypesImprovement[j].Name;
            var businessImprovePrice = _businessConfig.ConfigBusinessModel[index].TypesImprovement[j].Price;
            var businessImproveBoostIncome = _businessConfig.ConfigBusinessModel[index].TypesImprovement[j].BoostIncome;
            var businessImproveIsPurchased = _businessConfig.ConfigBusinessModel[index].TypesImprovement[j].IsPurchased;

            businessImproves[j] = new ImprovementModel(businessImproveName, businessImprovePrice,
                businessImproveBoostIncome, businessImproveIsPurchased);
        }

        return businessImproves;
    }

    public BusinessModel[] GetBuisnessModels()
    {
        return _businessModels;
    }

    public int GetNewLevelPrice(float level, float basicPrice)
    {
        var newLevelPrice = (1 + level) * basicPrice;
        return (int)newLevelPrice;
    }
    
    public int RecalculationIncome(float level, float basicIncome, ImprovementController[] improvements)
    {
       
        var firstImprovementBoost =
            improvements[0].GetImprovementModel.IsBought ? improvements[0].GetImprovementModel.Boost : 0;
        var secondImprovementBoost =
            improvements[1].GetImprovementModel.IsBought ? improvements[0].GetImprovementModel.Boost : 0;
        
        var newIncome = level * basicIncome * (1 + firstImprovementBoost + secondImprovementBoost);
        
        return (int)newIncome;
    }
}
