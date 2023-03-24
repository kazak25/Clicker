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

   public void DecreaseTotalBalance(int price)
   {
      _totalBalance -= price;
   }
   
}
