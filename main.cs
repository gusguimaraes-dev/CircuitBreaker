using System;

class Program
{
    public static void Main(string[] args)
    {
      string host = "sql.freedb.tech";
      string dbName = "freedb_db_aula01";
      string user = "freedb_aluno";
      string password = "&ta2Vz@C5?EnXbD";
      
      Repository repository = new Repository(host, dbName, user, password);

        RandomTimeoutGenerator generator = RandomTimeoutGenerator.getInstance;


        for (int i = 0; i < 5; i++)
        {
            int timeout = generator.GetRandomTimeout();
            Console.WriteLine($"Timeout gerado: {timeout} ms");
        }




        /*
          Calculadora calculator = new Calculadora();

          // Adição
          calculator.SetCommand(new AdicaoCommand(10, 5));
          calculator.ExecuteCommand();

          //Subtração
          calculator.SetCommand(new SubtracaoCommand(10, 5));
          calculator.ExecuteCommand();

         //Multiplicação
          calculator.SetCommand(new MultiplicacaoCommand(10, 5));
          calculator.ExecuteCommand();

          //Divisão
          calculator.SetCommand(new DivisaoCommand(10, 5));
          calculator.ExecuteCommand();*/
    }
}