using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace Items
{
    public class FruitsCountnerView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        
        private IFruitChanged _fruitChanged;
        
        [Inject]
        public void Constructor(IFruitChanged fruitChanged)
        {
            _fruitChanged = fruitChanged;
        }

        private void OnEnable()
        {
            _fruitChanged.OnFruitsCountChanged += OnFruitCountChanged;
        }

        private void OnDisable()
        {
            _fruitChanged.OnFruitsCountChanged -= OnFruitCountChanged;
        }

        private void OnFruitCountChanged(int min, int max) => _text.text = $"{min}/{max}";
    }
}