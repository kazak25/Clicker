using UnityEngine;

public class ConfigSystem : MonoBehaviour
{

    public int GetNewLevelPrice(int level, int basicPrice)
    {
        var newLevelPrice = (1 + level) * basicPrice;
        return newLevelPrice;
    }
    public float RecalculationIncome(float level, float basicIncome, ImprovementController[] improvements)
    {
        foreach (var improvement in improvements)
        {
            if (improvement.GetImprovementModel.IsBought)
            {
                improvement.GetImprovementModel.FinalBoost = improvement.GetImprovementModel.Boost;
            }
        }
        var newIncome = level * basicIncome * (1 + improvements[0].GetImprovementModel.FinalBoost + 
                                               improvements[1].GetImprovementModel.FinalBoost);
        return newIncome;
    }
}
