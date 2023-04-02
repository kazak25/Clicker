using System;
using Systems;
using TMPro;
using UnityEngine;

namespace GameView
{
    public class BalanceView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _totalBalance;
        public void View(TotalBalanceController totalBalanceController)
        {
            var balance = Convert.ToInt32(totalBalanceController.GetBalance().ToString());
            _totalBalance.text = "Balance: " + balance + "$";
        }
    }
}