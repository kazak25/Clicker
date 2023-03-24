using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class ConfigSystem : MonoBehaviour
{
    [SerializeField] private List<BusinessController> _business = new List<BusinessController>();
    
    private Dictionary<string, BusinessController> _data = new Dictionary<string, BusinessController>();

   

    private void Awake()
    {
        
        foreach (var business  in _business)
        {
            business.Initialize(this);
            _data.Add(business._businessSettings.GetName,business);  
        }
    }

    public Dictionary<string, BusinessController> GetBuisness()
    {
        return _data;
    }


    public int GetNewLevelPrice(int level, int basicPrice)
    {
        var newLevelPrice = (1 + level) * basicPrice;
        return newLevelPrice;
    }
    public int RecalculationIncome(int level, int basicIncome, int improvement1, int improvement2)
    {
        var newIncome = level * basicIncome * (1 + improvement1 + improvement2);
        return newIncome;
    }

    // [UsedImplicitly]
    // public void GetRecalculationIncome()
    // {
    //     RecalculationIncome();
    // }
}
