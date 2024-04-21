using System;
class DivisaoCommand : ICommand 
{
  private readonly int _a, _b;
  public DivisaoCommand(int a, int b) 
  {
    _a = a;
    _b = b;
  }
  public void Execute()
  {
      if (_b != 0)
      {
          Console.WriteLine($"{_a} / {_b} = {_a / _b}");
      }
      else
      {
          Console.WriteLine("Não é possível dividir por zero.");
      }
  }
}