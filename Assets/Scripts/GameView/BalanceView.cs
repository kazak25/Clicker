using System;
using TMPro;
using UnityEngine;

public class BalanceView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _totalBalance;
    
    private Profit _profit;

    void Update()
    {
        // var balance = Convert.ToInt32(_profit.GetBalance());
        var balance = Convert.ToInt32(_profit.GetBalance().ToString());
        _totalBalance.text = "Balance: " +  balance + "$";
    }
    public void Initialize(Profit profit)
    {
        _profit = profit;
    }
    
   
}
