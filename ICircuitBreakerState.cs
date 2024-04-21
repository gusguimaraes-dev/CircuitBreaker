using System;

interface ICircuitBreakerState
{
    void Execute(Action protectedCode, Action onOpen, Action onHalfOpen);
}
