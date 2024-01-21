using System;

namespace PlayerScripts
{
    public interface IDieHandler
    {
        event Action OnPlayerDie;
    }
}