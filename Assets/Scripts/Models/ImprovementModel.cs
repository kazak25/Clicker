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
   
   
   [SerializeField] public string Name;
   [SerializeField] public float Price;
   [SerializeField]  public float Boost;
   
   public void ChangeCondition()
   {
      if (IsBought) IsBought = false;
      
   }
   


}

