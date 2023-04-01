using Events;
using Models;
using Systems;
using UnityEngine;
using Slider = UnityEngine.UI.Slider;

namespace GameView
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        private ProfitSystem _profitSystem; //Сделать через EventBus
   
        private BusinessModel _model;
        private int _maxValue;
        private float _timer;

        private void Start()
        {
            _slider.maxValue = _model.GetDelayIncome;
        }

        public void Initialize(ProfitSystem profitSystem)
        {
            _profitSystem = profitSystem;
        }

        public void Initialize(BusinessModel model)
        {
            _model = model;
        }
   
        private void Update()
        {
            UpdateSlider();
        }

        private void UpdateSlider()
        {
            if (_model.GetCurrentLevel == 0)
            {
                return;
            }
            _timer += Time.deltaTime;
            _slider.value = _timer;
            if (_timer>=_model.GetDelayIncome)
            {
                var eventDataRequest = new GetIncomeEvent(_model.GetCurrentIncome);
                EventStream.Game.Publish(eventDataRequest);
                _timer=0;
            }
        }
    }
}
