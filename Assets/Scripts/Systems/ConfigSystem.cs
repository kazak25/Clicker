using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigSystem : MonoBehaviour
{
   
    private int level;
    private int basicIncome;
    private int Improvement1;
    private int Improvement2;
    
    private int RecalculationIncome()
    {
        var newIncome = level * basicIncome * (1 + Improvement1 + Improvement2);
        return newIncome;
    }
}
