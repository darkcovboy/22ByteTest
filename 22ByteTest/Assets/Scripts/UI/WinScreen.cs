using System;
using Items;
using Loader;
using PlayerScripts.PersistentData;
using PlayerScripts.WalletScripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class WinScreen : MonoBehaviour
    {
        private const string EarnedText = "You earned:";
        private const string MainMenuName = "MainScene";

        [SerializeField] private TMP_Text _rewardText;
        [SerializeField] private Button _loadButton;
        
        private Wallet _wallet;
        private LevelSettings _levelSettings;
        private LevelLoader _levelLoader;
        private PlayerSave _playerSave;
        
        [Inject]
        public void Constructor(IGameWinning gameWinning, Wallet wallet, LevelSettings levelSettings, LevelLoader levelLoader, PlayerSave playerSave)
        {
            _wallet = wallet;
            _levelSettings = levelSettings;
            _levelLoader = levelLoader;
            _playerSave = playerSave;
            gameWinning.OnGameWin += () =>
            {
                gameObject.SetActive(true);
            };
        }

        private void OnEnable()
        {
            _rewardText.text = $"{EarnedText} {_levelSettings.Reward}";
            _wallet.AddMoney(_levelSettings.Reward);
            _loadButton.onClick.AddListener(LoadMainMenu);
        }

        private void OnDisable()
        {
            _loadButton.onClick.RemoveListener(LoadMainMenu);
        }

        public void MultiplyReward()
        {
            _rewardText.text = $"{EarnedText} {_levelSettings.Reward + _levelSettings.ExtraReward}";
            _wallet.AddMoney(_levelSettings.ExtraReward);
        }

        private void LoadMainMenu()
        {
            _playerSave.UpdateMoney(_wallet.Money);
            _playerSave.Save();
            _levelLoader.Load(MainMenuName);
        }
    }
}