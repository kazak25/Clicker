using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class BusinessView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _businessName;
    [SerializeField] private TextMeshProUGUI _level;
    [SerializeField] private TextMeshProUGUI _income;
    [SerializeField] private TextMeshProUGUI _levelUpPrice;

    [SerializeField] private BusinessController _businessController;

    private void View()
    {
        _businessName.text = _businessController.BusinessModel.GetName;
        _level.text = "LVL " + _businessController.BusinessModel.GetCurrentLevel;
        _income.text = "INCOME: " + _businessController.BusinessModel.GetCurrentIncome;
        _levelUpPrice.text =  _businessController.BusinessModel.GetCurrentLevelPrice+ "$";
    }

    private void Update()
    {
        View();
    }
}
