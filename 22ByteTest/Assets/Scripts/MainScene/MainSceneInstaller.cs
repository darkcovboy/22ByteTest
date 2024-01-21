using Loader;
using MainScene.Levels;
using PlayerScripts.PersistentData;
using PlayerScripts.WalletScripts;
using UnityEngine;
using Zenject;

namespace MainScene
{
    public class MainSceneInstaller : MonoInstaller
    {
        [SerializeField] private LevelsView _levelsView;
        [SerializeField] private LevelFabric _fabric;
        [SerializeField] private LevelInfoContainer _container;

        private PlayerSave _playerSave;
        
        public override void InstallBindings()
        {
            BindPlayerSave();
            BindLoader();
            BindWallet();
            BindLevels();
        }

        private void BindPlayerSave()
        {
            _playerSave = new PlayerSave();
            Container
                    .Bind<PlayerSave>()
                .FromInstance(_playerSave)
                .AsSingle();
        }

        private void BindLoader()
        {
            LevelLoader levelLoader = FindObjectOfType<LevelLoader>();
            Container
                .Bind<LevelLoader>()
                .FromInstance(levelLoader)
                .AsSingle();
        }

        private void BindLevels()
        {
            Container.Bind<LevelFabric>()
                .FromInstance(_fabric)
                .AsSingle();
            Container.Bind<LevelsView>()
                .FromInstance(_levelsView)
                .AsSingle();
            Container.Bind<LevelInfoContainer>()
                .FromInstance(_container)
                .AsSingle();
            Container.BindInterfacesAndSelfTo<LevelsService>()
                .AsSingle()
                .NonLazy();
        }

        private void BindWallet()
        {
            Container.BindInterfacesAndSelfTo<Wallet>().AsSingle().WithArguments(_playerSave.SaveData.Money).NonLazy();
        }
    }
}