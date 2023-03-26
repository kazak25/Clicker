using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
   [SerializeField] private Profit profit;
   [SerializeField] private BalanceView _balanceView;
   
   
   private void Start()
   {
       _balanceView.Initialize(profit);
   }

  
}
