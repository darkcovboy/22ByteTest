using System;
using UnityEngine;

namespace PlayerScripts
{
    [RequireComponent(typeof(Collider))]
    public class DieCheck : MonoBehaviour
    {
        public event Action OnPlayerDie;
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent<Player>(out Player player))
                OnPlayerDie?.Invoke();
        }
    }
}