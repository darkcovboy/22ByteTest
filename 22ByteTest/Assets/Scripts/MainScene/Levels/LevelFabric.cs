using UnityEngine;

namespace MainScene.Levels
{
    [CreateAssetMenu(fileName = "Fabric", menuName = "Levels/Fabric", order = 1)]
    public class LevelFabric : ScriptableObject
    {
        [SerializeField] private LevelView _prefab;

        public LevelView Get(Level levelInfo, Transform container)
        {
            LevelView levelVIew = Instantiate(_prefab, container);
            levelVIew.Constructor(levelInfo);
            return levelVIew;
        }
    }
}