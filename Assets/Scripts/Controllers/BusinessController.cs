using System;
using JetBrains.Annotations;
using SimpleEventBus.Disposables;
using UnityEngine;

public class BusinessController : MonoBehaviour
{
    public BusinessModel BusinessModel => _model;

    // public BusinessSettings _businessSettings { get; private set; }
    [SerializeField] private Timer _timer;
    [SerializeField] private ImprovementController[] _improvementControllers;

    private ProfitSystem _profitSystem;
    private ConfigSystem _configSystem;
    private BusinessModel _model;
    private CompositeDisposable _subscription;
    private float _price;
    private bool _isLevel;

    private void Awake()
    {
       
      _subscription = new CompositeDisposable()
      {
         EventStream.Game.Subscribe<GetProfitEvent>(GetProfit),

      };
    }
    

    private void Start()
    {
        _timer.Initialize(_model);
        var newLevelPrice = _configSystem.GetNewLevelPrice(_model.GetCurrentLevel, _model.GetBasicPrice);
        _model.ChangeLevelPrice(newLevelPrice);
        

        for (var i = 0; i < _improvementControllers.Length; i++)
        {
            Debug.Log(_model);
            _improvementControllers[i].Initialize(_model.GetImprovemnts[i]);
        }
    }
    
    
    [UsedImplicitly]
    public void GetProfit(GetProfitEvent profit)
    {
        _profitSystem = profit.GetProfit();
        foreach (var improvementController in _improvementControllers)
        {
            improvementController.Initialize(profit.GetProfit());
        }
    }

    public void Initialize(BusinessModel model, ConfigSystem configSystem)
    {
        _model = model;
        _configSystem = configSystem;
    }


    [UsedImplicitly]
    public void GetLevelPrice()
    {
        _price = _model.GetCurrentLevelPrice;
    }

    public void PressLevel()
    {
        _isLevel = true;
    }

    [UsedImplicitly]
    public void ChangeIncome()
    {
        if (_profitSystem.GetBalance() < _price)
        {
            return;
        }

        Debug.Log(_isLevel);
        if (_isLevel)
        {
            _model.ChangeLEvel();
            _isLevel = false;
        }

        _profitSystem.DecreaseTotalBalance(_price);

        ChangeCurrentIncome();
        
        var newLevelPrice = _configSystem.GetNewLevelPrice(_model.GetCurrentLevel, _model.GetBasicPrice);
        _model.ChangeLevelPrice(newLevelPrice);
    }

    public void ChangeCurrentIncome()
    {
        var newIncome = _configSystem.RecalculationIncome(_model.GetCurrentLevel, _model.GetBasicPrice,
            _improvementControllers);

        _model.ChangeProfit(newIncome);
    }

    private void OnDestroy()
    {
        _subscription?.Dispose();
    }
}