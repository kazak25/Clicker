using System;
using UnityEngine;


[Serializable]
public class BusinessModel 
{
    public float GetDelayIncome => _delayIncome;
    public string GetName => _name;
    public float GetBasicPrice => _basicPrice;
    public float GetBaseIncome => _baseIncome; 
    public float GetCurrentLevel => _currentLevel;
    public float GetCurrentIncome => _currentIncome;
    public float GetCurrentLevelPrice => _currentLevelPrice;
    public ImprovementModel[] GetImprovemnts => _imrpovements;
    
    [SerializeField] private string _name;
    [SerializeField] private float _delayIncome;
    [SerializeField] private float _basicPrice;
    [SerializeField] private float _baseIncome;
    [SerializeField] private float _currentIncome;
    [SerializeField] private float _currentLevel;
    [SerializeField] private float _currentLevelPrice;
    [SerializeField] private ImprovementModel[] _imrpovements;

    public BusinessModel(string name, float incomeDelay, float currentLevel, float baseIncome, float currentIncome, float currentLevelPrice, ImprovementModel[] improvementModels)
    {
        _name = name;
        _delayIncome = incomeDelay;
        _currentLevel = currentLevel;
        _baseIncome = baseIncome;
        _currentIncome = currentIncome;
        _currentLevelPrice = currentLevelPrice;
        _imrpovements = improvementModels;
    }
    public void ChangeProfit(int newProfit)
    {
        _currentIncome = newProfit;
    }

    public void ChangeLevelPrice(int newPrice)
    {
        _currentLevelPrice = newPrice;
    }

    public void ChangeLEvel()
    {
        _currentLevel++;
    }
}
