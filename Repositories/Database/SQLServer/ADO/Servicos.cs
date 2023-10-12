using System;
using System.Collections.Generic;
using System.Data.SqlClient;

/* idServico int IDENTITY(1,1) PRIMARY KEY,
nomeServico varchar(100) NOT NULL,
valorServico decimal(18,2) NOT NULL,
observacoesServico varchar(100) NULL,
dataCadastroServico date NOT NULL */

namespace Repositories.Database.SQLServer.ADO
{
    public class Servicos : IRepository<Models.Servico>
    {
        private readonly SqlConnection conn;

        public Servicos(String connectionString)
        {
            this.conn = new SqlConnection(connectionString);
        }
        
        public List<Models.Servico> Get()
        {
            List<Models.Servico> servicos = new List<Models.Servico>();

            using(conn)
            {
                conn.Open();
                string commandText = "SELECT idServico, nomeServico, valorServico, observacoesServico, dataCadastroServico FROM Servico";

                using(SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        while(dataReader.Read())
                        {
                            Models.Servico servico = new Models.Servico();
                            servico.idServico = (int)dataReader["idServico"];
                            servico.nomeServico = (string)dataReader["nomeServico"];
                            servico.valorServico = (decimal)dataReader["valorServico"];
                            servico.observacoesServico = dataReader["observacoesServico"] == DBNull.Value ? null : (string)dataReader["observacoesServico"];
                            servico.dataCadastroServico = (DateTime)dataReader["dataCadastroServico"];

                            servicos.Add(servico);
                        }
                    }
                }
            }
            return servicos;
        }

        public Models.Servico GetById(int id)
        {
            List<Models.Servico> servicos = new List<Models.Servico>();
            Models.Servico servico = null;

            using(conn)
            {
                conn.Open();
                string commandText = "SELECT idServico, nomeServico, valorServico, observacoesServico, dataCadastroServico FROM Servico WHERE idServico = @idServico";

                using(SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.Parameters.Add("@idServico", System.Data.SqlDbType.Int).Value = id;

                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        while(dataReader.Read())
                        {
                            servico = new Models.Servico();
                            servico.idServico = (int)dataReader["idServico"];
                            servico.nomeServico = (string)dataReader["nomeServico"];
                            servico.valorServico = (decimal)dataReader["valorServico"];
                            servico.observacoesServico = dataReader["observacoesServico"] == DBNull.Value ? null : (string)dataReader["observacoesServico"];
                            servico.dataCadastroServico = (DateTime)dataReader["dataCadastroServico"];
                        }
                    }
                }
            }
            return servico;
        }

        public void Add(Models.Servico servico)
        {
            using(conn)
            {
                conn.Open();
                string commandText = "INSERT INTO Servico (nomeServico, valorServico, observacoesServico, dataCadastroServico) VALUES (@nomeServico, @valorServico, @observacoesServico, @dataCadastroServico); select convert(int, @@IDENTITY) as id;";

                using(SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@nomeServico", System.Data.SqlDbType.VarChar)).Value = servico.nomeServico;
                    cmd.Parameters.Add(new SqlParameter("@valorServico", System.Data.SqlDbType.Decimal)).Value = servico.valorServico;

                    if (servico.observacoesServico == null)
                        cmd.Parameters.Add(new SqlParameter("@observacoesServico", System.Data.SqlDbType.VarChar)).Value = DBNull.Value;
                    else
                        cmd.Parameters.Add(new SqlParameter("@observacoesServico", System.Data.SqlDbType.VarChar)).Value = servico.observacoesServico;
                    
                    cmd.Parameters.Add(new SqlParameter("@dataCadastroServico", System.Data.SqlDbType.Date)).Value = servico.dataCadastroServico;

                    servico.idServico = (int)cmd.ExecuteScalar();
                }
            }
        }

        public int Update(int id, Models.Servico servico)
        {
            int linhasAfetadas = 0;

            using(conn)
            {
                conn.Open();
                string commandText = "UPDATE Servico SET nomeServico = @nomeServico, valorServico = @valorServico, observacoesServico = @observacoesServico, dataCadastroServico = @dataCadastroServico WHERE idServico = @idServico";

                using(SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@nomeServico", System.Data.SqlDbType.VarChar)).Value = servico.nomeServico;
                    cmd.Parameters.Add(new SqlParameter("@valorServico", System.Data.SqlDbType.Decimal)).Value = servico.valorServico;

                    if (servico.observacoesServico == null)
                        cmd.Parameters.Add(new SqlParameter("@observacoesServico", System.Data.SqlDbType.VarChar)).Value = DBNull.Value;
                    else
                        cmd.Parameters.Add(new SqlParameter("@observacoesServico", System.Data.SqlDbType.VarChar)).Value = servico.observacoesServico;
                    
                    cmd.Parameters.Add(new SqlParameter("@dataCadastroServico", System.Data.SqlDbType.Date)).Value = servico.dataCadastroServico;
                    cmd.Parameters.Add(new SqlParameter("@idServico", System.Data.SqlDbType.Int)).Value = id;

                    linhasAfetadas = cmd.ExecuteNonQuery();
                }
            }
            return linhasAfetadas;
        }

        public int Delete(int id)
        {
           int linhasAfetadas = 0;

            using(conn)
            {
                conn.Open();
                string commandText = "DELETE FROM Servico WHERE idServico = @idServico";

                using(SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@idServico", System.Data.SqlDbType.Int)).Value = id;

                    linhasAfetadas = cmd.ExecuteNonQuery();
                }
            }
            return linhasAfetadas;
        }
    }
}
