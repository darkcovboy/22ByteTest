using UnityEngine;
using Zenject;

namespace MainScene.Levels
{
    public class LevelsView : MonoBehaviour
    {
        [SerializeField] private Transform _container;

        public Transform Container => _container;
    }
}