using BasketScripts;
using Items;
using Loader;
using PlayerScripts;
using PlayerScripts.Movement.SwipeDetector;
using PlayerScripts.PersistentData;
using PlayerScripts.WalletScripts;
using UI;
using UI.ExtraRewardGame;
using UI.TimerScripts;
using UnityEngine;
using Zenject;

namespace System
{
    public class GameplaySceneInstaller : MonoInstaller, ICoroutineRunner
    {
        [SerializeField] private SwipeDetector _swipeDetector;
        [SerializeField] private Player _playerPrefab;
        [SerializeField] private DieCheck _dieCheck;
        [SerializeField] private LevelSettings _levelSettings;
        [SerializeField] private GameplaySceneFabric _fabric;
        [SerializeField] private WinScreen _winScreen;
        [SerializeField] private CellViewFabric _cellViewFabric;
        [Header("Positions")] 
        [SerializeField] private Transform _playerPosition;

        private PlayerSave _playerSave;

        public override void InstallBindings()
        {
            BindPlayerSave();
            BindLevelSettings();
            BindLoader();
            BindSwipe();
            BindFruits();
            BindBasket();
            BindWallet();
            BindPlayer();
            BindTimer();
            BindLoseManager();
            BindWinScreen();
        }

        private void BindLevelSettings()
        {
            Container.BindInterfacesAndSelfTo<GameplaySceneInstaller>().FromInstance(this).AsSingle();
            Container.Bind<LevelSettings>().FromInstance(_levelSettings).AsSingle();
        }

        private void BindPlayerSave()
        {
            _playerSave = new PlayerSave();
            Container.Bind<PlayerSave>().FromInstance(_playerSave).AsSingle();
        }

        private void BindWinScreen()
        {
            Container.Bind<WinScreen>()
                .FromInstance(_winScreen)
                .AsSingle();
            Container.Bind<CellViewFabric>()
                .FromInstance(_cellViewFabric)
                .AsSingle();
        }

        private void BindLoseManager()
        {
            Container.BindInterfacesAndSelfTo<GameLoseManager>()
                .AsSingle()
                .NonLazy();
        }

        private void BindTimer()
        {
            Container.BindInterfacesAndSelfTo<Timer>()
                .AsSingle()
                .WithArguments(_levelSettings.Seconds);
        }

        private void BindLoader()
        {
            LevelLoader levelLoader = FindObjectOfType<LevelLoader>();
            Container.Bind<LevelLoader>()
                .FromInstance(levelLoader)
                .AsSingle();
        }

        private void BindBasket()
        {
            Container.BindInterfacesAndSelfTo<BusketButtonManager>()
                .AsSingle()
                .NonLazy();
        }

        private void BindFruits()
        {
            Container.BindInterfacesAndSelfTo<FruitsCounter>()
                .AsSingle()
                .WithArguments(_levelSettings.CountCollectFruits)
                .NonLazy();
        }

        private void BindSwipe()
        {
            Container.BindInterfacesAndSelfTo<SwipeDetector>()
                .FromInstance(_swipeDetector)
                .AsSingle();
        }

        private void BindPlayer()
        {
            Container.Bind<DieCheck>().FromInstance(_dieCheck).AsSingle();
            Player player = _fabric.GetPlayer(Container, _playerPosition);
            Container.BindInterfacesAndSelfTo<Player>()
                .FromInstance(player)
                .AsSingle();
        }
        
        private void BindWallet()
        {
            Container.BindInterfacesAndSelfTo<Wallet>()
                .AsSingle()
                .WithArguments(_playerSave.SaveData.Money)
                .NonLazy();
        }
    }
}