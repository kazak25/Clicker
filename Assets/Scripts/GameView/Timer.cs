using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class Timer : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private Profit _profit;
    private Dictionary<string, BusinessController> _data = new Dictionary<string, BusinessController>();
    private BusinessController _businessController;
    private int _maxValue;
    private float _timer;
    
    public void Initialize( Dictionary<string, BusinessController> data)
    {
        _data = data;
        foreach (var key in _data)
        {
            var sliderName = _slider.name;
            if (sliderName == key.Key)
            {
                _businessController = _data[key.Key];
            }
        }
        _slider.maxValue = _businessController._businessSettings.GetDelayIncome;
    }

    public void Initialize(Profit profit)
    {
        _profit = profit;
    }
   
    private void Update()
    {
         UpdateSlider();
    }

    private void UpdateSlider()
    {
        if (_businessController._businessSettings.GetCurrentLevel == 0)
        {
            return;
        }
        _timer += Time.deltaTime;
        _slider.value = _timer;
       
        if (_timer>=_businessController._businessSettings.GetDelayIncome)
        {
            _profit.IncreaseProfit(_businessController._businessSettings.GetCurrentIncome);
            _timer=0;
        }
    }
}
