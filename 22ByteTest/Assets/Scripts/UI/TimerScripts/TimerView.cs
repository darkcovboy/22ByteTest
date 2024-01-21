using System;
using TMPro;
using UI.TimerScripts;
using UnityEngine;
using Zenject;

namespace PlayerScripts
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        private Timer _timer;
        
        [Inject]
        public void Constructor(Timer timer)
        {
            _timer = timer;
        }

        private void OnEnable()
        {
            _timer.OnTimeChanged += UpdateTime;
        }

        private void OnDisable()
        {
            _timer.OnTimeChanged -= UpdateTime;
        }

        private void UpdateTime(int timerDuration)
        {
            int minutes = Mathf.FloorToInt(timerDuration / 60);
            int seconds = Mathf.FloorToInt(timerDuration % 60);

            string timerString = $"{minutes:00}:{seconds:00}";

            _text.text = timerString;
        }
    }
}