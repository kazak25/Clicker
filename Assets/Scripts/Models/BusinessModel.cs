using System;

namespace Models
{
    [Serializable]
    public class BusinessModel
    {
        public string GetName { get; set; }
        public float GetDelayIncome { get; set; }
        public float GetBasicPrice { get; set; }
        public float GetBaseIncome { get; set; }
        public float GetCurrentIncome { get; set; }
        public float GetCurrentLevel { get; set; }
        public float GetCurrentLevelPrice { get; set; }

        public  ImprovementModel[] GetImprovemnts;

        public bool isLevelClick { get; private set; }


        public BusinessModel(string name, float incomeDelay, float currentLevel, float baseIncome, float currentIncome,
            float basicPrice, ImprovementModel[] improvementModels)
        {
            GetName = name;
            GetDelayIncome = incomeDelay;
            GetCurrentLevel = currentLevel;
            GetBaseIncome = baseIncome;
            GetCurrentIncome = currentIncome;
            GetBasicPrice = basicPrice;
            GetImprovemnts = improvementModels;
        }

        public void ClickLevel()
        {
            isLevelClick = true;
        }
        public void ResetLevelClick()
        {
            isLevelClick = false;
        }
        public void ChangeProfit(int newProfit)
        {
            GetCurrentIncome = newProfit;
        }

        public void ChangeLevelPrice(int newPrice)
        {
            GetCurrentLevelPrice = newPrice;
        }

        public void ChangeLEvel()
        {
            GetCurrentLevel++;
        }
    }
}