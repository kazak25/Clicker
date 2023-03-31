using JetBrains.Annotations;
using UnityEngine;

public class ImprovementController : MonoBehaviour
{
   public ImprovementModel GetImprovementModel => _improvementModel;
   
   [SerializeField] private BusinessController _businessController;
   
   private ImprovementModel _improvementModel;
   private ProfitSystem _profitSystem;
   private float _price;
   

   public void Initialize(ProfitSystem profitSystem)
   {
      _profitSystem = profitSystem;
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
      Debug.Log(_profitSystem==null);
      if (_profitSystem.GetBalance() < _price)
      {
         return;
      }
      
      _improvementModel.ChangeCondition();
      _businessController.ChangeCurrentIncome();
      _profitSystem.DecreaseTotalBalance(_price);
   }
   
   [UsedImplicitly]
   public void GetImprovementPrice()
   {
      _price = GetImprovementModel.Price;
   }
}
