using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameView : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private TextMeshProUGUI _totalBalance;
    private Profit _profit;

    public void Initialize(Profit profit)
    {
        _profit = profit;
    }

    // Update is called once per frame
    void Update()
    {
        var balance = _profit.GetBalance().ToString();
        _totalBalance.text = "Balance " +  balance;
    }
}
