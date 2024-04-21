using System;
public class TimeoutGeneratorSingleton
{
    private static TimeoutGeneratorSingleton _instance;
    private readonly Random _random;

    private TimeoutGeneratorSingleton()
    {
        _random = new Random();
    }

    public static TimeoutGeneratorSingleton getInstance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new TimeoutGeneratorSingleton();
            }
            return _instance;
        }
    }

    public int GetRandomTimeout()
    {
        return _random.Next(1000, 10001);
    }
}