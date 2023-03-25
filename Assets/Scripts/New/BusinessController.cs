using System;
using JetBrains.Annotations;
using UnityEngine;
using Slider = UnityEngine.UI.Slider;

public class BusinessController : MonoBehaviour
{
    // public BusinessSettings _businessSettings { get; private set; }
    [SerializeField] private Timer _timer;
    private BusinessModel _model;


    private void Start()
    {
        _timer.Initialize(_model);
    }
    // [SerializeField] private Profit _profit;

    // private bool isLevel;
    // private bool isImprovement;

    public void Initialize(BusinessModel model)
    {
        _model = model;
    }
    
    

    // public BusinessModelConfig GetBusinessModelConfig
    // {
    //     get { return _businessSettings2; }
    //     private set { }
    // }
    //
    // private ConfigSystem _configSystem;
    // private float _timer;
    // private int _price;
    //
    // public void Initialize(ConfigSystem configSystem)
    // {
    //     _configSystem = configSystem;
    // }
    //
    // [UsedImplicitly]
    // public void GetLevelPrice()
    // {
    //     _price = GetBusinessModelConfig.GetCurrentLevelPrice;
    //     isLevel = true;
    // }
    //
    // public void PressLevel()
    // {
    //     isLevel = true;
    // }
    //
    // [UsedImplicitly]
    // public void GetImprovement(string text)
    // {
    //     switch (text)
    //     {
    //         case "Improvement1":
    //             _price = GetBusinessModelConfig.GetImprovementPrice1;
    //             break;
    //         case "Improvement2":
    //             _price = GetBusinessModelConfig.GetImprovementPrice2;
    //             break;
    //     }
    // }
    //
    // [UsedImplicitly]
    // public void ChangeIncome()
    // {
    //     if (_profit.GetBalance()<=_price)
    //     {
    //         return;
    //     }
    //
    //     if (isLevel)
    //     {
    //         GetBusinessModelConfig.ChangeLEvel();
    //         isLevel = false;
    //     }
    //     
    //     _profit.DecreaseTotalBalance(_price);
    //     
    //     var newIncome =  _configSystem.RecalculationIncome(GetBusinessModelConfig.GetCurrentLevel,GetBusinessModelConfig.GetBasicPrice,
    //       GetBusinessModelConfig.GetImprovement1, GetBusinessModelConfig.GetImprovement2);
    //
    //     GetBusinessModelConfig.ChangeProfit(newIncome);
    //   
    //  var newLevelPrice = _configSystem.GetNewLevelPrice(GetBusinessModelConfig.GetCurrentLevel, GetBusinessModelConfig.GetBasicPrice);
    //  GetBusinessModelConfig.ChangeLevelPrice(newLevelPrice);
    // }
    //
  
}
