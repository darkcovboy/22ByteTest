using System;
using Zenject;

namespace Items
{
    public class FruitsCounter : IFruitChanged, IGameWinning, IInitializable
    {
        private const int MINFruits = 0;
        private int _minFruits;
        private int _maxFruits;

        public event Action<int, int> OnFruitsCountChanged;
        public event Action OnGameWin;

        public FruitsCounter(int maxFruits)
        {
            _maxFruits = maxFruits;
            _minFruits = MINFruits;
        }

        public void AddFruit()
        {
            _minFruits++;
            OnFruitsCountChanged?.Invoke(_minFruits,_maxFruits);
            
            if(_minFruits == _maxFruits)
                OnGameWin?.Invoke();
        }

        public void Initialize()
        {
            OnFruitsCountChanged?.Invoke(_minFruits,_maxFruits);
        }
    }
}