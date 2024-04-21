using System;
public class RandomTimeoutGenerator
{
    private static RandomTimeoutGenerator _instance;
    private readonly Random _random;

    private RandomTimeoutGenerator()
    {
        _random = new Random();
    }

    public static RandomTimeoutGenerator getInstance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new RandomTimeoutGenerator();
            }
            return _instance;
        }
    }

    public int GetRandomTimeout()
    {
        return _random.Next(1000, 10001);
    }
}