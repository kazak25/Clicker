using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class ConfigSystem : MonoBehaviour
{
    [SerializeField] private List<BusinessParameters> _business = new List<BusinessParameters>();
    
    private Dictionary<string, BusinessParameters> _data = new Dictionary<string, BusinessParameters>();

    private int _level;
    private int _basicIncome;
    private int _improvement1;
    private int _improvement2;
    private int _basicPrice;

    private void Awake()
    {
        foreach (var business  in _business)
        {
            _data.Add(business._levelSettings.GetName,business);  
        }
    }

    private void Start()
    {
        var s = _data["Darknet"];
        Debug.Log(s.name);
        Debug.Log(s._levelSettings.GetBasicPrice);
        Debug.Log(s._levelSettings.GetBaseIncome);
        Debug.Log(s._levelSettings.GetImprovement2);
        Debug.Log(s._levelSettings.GetImprovement1);
    }


    public void Initialize(int level, int basicPrice,int basicIncome, int improvement1,int improvement2)
    {
        _level = level;
        _basicIncome = basicIncome;
        _basicPrice = basicPrice;
        _improvement1 = improvement1;
        _improvement2 = improvement2;
    }
    public int RecalculationIncome()
    {
        var newIncome = _level * _basicIncome * (1 + _improvement1 + _improvement2);
        return newIncome;
    }

    [UsedImplicitly]
    public void GetRecalculationIncome()
    {
        RecalculationIncome();
    }
}
