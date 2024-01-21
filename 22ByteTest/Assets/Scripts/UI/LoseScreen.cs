using System;
using Loader;
using PlayerScripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class LoseScreen : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;

        private LevelLoader _levelLoader;

        [Inject]
        public void Constructor(LevelLoader levelLoader, GameLoseManager gameLoseManager)
        {
            _levelLoader = levelLoader;
            gameLoseManager.OnLose += () =>
            {
                gameObject.SetActive(true);
            };
        }

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(Restart);
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(Restart);
        }

        private void Restart()
        {
            _levelLoader.Load(SceneManager.GetActiveScene().name);
        }
    }
}