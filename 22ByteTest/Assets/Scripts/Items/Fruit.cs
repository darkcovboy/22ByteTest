using System;
using PlayerScripts;
using UnityEngine;

namespace Items
{
    public class Fruit : MonoBehaviour
    {
        [SerializeField] private ItemType _itemType;

        public ItemType ItemType => _itemType;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                player.AddFruit(this);
                Destroy(gameObject);
            }
        }
    }
}