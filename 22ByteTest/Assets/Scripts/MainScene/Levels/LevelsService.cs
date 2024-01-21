using System.Collections.Generic;
using Loader;
using PlayerScripts.PersistentData;
using PlayerScripts.WalletScripts;
using Zenject;

namespace MainScene.Levels
{
    public class LevelsService : IInitializable
    {
        private LevelsView _levelsView;
        private readonly LevelInfoContainer _levelInfoContainer;
        private readonly LevelFabric _levelFabric;
        private List<LevelView> _levelViews;
        private Wallet _wallet;
        private LevelLoader _levelLoader;
        private PlayerSave _playerSave;

        public LevelsService(LevelsView levelsView, LevelInfoContainer levelInfoContainer, LevelFabric levelFabric, Wallet wallet, LevelLoader levelLoader, PlayerSave playerSave)
        {
            _levelsView = levelsView;
            _levelInfoContainer = levelInfoContainer;
            _levelFabric = levelFabric;
            _wallet = wallet;
            _levelLoader = levelLoader;
            _playerSave = playerSave;
        }
        
        public void Initialize()
        {
            _levelViews = new List<LevelView>();
            CreateLevels();
        }

        private void CreateLevels()
        {
            foreach (var level in _levelInfoContainer.Level)
            {
                var item = _levelFabric.Get(level, _levelsView.Container);
                if(_playerSave.SaveData.OpenedLevels.Contains(level.Id))
                    item.OpenLevel();
                item.OnClick += OnClick;
                _levelViews.Add(item);
            }
        }

        private void OnClick(LevelView levelView)
        {
            if (levelView.LevelInfo.IsOpen)
            {
                _levelLoader.Load(levelView.LevelInfo.NameToLoad);
            }
            else
            {
                if (_wallet.IsEnough(levelView.LevelInfo.Price))
                {
                    _wallet.TakeMoney(levelView.LevelInfo.Price);
                    levelView.OpenLevel();
                    _playerSave.UpdateLevels(levelView.LevelInfo.Id);
                    _playerSave.Save();
                }
                else
                {
                    levelView.ShowError();
                }
            }
        }
    }
}