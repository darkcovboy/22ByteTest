using System;

namespace Items
{
    public interface IFruitChanged
    {
        event Action<int, int> OnFruitsCountChanged;
    }
}