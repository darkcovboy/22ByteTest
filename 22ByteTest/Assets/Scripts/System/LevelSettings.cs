using UnityEngine;

namespace System
{
    [CreateAssetMenu(fileName = "Settings", menuName = "Level/Settings", order = 0)]
    public class LevelSettings : ScriptableObject
    {
        [SerializeField, Min(1)] private int _countCollectFruits;
        [SerializeField, Min(1)] private int _reward;
        [SerializeField, Min(1)] private int _seconds;
        [SerializeField, Min(1)] private int _extraReward;

        public int CountCollectFruits => _countCollectFruits;

        public int Reward => _reward;

        public int Seconds => _seconds;

        public int ExtraReward => _extraReward;
    }
}