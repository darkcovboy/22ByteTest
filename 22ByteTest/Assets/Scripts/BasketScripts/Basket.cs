using System.Collections.Generic;
using Items;

namespace BasketScripts
{
    public class Basket
    {
        private readonly List<Fruit> _fruits;
        private readonly ItemType _itemType;
        private readonly FruitsCounter fruitsCounter;

        public Basket(ItemType itemType, FruitsCounter fruitsCounter)
        {
            _fruits = new List<Fruit>();
            _itemType = itemType;
            this.fruitsCounter = fruitsCounter;
        }

        public bool CheckFruit(Fruit fruit) => fruit.ItemType == _itemType;

        public void AddFruit(Fruit fruit)
        {
            _fruits.Add(fruit);
            fruitsCounter.AddFruit();
        }
    }
}