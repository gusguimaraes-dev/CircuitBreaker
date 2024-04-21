using System;

class HalfOpenState : ICircuitBreakerState
{
    public void Execute(Action protectedCode, Action onOpen, Action onHalfOpen)
    {
        onHalfOpen.Invoke();
    }
}