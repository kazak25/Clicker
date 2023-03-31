using System;
using TMPro;
using UnityEngine;

public class BalanceView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _totalBalance;
    
    private ProfitSystem _profitSystem;

    void Update()
    {
        // var balance = Convert.ToInt32(_profit.GetBalance());
        Debug.Log(_profitSystem.GetBalance());
        var balance = Convert.ToInt32(_profitSystem.GetBalance().ToString());
        _totalBalance.text = "Balance: " +  balance + "$";
    }
    public void Initialize(ProfitSystem profitSystem)
    {
        _profitSystem = profitSystem;
    }
    
   
}
