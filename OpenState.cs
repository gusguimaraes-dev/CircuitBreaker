using System;

class OpenState : ICircuitBreakerState
{
    public void Execute(Action protectedCode, Action onOpen, Action onHalfOpen)
    {
        onOpen.Invoke();
    }
}