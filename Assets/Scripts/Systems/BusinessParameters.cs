using UnityEngine;
using Slider = UnityEngine.UI.Slider;

public class BusinessParameters : MonoBehaviour
{
    public LevelSettings _levelSettings;
    
    [SerializeField] private Profit _profit;
    
    [SerializeField] private Slider _slider;
    
    private float _timer;

    private void Start()
    {
        _slider.maxValue = _levelSettings.GetDelayIncome;
    }
    
   private void Update()
   {
       UpdateSlider();
   }

   private void UpdateSlider()
   {
       _timer += Time.deltaTime;
       _slider.value = _timer;
       
       if (_timer>=_levelSettings.GetDelayIncome)
       {
           _profit.IncreaseProfit(_levelSettings.GetBasicPrice);
           _timer=0;
       }
   }
}
