using System;

class CircuitBreaker
{
    private ICircuitBreakerState _state;
    private TimeoutRepository _timeoutRepository;

    public CircuitBreaker(string _stringConexao)
    {
        _state = new ClosedState();
        _timeoutRepository = new TimeoutRepository(_stringConexao);
    }

    public void Execute(Action protectedCode, Action onOpen, Action onHalfOpen)
    {
        int timeout = TimeoutGeneratorSingleton.getInstance.GetRandomTimeout();
        _timeoutRepository.SaveTimeout(timeout);

        _state.Execute(protectedCode, onOpen, onHalfOpen);
    }

    public void ChangeState(ICircuitBreakerState state)
    {
        _state = state;  
    }

}