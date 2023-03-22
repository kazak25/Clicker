using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class ConfigSystem : MonoBehaviour
{
   
    private int _level;
    private int _basicIncome;
    private int _improvement1;
    private int _improvement2;
    private int _basicPrice;

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
