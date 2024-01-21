using System;

namespace PlayerScripts.Movement.SwipeDetector
{
    public interface ISwipeDetector
    {
        public event Action<SwipeData> OnSwipe;
    }
}