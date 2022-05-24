using Npgsql;


namespace DataBaseControl
{
    /// <summary>
    /// Classe utilizada para o controle de conexão da base de dados
    /// </summary>
    public class DataBaseConnection
    {
        NpgsqlConnection StringConexao;

        /// <summary>
        /// Inicia conexão com o banco de dados.
        /// </summary>
        /// <returns>Retorna string de conexão para a base de dados.</returns>
        public NpgsqlConnection StartDataBaseConnection()
        {
            try
            {
                if (StringConexao == null)
                {
                    StringConexao = new NpgsqlConnection();

                    StringConexao.ConnectionString = @"Server = localhost; Port = 5432; Database = DBGerencialNET; User Id = postgres; Password = porcos128";

                    StringConexao.Open();
                }
                return StringConexao;
            }
            catch(Exception ex)
            {
                EndDataBaseConnection();
                throw ex;
            }
         }

        /// <summary>
        /// Finaliza a conexão com o banco de dados.
        /// </summary>
        public void EndDataBaseConnection()
        { 
            if (StringConexao != null)
            {
                StringConexao.Dispose();
            }
        }
    }
}
