using System;
using Sirenix.OdinInspector;

namespace MainScene.Levels
{
    [Serializable]
    public class Level
    {
        public string Name;
        public string NameToLoad;
        public int Id;
        public bool IsOpen;
        public int Price;
    }
}