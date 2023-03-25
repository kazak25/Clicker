using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class Timer : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private Profit _profit; //Сделать через EventBus
   
    private BusinessModel _model;
    private int _maxValue;
    private float _timer;

    private void Start()
    {
        _slider.maxValue = _model.GetDelayIncome;
       
    }

    public void Initialize(Profit profit)
    {
        _profit = profit;
    }

    public void Initialize(BusinessModel model)
    {
        _model = model;
    }
   
    private void Update()
    {
         UpdateSlider();
    }

    private void UpdateSlider()
    {
        if (_model.GetCurrentLevel == 0)
        {
            return;
        }
        _timer += Time.deltaTime;
        _slider.value = _timer;
       
        if (_timer>=_model.GetDelayIncome)
        {
            var eventDataRequest = new GetProfitEvent(_model.GetCurrentIncome);
            EventStream.Game.Publish(eventDataRequest);
            _timer=0;
        }
    }
}
