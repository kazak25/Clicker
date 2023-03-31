using System.Collections.Generic;
using UnityEngine;

public class BusinesSpawner : MonoBehaviour
{
   // [SerializeField] private BusinessConfig _businessesConfig;
    [SerializeField] private BusinessController _businessPrefab;
    [SerializeField] private RectTransform _parent;
    [SerializeField] private ProfitSystem profitSystem; //Сделать через EventBus
    [SerializeField] private Timer _timer; //сделаем через EventBus
    [SerializeField] private ConfigSystem _configSystem;
    
    private readonly List<BusinessController> _controllers = new ();

    public void SpawnBusiness(BusinessModel[] businessModels)
    {
        foreach (var businessModel in businessModels)
        {
            var business = Instantiate(_businessPrefab, _parent);
            business.Initialize(businessModel, _configSystem);
           // Debug.Log(businessModel.GetName);
          // _timer.Initialize(businessModel);
          Debug.Log("Spawner"+profitSystem.GetBalance());
            _timer.Initialize(profitSystem);
            _controllers.Add(business);
        }
    }
    public void DeleteControllers()
    {
        foreach (var controller in _controllers)
        {
            Destroy(controller.gameObject);
        }
        _controllers.Clear();
    }
    
}