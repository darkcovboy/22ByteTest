using PlayerScripts;
using UnityEngine;
using Zenject;

namespace System
{
    [CreateAssetMenu(fileName = "Fabric", menuName = "Level/Fabric", order = 0)]
    public class GameplaySceneFabric : ScriptableObject
    {
        [SerializeField] private Player _playerPrefab;
        
        //We also can put here spawns fruits or another objects

        public Player GetPlayer(DiContainer container, Transform position)
        {
            return container
                .InstantiatePrefabForComponent<Player>(_playerPrefab, position.position,
                Quaternion.identity, null);
        }
    }
}