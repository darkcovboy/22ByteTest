using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class LevelName : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        private void Start()
        {
            _text.text = SceneManager.GetActiveScene().name;
        }
    }
}