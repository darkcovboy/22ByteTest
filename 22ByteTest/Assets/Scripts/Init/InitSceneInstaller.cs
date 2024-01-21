using Loader;
using UnityEngine;
using Zenject;

namespace Init
{
    public class InitSceneInstaller : MonoInstaller
    {
        [SerializeField] private LevelLoader _levelLoaderPrefab;
        public override void InstallBindings()
        {
            Container.InstantiatePrefabForComponent<LevelLoader>(_levelLoaderPrefab);
        }
    }
}
