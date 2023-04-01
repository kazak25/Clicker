using System;

namespace Models
{
   [Serializable]
   public class ImprovementModel
   {
      public bool IsBought = false;
   
      public string Name;
      public float Price;
      public float Boost;
   
      public void ChangeCondition()
      {
         IsBought = true;
      }
   
      public ImprovementModel(string name, float price, float boost, bool isPurchased)
      {
         Name = name;
         Price = price;
         Boost = boost;
         IsBought = isPurchased;
      }

   }
}

