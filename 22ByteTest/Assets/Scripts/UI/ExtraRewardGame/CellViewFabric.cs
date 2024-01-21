using System;
using System.Collections.Generic;
using System.Linq;
using Items;
using UnityEngine;

namespace UI.ExtraRewardGame
{
    [CreateAssetMenu(fileName = "fabric", menuName = "Match3Game/Fabric", order = 0)]
    public class CellViewFabric : ScriptableObject
    {
        [SerializeField] private CellView _cellViewPrefab;
        [SerializeField] private List<SpriteComparison> _spriteComparisons;

        public CellView Get(Cell cell,Transform container)
        {
            CellView cellView = Instantiate(_cellViewPrefab, container);
            cellView.Constructor(cell, _spriteComparisons.First(x => x.ItemType == cell.ItemType).Sprite);
            return cellView;
        }
    }

    [Serializable]
    public class SpriteComparison
    {
        public ItemType ItemType;
        public Sprite Sprite;
    }
}