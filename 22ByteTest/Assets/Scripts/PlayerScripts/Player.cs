using System;
using BasketScripts;
using Items;
using UnityEngine;
using Zenject;

namespace PlayerScripts
{
    public class Player : MonoBehaviour, IDieHandler
    {
        private Basket _basket;

        public event Action OnPlayerDie;

        [Inject]
        public void Constructor(IGameWinning gameWinning)
        {
            gameWinning.OnGameWin += () =>
            {
                Destroy(gameObject);
            };
        }

        public void AddFruit(Fruit fruit)
        {
            if (_basket == null)
            {
                OnPlayerDie?.Invoke();
                return;
            }
            
            if (_basket.CheckFruit(fruit))
                _basket.AddFruit(fruit);
            else
                OnPlayerDie?.Invoke();
        }

        public void ChangeCurrentBasket(Basket basket)
        {
            _basket = basket;
        }
    }
}