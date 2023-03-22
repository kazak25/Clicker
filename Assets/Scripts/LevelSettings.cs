using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "business", menuName = "Businesses")]
public class LevelSettings : ScriptableObject
{
    [SerializeField] private GameObject _gameObject;
    
    [SerializeField] private int DelayIncome;
    [SerializeField] private int BasicPrice;
    [SerializeField] private int BaseIncome;
    [SerializeField] private int Improvement1;
    [SerializeField] private int Improvement2;

    public int GetDelayIncome => DelayIncome;
    public int GetBasicPrice => BasicPrice;
    public int GetBaseIncome => BaseIncome;
    public int GetImprovement1 => Improvement1;
    public int GetImprovement2 => Improvement2;
}
