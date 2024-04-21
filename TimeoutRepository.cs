using System;
using System.Data;
using MySql.Data.MySqlClient;

class TimeoutRepository
{


    private readonly string _stringConexao;

    public TimeoutRepository(string stringConexao)
    {
        _stringConexao = stringConexao;
    }

    public void SaveTimeout(int timeout)
    {
        using (var conexao = new MySqlConnection(_stringConexao))
        {
            conexao.Open();
            MySqlCommand command = new MySqlCommand("INSERT INTO Timeouts (Timeout) VALUES (@Timeout)", conexao);
            command.Parameters.AddWithValue("@Timeout", timeout);
            command.ExecuteNonQuery();
        }
    }

    public int GetLastTimeout()
    {
        using (var conexao = new MySqlConnection(_stringConexao))
        {
            conexao.Open();
            MySqlCommand command = new MySqlCommand("SELECT * FROM Timeouts ORDER BY Id DESC", conexao);
            var result = command.ExecuteScalar();
            return result != DBNull.Value ? Convert.ToInt32(result) : -1;
        }
    }

    public void TestarConexao()
    {
        using (var conexao = new MySqlConnection(_stringConexao))
        {
            try
            {
                conexao.Open();
                Console.WriteLine("Conexão bem-sucedida!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao conectar: {ex.Message}");
            }
        }
    }
}