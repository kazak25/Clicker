using System;
using Configs;
using Events;
using GameView;
using JetBrains.Annotations;
using Models;
using SimpleEventBus.Disposables;
using Systems;
using UnityEngine;

namespace Controllers
{
    public class BusinessController : MonoBehaviour
    {
        public BusinessModel Model { get; private set; }

        [SerializeField] private Timer _timer;
        [SerializeField] private ImprovementController[] _improvementControllers;
        [SerializeField] private BusinessView _businessView;

        private ProfitSystem _profitSystem;
        private ConfigSystem _configSystem;
        private CompositeDisposable _subscription;

        private void Awake()
        {
            _subscription = new CompositeDisposable()
            {
                EventStream.Game.Subscribe<GetProfitEvent>(GetProfit),
            };
        }

        private void Start()
        {
            _timer.Initialize(Model);
            OnStart();
        
            for (var i = 0; i < _improvementControllers.Length; i++)
            {
                _improvementControllers[i].Initialize(Model.GetImprovemnts[i]);
            }
        }

        [UsedImplicitly]
        private void GetProfit(GetProfitEvent profit)
        {
            _profitSystem = profit.GetProfit();
            _timer.Initialize(profit.GetProfit());
            foreach (var improvementController in _improvementControllers)
            {
                improvementController.Initialize(profit.GetProfit());
            }
        }

        private void OnStart()
        {
            var newLevelPrice = _configSystem.GetNewLevelPrice(Model.GetCurrentLevel, Model.GetBasicPrice);
            Model.ChangeLevelPrice(newLevelPrice);
        }

        public void Initialize(BusinessModel model, ConfigSystem configSystem)
        {
            Model = model;
            _configSystem = configSystem;
        }

        public void ClickLevel()
        {
            Model.ClickLevel();
        }

        [UsedImplicitly]
        public void ChangeIncome()
        {
            if (_profitSystem.GetBalance() < Model.GetCurrentLevelPrice) return;
            if (Model.isLevelClick)
            {
                Model.ChangeLEvel();
                Model.ResetLevelClick();
            }

            _profitSystem.DecreaseTotalBalance(Model.GetCurrentLevelPrice);
            ChangeCurrentIncome();
            var newLevelPrice = _configSystem.GetNewLevelPrice(Model.GetCurrentLevel, Model.GetBasicPrice);
            Model.ChangeLevelPrice(newLevelPrice);
        }

        public void ChangeCurrentIncome()
        {
            var newIncome = _configSystem.RecalculationIncome(Model.GetCurrentLevel, Model.GetBasicPrice,
                _improvementControllers);
            Model.ChangeProfit(newIncome);
        }

        private void OnDestroy()
        {
            _subscription?.Dispose();
        }

        private void Update()
        {
            _businessView.View(Model.GetName,Model.GetCurrentLevel,Model.GetCurrentIncome,Model.GetCurrentLevelPrice);
        }
    }
}