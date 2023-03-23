using TMPro;
using UnityEngine;

public class GameView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _totalBalance;
    private Profit _profit;

    public void Initialize(Profit profit)
    {
        _profit = profit;
    }
    
    void Update()
    {
        var balance = _profit.GetBalance().ToString();
        _totalBalance.text = "Balance: " +  balance + "$";
    }
}
