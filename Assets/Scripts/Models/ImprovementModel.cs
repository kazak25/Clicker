using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class ImprovementModel
{
   public bool IsBought = false;
   public float FinalBoost;
   
   
   public string Name;
   public float Price;
   public float Boost;
   
   public void ChangeCondition()
   {
      IsBought = true;
   }
   


}

