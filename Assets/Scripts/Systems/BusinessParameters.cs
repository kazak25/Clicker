using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusinessParameters : MonoBehaviour
{
    // [SerializeField] private GameObject _currentIncome;
    //[SerializeField] private GameObject _currentLevel;
    [SerializeField] private LevelSettings _levelSettings;
    //
    [SerializeField] private Profit _profit;

   public IEnumerator Timer()
   {
       if (_levelSettings.GetCurrentLevel == 0)
       {
           yield break;
       }
       var waitingTime = _levelSettings.GetDelayIncome;
       yield return new WaitForSeconds(waitingTime);
        _profit.IncreaseProfit(_levelSettings.GetCurrentIncome);
        

   }

   private void Start()
   {
       StartCoroutine(Timer());
   }
}
