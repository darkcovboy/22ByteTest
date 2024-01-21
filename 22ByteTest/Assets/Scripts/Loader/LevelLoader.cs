using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Loader
{
    public class LevelLoader : MonoBehaviour
    {
        private const string MainSceneLevelName = "MainScene";
        
        [SerializeField] private Slider _loadingBar;

        public static LevelLoader Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
                return;
            }
            
            gameObject.SetActive(true);
            Instance = this;
            Load(MainSceneLevelName);
            DontDestroyOnLoad(gameObject);
        }

        public void Load(string name)
        {
            gameObject.SetActive(true);
            StartCoroutine(LoadAsync(name));
        }

        private IEnumerator LoadAsync(string name)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(name);
            _loadingBar.maxValue = 1;

            while (!operation.isDone)
            {
                float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
                _loadingBar.value = progressValue;

                yield return null;
            }

            gameObject.SetActive(false);
        }
    }
}