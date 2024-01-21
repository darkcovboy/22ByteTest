using PlayerScripts;
using UI.TimerScripts;
using UnityEngine;

namespace System
{
    public class GameLoseManager
    {
        private Player _player;
        private Timer _timer;

        public event Action OnLose;
        

        public GameLoseManager(Player player, Timer timer, DieCheck dieCheck)
        {
            _player = player;
            _timer = timer;
            player.OnPlayerDie += OnGameLose;
            timer.OnPlayerDie += OnGameLose;
            dieCheck.OnPlayerDie += OnGameLose;
        }
        
        private void OnGameLose()
        {
            if(_player != null)
                UnityEngine.Object.Destroy(_player.gameObject);
            
            _timer.StopTimer();
            OnLose?.Invoke();
        }
    }
}