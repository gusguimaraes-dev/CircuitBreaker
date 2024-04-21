using System;
class AdicaoCommand : ICommand 
{
  private readonly int _a, _b;
  public AdicaoCommand(int a, int b) 
  {
    _a = a;
    _b = b;
  }
  public void Execute() 
  {
    Console.WriteLine($"{_a} + {_b} = {_a + _b}");
  }
}