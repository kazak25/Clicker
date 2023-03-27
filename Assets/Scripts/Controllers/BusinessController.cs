using JetBrains.Annotations;
using SimpleEventBus.Disposables;
using UnityEngine;

public class BusinessController : MonoBehaviour
{
    public BusinessModel BusinessModel => _model;
    
    // public BusinessSettings _businessSettings { get; private set; }
    [SerializeField] private Timer _timer;
    [SerializeField] private ImprovementController[] _improvementControllers;

    private ConfigSystem _configSystem;
    private Profit _profit;
    private BusinessModel _model;
    private CompositeDisposable _subscription;
    private int _price;
    private bool _isLevel;

    private void Start()
    {
        _timer.Initialize(_model);
        var eventDataRequest = new GetIncomeEvent(_model.GetCurrentIncome);
        EventStream.Game.Publish(eventDataRequest);
        
        _subscription = new CompositeDisposable()
        {
            EventStream.Game.Subscribe<GetProfitEvent>(GetProfit),
        };
        
        for (var i = 0; i < _improvementControllers.Length; i++)
        {
            _improvementControllers[i].Initialize(_model.GetImprovemnts[i]);
        }
    }
    public void GetProfit(GetProfitEvent profit)
    {
        _profit = profit.GetProfit();
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
        if (_profit.GetBalance() < _price)
        {
            return;
        }
        
        if (_isLevel)
        {
            _model.ChangeLEvel();
            _isLevel = false;
        }
        
        _profit.DecreaseTotalBalance(_price);
        
       ChangeCurrentIncome();
      
     var newLevelPrice = _configSystem.GetNewLevelPrice(_model.GetCurrentLevel, _model.GetBasicPrice);
     _model.ChangeLevelPrice(newLevelPrice);
    }

    public void ChangeCurrentIncome()
    {
        var newIncome =  _configSystem.RecalculationIncome(_model.GetCurrentLevel,_model.GetBasicPrice,
            _improvementControllers);
    
        _model.ChangeProfit(newIncome);
    }
    
    private void OnDestroy()
    {
        _subscription?.Dispose();
            
    }
}
