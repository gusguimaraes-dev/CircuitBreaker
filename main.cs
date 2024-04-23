using System;

class Program
{
    public static void Main(string[] args)
    {    // Conexao com banco
        string conexaoString = "Server=sql.freedb.tech;Database=freedb_db_aula01;Uid=freedb_aluno;Pwd=&ta2Vz@C5?EnXbD;";
        TimeoutRepository timeoutRepository = new TimeoutRepository(conexaoString);

        timeoutRepository.TestarConexao();

        // instanciando objeto da classe de gerador de timeouts (com Singleton)

        TimeoutGeneratorSingleton generator = TimeoutGeneratorSingleton.getInstance;

        // testando Circuit Breaker
        CircuitBreaker circuitBreaker = new CircuitBreaker(conexaoString);

        Action protectedCode = () => { Console.WriteLine("Calculadora protegida (Circuito fechado)."); };
        Action onOpen = () => { Console.WriteLine("Circuit Breaker aberto."); };
        Action onHalfOpen = () => { Console.WriteLine("Circuit Breaker meio-aberto."); };




        // Gerador aleatório de Timeouts
        int timeout = generator.GetRandomTimeout();
        Console.WriteLine($"Timeout gerado: {timeout} ms");

        // Condicionais para testar o Circuit Breaker
        if (timeout > 5000)
        {
            circuitBreaker.ChangeState(new OpenState());
            onOpen();
        }
        else if ((timeout > 1001) && (timeout < 5001))
        {
            circuitBreaker.ChangeState(new HalfOpenState());
            onHalfOpen();
        }
        else if (timeout < 1001)
        {
            circuitBreaker.ChangeState(new ClosedState());
            protectedCode();
        }


        //Implementacao de um gerador de números aleatórios para a calculadora.
        Random random = new Random();
        int numero1 = random.Next(1, 100);
        int numero2 = random.Next(1, 100);

        Calculadora calculator = new Calculadora();

        // Adição
        calculator.SetCommand(new AdicaoCommand(numero1, numero2));
        calculator.ExecuteCommand();

        //Subtração
        calculator.SetCommand(new SubtracaoCommand(numero1, numero2));
        calculator.ExecuteCommand();

        //Multiplicação
        calculator.SetCommand(new MultiplicacaoCommand(numero1, numero2));
        calculator.ExecuteCommand();

        //Divisão
        calculator.SetCommand(new DivisaoCommand(numero1, numero2));
        calculator.ExecuteCommand();
    }
}