using System;

class ClosedState : ICircuitBreakerState
{
    public void Execute(Action protectedCode, Action onOpen, Action onHalfOpen)
    {
        protectedCode.Invoke();
    }
}