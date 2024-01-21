using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MainScene.Levels
{
    public class LevelView : MonoBehaviour, IPointerClickHandler
    {
        public event Action<LevelView> OnClick;
        
        [SerializeField] private TMP_Text _levelNumber;
        [SerializeField] private Image _lockImage;
        [SerializeField] private TMP_Text _price;

        public void Constructor(Level level)
        {
            LevelInfo = level;
            _levelNumber.text = level.Name;
            if (level.IsOpen)
            {
                _lockImage.gameObject.SetActive(false);
                _price.gameObject.SetActive(false);
            }
            else
                _price.text = level.Price.ToString();
        }

        public Level LevelInfo { get; private set; }


        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick?.Invoke(this);
        }

        public void OpenLevel()
        {
            LevelInfo.IsOpen = true;
            _lockImage.gameObject.SetActive(false);
            _price.gameObject.SetActive(false);
        }

        public void ShowError()
        {
            //We can add here some animation 
        }
    }
}