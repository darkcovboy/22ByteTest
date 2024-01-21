using System.Collections.Generic;
using UnityEngine;

namespace MainScene.Levels
{
    [CreateAssetMenu(fileName = "Container", menuName = "Levels/Container", order = 0)]
    public class LevelInfoContainer : ScriptableObject
    {
        [SerializeField] private List<Level> _levels;

        public IReadOnlyList<Level> Level => _levels;
    }
}