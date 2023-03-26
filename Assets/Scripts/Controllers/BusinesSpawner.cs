using UnityEngine;

public class BusinesSpawner : MonoBehaviour
{
    [SerializeField] private BusinessConfig _businessesConfig;
    [SerializeField] private BusinessController _businessPrefab;
    [SerializeField] private RectTransform _parent;
    [SerializeField] private Profit _profit; //Сделать через EventBus
    [SerializeField] private Timer _timer; //сделаем через EventBus
    [SerializeField] private ConfigSystem _configSystem;

    private void Awake()
    {
        SpawnBusiness();
    }

    private void SpawnBusiness()
    {
        foreach (var businessModel in _businessesConfig.BuisnessModels)
        {
            var business = Instantiate(_businessPrefab, _parent);
            business.Initialize(businessModel,_configSystem);
            _timer.Initialize(_profit);
        }
    }
}
