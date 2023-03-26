using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ImprovementView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _improvementName;
    [SerializeField] private TextMeshProUGUI _price;
    [SerializeField] private TextMeshProUGUI _boost;

    [SerializeField] private ImprovementController improvementController;

    private void View()
    {
        _improvementName.text = improvementController.GetImprovementModel.Name;
        _price.text = "PRICE: " + improvementController.GetImprovementModel.Price;
        _boost.text = "BOOST: " + improvementController.GetImprovementModel.Boost*100 +"%";
    }

    private void Update()
    {
        View();
    }
    
}
