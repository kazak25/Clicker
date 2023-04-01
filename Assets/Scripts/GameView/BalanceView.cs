using System;
using Systems;
using TMPro;
using UnityEngine;

namespace GameView
{
    public class BalanceView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _totalBalance;

        private ProfitSystem _profitSystem;

        void Update()
        {
            var balance = Convert.ToInt32(_profitSystem.GetBalance().ToString());
            _totalBalance.text = "Balance: " + balance + "$";
        }

        public void Initialize(ProfitSystem profitSystem)
        {
            _profitSystem = profitSystem;
        }
    }
}