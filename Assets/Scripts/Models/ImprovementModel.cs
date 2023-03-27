using System;
using UnityEngine;

[Serializable]
public class ImprovementModel
{
   public bool IsBought = false;
   public float FinalBoost;
  
   public string Name;
   public int Price;
   public float Boost;
   
   public void ChangeCondition()
   {
      IsBought = true;
   }
   


}

