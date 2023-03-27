using JetBrains.Annotations;
using UnityEngine;

public class ImprovementController : MonoBehaviour
{
   public ImprovementModel GetImprovementModel => _improvementModel;
   
   [SerializeField] private BusinessController _businessController;
   
   private ImprovementModel _improvementModel;
   private Profit _profit;
   private float _price;
   

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
      
      _improvementModel.ChangeCondition();
      _businessController.ChangeCurrentIncome();
      _profit.DecreaseTotalBalance(_price);
   }
   
   [UsedImplicitly]
   public void GetImprovementPrice()
   {
      _price = GetImprovementModel.Price;
   }
}
