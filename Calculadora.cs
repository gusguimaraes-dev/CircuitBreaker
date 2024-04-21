using System;
class Calculadora
{
  private ICommand _command;
  public void SetCommand(ICommand command)
  {
    _command = command;
  }
  public void ExecuteCommand() 
  {
    _command.Execute();
  }
}