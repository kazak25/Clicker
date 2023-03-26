using JetBrains.Annotations;
using UnityEngine;

public class ImprovementController : MonoBehaviour
{
   [SerializeField] private BusinessController _businessController;
   public ImprovementModel GetImprovementModel => _improvementModel;
   
   private ImprovementModel _improvementModel;

   private Profit _profit;
   

   private float _price;

   private void Start()
   {
      _improvementModel.ChangeCondition();
     // _improvementModel.FinalBoost = 0;
   }

   public void Initialize(Profit profit)
   {
      _profit = profit;
   }
  
   public void Initialize(ImprovementModel improvementModel)
   {
      _improvementModel = improvementModel;
   }
  
   public void ChangeIncome()
   {
      if (_improvementModel.IsBought)
      {
         return;
      }
      if (_profit.GetBalance() < _price)
      {
         return;
      }
      
      _businessController.ChangeCurrentIncome();
      _profit.DecreaseTotalBalance(_price);
      _improvementModel.ChangeCondition();
   }
   
   [UsedImplicitly]
   public void GetImprovementPrice()
   {
      _price = GetImprovementModel.Price;
   }
}
