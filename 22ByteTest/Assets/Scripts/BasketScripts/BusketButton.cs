using System;
using Items;
using PlayerScripts;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace BasketScripts
{
    public class BusketButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private ItemType _itemType;
        [SerializeField] private Image _selectedImage;

        private Player _player;
        private Basket _basket;
        private BusketButtonManager _busketButtonManager;
        
        [Inject]
        public void Constructor(Player player, FruitsCounter fruitsCounter, BusketButtonManager buttonManager)
        {
            _player = player;
            _basket = new Basket(_itemType, fruitsCounter);
            _busketButtonManager = buttonManager;
            _busketButtonManager.AddBusketButton(this);
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(ChangeBasket);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(ChangeBasket);
        }

        public void Unselect() => _selectedImage.gameObject.SetActive(false);
        
        private void Select() => _selectedImage.gameObject.SetActive(true);

        private void ChangeBasket()
        {
            _player.ChangeCurrentBasket(_basket);
            _busketButtonManager.UnselectButtons();
            Select();
        }
    }
}