using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.ExtraRewardGame
{
    public class CellView : MonoBehaviour, IPointerClickHandler
    {
        public Action<CellView> OnClick;
        
        [SerializeField] private Image _closedImage;
        [SerializeField] private Image _fruitImage;
        
        public void Constructor(Cell cell, Sprite fruitSprite)
        {
            Cell = cell;
            _fruitImage.sprite = fruitSprite;
        }
        
        public Cell Cell { get; private set; }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick?.Invoke(this);
        }

        public void Open()
        {
            _closedImage.gameObject.SetActive(false);
            _fruitImage.gameObject.SetActive(true);
        }
    }
}