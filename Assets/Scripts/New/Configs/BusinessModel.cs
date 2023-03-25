using System;
using UnityEngine;


[Serializable]
public class BusinessModel 
{

    [SerializeField] private string _name;
    [SerializeField] private int _delayIncome;
    [SerializeField] private int _basicPrice;
    [SerializeField] private int _baseIncome;
    [SerializeField] private int _improvement1;
    [SerializeField] private int _improvement2;
    [SerializeField] private int _currentIncome;
    [SerializeField] private int _currentLevel;
    [SerializeField] private int _currentLevelPrice;
    [SerializeField] private int _improvementPrice1;
    [SerializeField] private int _improvementPrice2;
    
    public int GetDelayIncome => _delayIncome;
    public string GetName => _name;
    public int GetBasicPrice => _basicPrice;
    public int GetBaseIncome => _baseIncome;
    public int GetImprovement1 => _improvement1;
    public int GetImprovement2 => _improvement2;
    public int GetCurrentLevel => _currentLevel;
    public int GetCurrentIncome => _currentIncome;
    public int GetCurrentLevelPrice => _currentLevelPrice;
    public int GetImprovementPrice1 => _improvementPrice1;
    public int GetImprovementPrice2 => _improvementPrice2;
    

    public BusinessModel(string name,int currentLevelPrice, int currenLevel, int baseIncome,int delayIncome, int currentIncome)
    {
        _name = name;
        _currentLevelPrice = currentLevelPrice;
        _currentLevel = currenLevel;
        _delayIncome = delayIncome;
        _baseIncome = baseIncome;
        _currentIncome = currentIncome;
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
