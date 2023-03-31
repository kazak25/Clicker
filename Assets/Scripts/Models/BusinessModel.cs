using System;
using UnityEngine;


[Serializable]
public class BusinessModel 
{
    // public float GetDelayIncome => _delayIncome;
    // public string GetName => _name;
    // public float GetBasicPrice => _basicPrice;
    // public float GetBaseIncome => _baseIncome; 
    // public float GetCurrentLevel => _currentLevel;
    // public float GetCurrentIncome => _currentIncome;
    // public float GetCurrentLevelPrice => _currentLevelPrice;
    // public ImprovementModel[] GetImprovemnts => _imrpovements;
    
     public string GetName { get; set; }
     public float GetDelayIncome { get; set; }
     public float GetBasicPrice { get; set; }
     
     public float GetBaseIncome { get; set; }
     
     public float GetCurrentIncome { get; set; }
     
     public float GetCurrentLevel{ get; set; }
     
     public float GetCurrentLevelPrice{ get; set; }
     
     public ImprovementModel[] GetImprovemnts;
     
    
     

    public BusinessModel(string name, float incomeDelay, float currentLevel, float baseIncome, float currentIncome, float basicPrice, ImprovementModel[] improvementModels)
    {
        GetName = name;
        GetDelayIncome = incomeDelay;
        GetCurrentLevel = currentLevel;
        GetBaseIncome = baseIncome;
        GetCurrentIncome = currentIncome;
        GetBasicPrice = basicPrice;
        GetImprovemnts = improvementModels;
    }
    public void ChangeProfit(int newProfit)
    {
        GetCurrentIncome = newProfit;
    }

    public void ChangeLevelPrice(int newPrice)
    {
        GetCurrentLevelPrice = newPrice;
    }

    public void ChangeLEvel()
    {
        GetCurrentLevel++;
    }
}
