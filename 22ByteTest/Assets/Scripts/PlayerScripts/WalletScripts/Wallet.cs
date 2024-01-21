using System;
using Zenject;

namespace PlayerScripts.WalletScripts
{
    public class Wallet : IMoneyChangedView, IInitializable
    {
        public int Money { get; private set; }

        public Wallet(int money)
        {
            if(money < 0)
                throw new ArgumentException(nameof(money));

            Money = money;
        }
    
        public event Action<int> OnMoneyChanged;

        public bool IsEnough(int moneyToTake) => Money - moneyToTake >= 0;

        public void AddMoney(int moneyToAdd)
        {
            if(moneyToAdd < 0)
                throw new ArgumentException(nameof(moneyToAdd));

            Money += moneyToAdd;
            OnMoneyChanged?.Invoke(Money);
        }

        public void TakeMoney(int moneyToTake)
        {
            if(moneyToTake < 0)
                throw new ArgumentException(nameof(moneyToTake));

            Money -= moneyToTake;
            OnMoneyChanged?.Invoke(Money);
        }

        public void Initialize()
        {
            OnMoneyChanged?.Invoke(Money);
        }
    }
}
