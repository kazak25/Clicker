using UnityEngine;

public class Presenter : MonoBehaviour
{
  // [SerializeField] private SaveSystem _saveSystem;
   //[SerializeField] private BusinessParameters businessParameters;
   [SerializeField] private Profit profit;
   [SerializeField] private ConfigSystem _configSystem;
  // [SerializeField] private UpgradeSystem _upgradeSystem;
   [SerializeField] private GameView _gameView;
   
   private void Start()
   {
       _gameView.Initialize(profit);
   }

   private void BusinessInitialize()
   {
       // var settings = businessParameters._levelSettings;
       // _configSystem.Initialize(settings.GetCurrentLevel,settings.GetBasicPrice,settings.GetBaseIncome,
       //     settings.GetImprovement1,settings.GetImprovement2);
   }
}
