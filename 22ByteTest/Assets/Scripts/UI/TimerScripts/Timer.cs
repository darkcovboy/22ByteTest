using System;
using System.Collections;
using Items;
using PlayerScripts;
using UnityEngine;
using Zenject;

namespace UI.TimerScripts
{
    public class Timer : IDieHandler, IInitializable
    {
        private ICoroutineRunner _coroutineRunner;
        private int _time;
        private Player _player;
        
        
        public Timer(int time, ICoroutineRunner coroutineRunner, Player player, IGameWinning gameWinning)
        {
            _time = time;
            _player = player;
            _coroutineRunner = coroutineRunner;
            gameWinning.OnGameWin += StopTimer;
        }
        
        public event Action OnPlayerDie;
        public event Action<int> OnTimeChanged;
        
        public void Initialize()
        {
            _coroutineRunner.StartCoroutine(UpdateTimer());
        }

        public void StopTimer()
        {
            _coroutineRunner.StopCoroutine(UpdateTimer());
        }

        private IEnumerator UpdateTimer()
        {
            while (_time > 0)
            {
                yield return new WaitForSeconds(1f);
                _time--;
                OnTimeChanged?.Invoke(_time);
            }
            
            OnPlayerDie?.Invoke();
        }
    }
}