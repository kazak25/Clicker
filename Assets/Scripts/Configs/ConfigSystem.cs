using Controllers;
using Models;
using ScriptableObjects;
using UnityEngine;

namespace Configs
{
    public class ConfigSystem : MonoBehaviour
    {
        [SerializeField] private BusinessConfigCollection businessConfigCollection;

        private BusinessModel[] _businessModels;
        private ImprovementModel[] _improvementModels;
        public void CreateBusinessModels()
        {
            _businessModels = new BusinessModel[businessConfigCollection.ConfigBusinessModel.Length];

            for (var i = 0; i < businessConfigCollection.ConfigBusinessModel.Length; i++)
            {
                var businessName = businessConfigCollection.ConfigBusinessModel[i].Name;
                var incomeDelay = businessConfigCollection.ConfigBusinessModel[i].IncomeDelay;
                var level = businessConfigCollection.ConfigBusinessModel[i].Level;
                var income = businessConfigCollection.ConfigBusinessModel[i].Income;
                var price = businessConfigCollection.ConfigBusinessModel[i].Price;
                
                var businessImproves = CreateBusinessImproveModels(i);

                _businessModels[i] = new BusinessModel(businessName, incomeDelay, level, income, income, price, businessImproves);
            }
        }
        private ImprovementModel[] CreateBusinessImproveModels(int index)
        {
            var businessImproves = new ImprovementModel[businessConfigCollection.ConfigBusinessModel[index].TypesImprovement.Length];
            for (var j = 0; j < businessImproves.Length; j++)
            {
                var businessImproveName = businessConfigCollection.ConfigBusinessModel[index].TypesImprovement[j].Name;
                var businessImprovePrice = businessConfigCollection.ConfigBusinessModel[index].TypesImprovement[j].Price;
                var businessImproveBoostIncome = businessConfigCollection.ConfigBusinessModel[index].TypesImprovement[j].BoostIncome;
                var businessImproveIsPurchased = businessConfigCollection.ConfigBusinessModel[index].TypesImprovement[j].IsPurchased;

                businessImproves[j] = new ImprovementModel(businessImproveName, businessImprovePrice,
                    businessImproveBoostIncome, businessImproveIsPurchased);
            }

            return businessImproves;
        }

        public BusinessModel[] GetBuisnessModels()
        {
            return _businessModels;
        }

        public int GetNewLevelPrice(float level, float basicPrice)
        {
            var newLevelPrice = (1 + level) * basicPrice;
            return (int)newLevelPrice;
        }
    
        public int RecalculationIncome(float level, float basicIncome, ImprovementController[] improvements)
        {
       
            var firstImprovementBoost =
                improvements[0].GetImprovementModel.IsBought ? improvements[0].GetImprovementModel.Boost : 0;
            var secondImprovementBoost =
                improvements[1].GetImprovementModel.IsBought ? improvements[0].GetImprovementModel.Boost : 0;
        
            var newIncome = level * basicIncome * (1 + firstImprovementBoost + secondImprovementBoost);
        
            return (int)newIncome;
        }
    }
}
