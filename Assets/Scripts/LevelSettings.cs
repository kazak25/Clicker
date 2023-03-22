using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "business", menuName = "Businesses")]
public class LevelSettings : ScriptableObject
{

    [SerializeField] private int _delayIncome;
    [SerializeField] private int _basicPrice;
    [SerializeField] private int _baseIncome;
    [SerializeField] private int _improvement1;
    [SerializeField] private int _improvement2;
    [SerializeField] private int _currentIncome;
    [SerializeField] private int _currentLevel;
    public int GetDelayIncome => _delayIncome;
    public int GetBasicPrice => _basicPrice;
    public int GetBaseIncome => _baseIncome;
    public int GetImprovement1 => _improvement1;
    public int GetImprovement2 => _improvement2;
}