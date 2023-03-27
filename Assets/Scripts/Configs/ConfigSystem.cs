using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class ConfigSystem : MonoBehaviour
{
    public int GetNewLevelPrice(int level, int basicPrice)
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
