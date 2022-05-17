using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Npgsql;

namespace DataBaseControl
{
    /// <summary>
    /// Classe utilizada para o controle de persistência da base de dados.
    /// </summary>
    class DataBasePersistenceControl
    {
        NpgsqlCommand ComandoSql;

        /// <summary>
        /// Executa script de leitura e retorna resultado.
        /// </summary>
        /// <param name="ScriptSql">Script Sql para obter registros.</param>
        /// <returns>Retorna resultado obtido a partir de um comando Select.</returns>
        public DataTable BuscaDados(String ScriptSql)
        {
            try
            {
                DataTable DadosDataTable = new DataTable();
                DataBaseConnection ConnectionDB = new DataBaseConnection();
                NpgsqlDataReader DadosDataReader;

                ComandoSql = new NpgsqlCommand(ScriptSql, ConnectionDB.StartDataBaseConnection());

                DadosDataReader = ComandoSql.ExecuteReader();

                DadosDataTable.Load(DadosDataReader);

                return DadosDataTable;
            }
            catch(DataException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Incluir, excluir e modificar registros na base de dados.
        /// </summary>
        /// <param name="ScriptSql">Script Sql para a persistência de dados</param>
        public void PersisteDados(String ScriptSql)
        {
            try
            {
                DataBaseConnection ConexaoBD = new DataBaseConnection();
                DataSet DTSet = new DataSet();

                NpgsqlDataAdapter AdaptSQL = new NpgsqlDataAdapter(ScriptSql, ConexaoBD.StartDataBaseConnection());

                AdaptSQL.Fill(DTSet);

                NpgsqlTransaction ControleTransacao = ConexaoBD.StartDataBaseConnection().BeginTransaction();

                //Indica que há controle de transação para os comandos de Exclusão, Inserção e Modificação de Dados.
                AdaptSQL.DeleteCommand.Transaction = ControleTransacao;
                AdaptSQL.InsertCommand.Transaction = ControleTransacao;
                AdaptSQL.UpdateCommand.Transaction = ControleTransacao;

                try
                {
                    AdaptSQL.Update(DTSet, ObtemTabelaBaseDados(ScriptSql));
                    ControleTransacao.Commit();
                }
                catch (DataException ex)
                {
                    ControleTransacao.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtem o alias de uma tabela a partir do script passado por parâmetro.
        /// </summary>
        /// <param name="ScriptSql">Script Sql passado para a base de dados.</param>
        /// <returns>Retorna o alias da tabela utilizada na base de dados.</returns>
        public String ObtemTabelaBaseDados(String ScriptSql) {
            string[] ComandosScript = ScriptSql.Split(' ');

            foreach(string Comando in ComandosScript){
                if (!Comando.Equals("UPDATE") && !Comando.Equals("INSERT") && !Comando.Equals("DELETE") && !Comando.Equals("INTO") && !Comando.Equals("FROM"))
                {
                    return Comando;
                }
            }
            return String.Empty;
        }
    }
}
