using System;

namespace PlayerScripts.WalletScripts
{
    public interface IMoneyChangedView
    {
        event Action<int> OnMoneyChanged;
    }
}