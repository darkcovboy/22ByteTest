using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace PlayerScripts.PersistentData
{
    public class PlayerSave
    {
        private const string DataPath = "Assets/Resources/Data/Data.json";

        public PlayerSave()
        {
            string json = File.ReadAllText(DataPath);

            if (string.IsNullOrEmpty(json) || json == "{}")
            {
                SaveData = CreateNewData();
                Save();
            }
            else
            {
                SaveData = JsonUtility.FromJson<SaveData>(json);
            }
        }

        public SaveData SaveData { get;}

        public void UpdateMoney(int money) => SaveData.Money = money;
        public void UpdateLevels(int id) => SaveData.OpenedLevels.Add(id);
        
        public void Save()
        {
            string json = JsonUtility.ToJson(SaveData);
            File.WriteAllText(DataPath, json);
        }

        private SaveData CreateNewData()
        {
            SaveData saveData = new SaveData();
            saveData.Money = 1;
            saveData.OpenedLevels = new List<int>()
            {
                0,
                1
            };
            return saveData;
        }
    }

    public class SaveData
    {
        public int Money;
        public List<int> OpenedLevels;
    }
}