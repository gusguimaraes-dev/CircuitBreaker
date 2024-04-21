using System;
using System.Data;
using MySql.Data.MySqlClient;

class Repository
{
    
    
        private readonly string _stringConexao;

        public ConexaoBD(string host, string dbName, string user, string password)
        {
            _stringConexao = $"Server={host};Database={dbName};Uid={user};Pwd={password};";
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