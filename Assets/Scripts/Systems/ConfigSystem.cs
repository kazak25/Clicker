using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigSystem : MonoBehaviour
{
   
    private int _level;
    private int _basicIncome;
    private int _improvement1;
    private int _improvement2;
    
    private int RecalculationIncome()
    {
        var newIncome = _level * _basicIncome * (1 + _improvement1 + _improvement2);
        return newIncome;
    }
}
