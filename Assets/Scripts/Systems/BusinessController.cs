using JetBrains.Annotations;
using UnityEngine;
using Slider = UnityEngine.UI.Slider;

public class BusinessController : MonoBehaviour
{
    // public BusinessSettings _businessSettings { get; private set; }

    [SerializeField] private BusinessSettings _businessSettings2;
    [SerializeField] private Profit _profit;

    private bool isLevel;
    private bool isImprovement;

    public BusinessSettings _businessSettings
    {
        get { return _businessSettings2; }
        private set { }
    }

    private ConfigSystem _configSystem;
    private float _timer;
    private int _price;

    public void Initialize(ConfigSystem configSystem)
    {
        _configSystem = configSystem;
    }

    [UsedImplicitly]
    public void GetLevelPrice()
    {
        _price = _businessSettings.GetLevelPrice;
        isLevel = true;
    }

    public void PressLevel()
    {
        isLevel = true;
    }

    [UsedImplicitly]
    public void GetImprovement(string text)
    {
        switch (text)
        {
            case "Improvement1":
                _price = _businessSettings.GetImprovementPrice1;
                break;
            case "Improvement2":
                _price = _businessSettings.GetImprovementPrice2;
                break;
        }
    }

    [UsedImplicitly]
    public void ChangeIncome()
    {
        if (_profit.GetBalance()<=_price)
        {
            return;
        }

        if (isLevel)
        {
            _businessSettings.ChangeLEvel();
            isLevel = false;
        }
        
        _profit.DecreaseTotalBalance(_price);
        
        var newIncome =  _configSystem.RecalculationIncome(_businessSettings.GetCurrentLevel,_businessSettings.GetBasicPrice,
          _businessSettings.GetImprovement1, _businessSettings.GetImprovement2);

        _businessSettings.ChangeProfit(newIncome);
      
     var newLevelPrice = _configSystem.GetNewLevelPrice(_businessSettings.GetCurrentLevel, _businessSettings.GetBasicPrice);
     _businessSettings.ChangeLevelPrice(newLevelPrice);
    }
    
  
}
