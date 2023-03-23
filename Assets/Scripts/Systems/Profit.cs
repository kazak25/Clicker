using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Profit : MonoBehaviour
{

   private int _totalBalance;

   public void IncreaseProfit(int profit)
   {
      _totalBalance += profit;
   }

   public int GetBalance()
   {
      return _totalBalance;
   }
   
}
