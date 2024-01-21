using System;
using System.Collections.Generic;
using Items;
using UnityEngine;
using Zenject;
using Random = System.Random;

namespace UI.ExtraRewardGame
{
    public class Match3Game : MonoBehaviour
    {
        private const int MaxColumn = 3;
        private const int MaxRow = 3;
        private const int MaxToChoose = 3;
        
        [SerializeField] private Transform _container;

        private CellViewFabric _cellViewFabric;
        private WinScreen _winScreen;
        private List<ItemType> _collected;
        
        [Inject]
        public void Constructor(CellViewFabric cellViewFabric, WinScreen winScreen)
        {
            _cellViewFabric = cellViewFabric;
            _winScreen = winScreen;
        }
        
        private void OnEnable()
        {
            CreateMatrix();
        }

        private void CreateMatrix()
        {
            ItemType[,] matrix = GenerateRandomMatrix();
            _collected = new List<ItemType>();


            for (int i = 0; i < MaxRow; i++)
            {
                for (int j = 0; j < MaxColumn; j++)
                {
                    Cell cell = new Cell(i, j, matrix[i,j]);
                    CellView cellView = _cellViewFabric.Get(cell, _container);
                    cellView.OnClick += OpenCell;
                }
            }
        }

        private void OpenCell(CellView cellView)
        {
            if(_collected.Count == MaxToChoose)
                return;
            
            _collected.Add(cellView.Cell.ItemType);
            cellView.Open();

            if (_collected.Count == MaxToChoose)
            {
                if (AreAllObjectsEquel(_collected))
                    _winScreen.MultiplyReward();
                
                gameObject.SetActive(false);
            }
        }

        private bool AreAllObjectsEquel(List<ItemType> itemTypes)
        {
            return itemTypes.TrueForAll(i => i == itemTypes[0]);
        }

        private ItemType[,] GenerateRandomMatrix()
        {
            ItemType[,] matrix = new ItemType[MaxColumn,MaxRow];

            Array values = Enum.GetValues(typeof(ItemType));
            Random random = new Random();
            
            for (int i = 0; i < MaxRow; i++)
            {
                for (int j = 0; j < MaxColumn; j++)
                {
                    ItemType itemType = (ItemType)values.GetValue(random.Next(values.Length));
                    matrix[i, j] = itemType;
                    Debug.Log(i + " " + j + " " + itemType);
                }
            }

            return matrix;
        }
    }
}