using System;
using GameView;
using JetBrains.Annotations;
using Models;
using Systems;
using UnityEngine;

namespace Controllers
{
    public class ImprovementController : MonoBehaviour
    {
        public ImprovementModel GetImprovementModel => _improvementModel;

        [SerializeField] private BusinessController _businessController;
        [SerializeField] private ImprovementView _improvementView;

        private ImprovementModel _improvementModel;
        private ProfitSystem _profitSystem;


        public void Initialize(ProfitSystem profitSystem)
        {
            _profitSystem = profitSystem;
        }

        public void Initialize(ImprovementModel improvementModel)
        {
            _improvementModel = improvementModel;
        }

        [UsedImplicitly]
        public void ChangeIncome()
        {
            if (_improvementModel.IsBought)
            {
                return;
            }

            Debug.Log(_profitSystem == null);
            if (_profitSystem.GetBalance() < _improvementModel.Price)
            {
                return;
            }

            _improvementModel.ChangeCondition();
            _businessController.ChangeCurrentIncome();
            _profitSystem.DecreaseTotalBalance(_improvementModel.Price);
        }

        private void Update()
        {
            _improvementView.View(_improvementModel.Name,_improvementModel.Price,_improvementModel.Boost);
        }
    }
}