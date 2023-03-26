using System;
using UnityEngine;


[Serializable]
public class BusinessModel 
{
    public int GetDelayIncome => _delayIncome;
    public string GetName => _name;
    public int GetBasicPrice => _basicPrice;
    
    public int GetBaseIncome => _baseIncome; 
    public int GetCurrentLevel => _currentLevel;
    public float GetCurrentIncome => _currentIncome;
    public int GetCurrentLevelPrice => _currentLevelPrice;
    public ImprovementModel[] GetImprovemnts => _imrpovements;
    
    [SerializeField] private string _name;
    [SerializeField] private int _delayIncome;
    [SerializeField] private int _basicPrice;
    [SerializeField] private int _baseIncome;
    
    [SerializeField] private float _currentIncome;
    [SerializeField] private int _currentLevel;
    [SerializeField] private int _currentLevelPrice;
    
    [SerializeField] private ImprovementModel[] _imrpovements;
   
    
    
    
    public void ChangeProfit(float newProfit)
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
