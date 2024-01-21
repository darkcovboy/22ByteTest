using System;

namespace Items
{
    public interface IGameWinning
    {
        event Action OnGameWin;
    }
}