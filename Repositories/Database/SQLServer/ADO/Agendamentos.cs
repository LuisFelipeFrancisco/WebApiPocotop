using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Repositories.Database.SQLServer.ADO
{
    public class Agendamentos : IRepository<Models.Agendamento>
    {
        private readonly SqlConnection conn;

        public Agendamentos(String connectionString)
        {
            this.conn = new SqlConnection(connectionString);
        }

        public List<Models.Agendamento> Get()
        {
            List<Models.Agendamento> agendamentos = new List<Models.Agendamento>();

            using (conn)
            {
                conn.Open();
                string commandText = "SELECT idAgendamento, idProprietario, idAnimal, idServico, idVeterinario, dataAgendamento, horaAgendamento, observacoesAgendamento, dataCadastroAgendamento FROM Agendamento";

                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Models.Agendamento agendamento = new Models.Agendamento();
                            agendamento.idAgendamento = (int)dataReader["idAgendamento"];
                            agendamento.idProprietario = (int)dataReader["idProprietario"];
                            agendamento.idAnimal = (int)dataReader["idAnimal"];
                            agendamento.idServico = (int)dataReader["idServico"];
                            agendamento.idVeterinario = (int)dataReader["idVeterinario"];
                            agendamento.dataAgendamento = (DateTime)dataReader["dataAgendamento"];
                            agendamento.horaAgendamento = (TimeSpan)dataReader["horaAgendamento"];
                            agendamento.observacoesAgendamento = dataReader["observacoesAgendamento"] == DBNull.Value ? null : (string)dataReader["observacoesAgendamento"];
                            agendamento.dataCadastroAgendamento = (DateTime)dataReader["dataCadastroAgendamento"];

                            agendamentos.Add(agendamento);
                        }
                    }
                }
            }
            return agendamentos;
        }

        public Models.Agendamento GetById(int id)
        {
             List<Models.Agendamento> agendamentos = new List<Models.Agendamento>();
             Models.Agendamento agendamento = null;

             using(conn)
             {
                conn.Open();

                using(SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT idAgendamento, idProprietario, idAnimal, idServico, idVeterinario, dataAgendamento, horaAgendamento, observacoesAgendamento, dataCadastroAgendamento FROM Agendamento WHERE idAgendamento = @idAgendamento";
                    cmd.Parameters.Add(new SqlParameter("@idAgendamento", System.Data.SqlDbType.Int)).Value = id;

                    using(SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        if(dataReader.Read())
                        {
                            agendamento = new Models.Agendamento();
                            agendamento.idAgendamento = (int)dataReader["idAgendamento"];
                            agendamento.idProprietario = (int)dataReader["idProprietario"];
                            agendamento.idAnimal = (int)dataReader["idAnimal"];
                            agendamento.idServico = (int)dataReader["idServico"];
                            agendamento.idVeterinario = (int)dataReader["idVeterinario"];
                            agendamento.dataAgendamento = (DateTime)dataReader["dataAgendamento"];
                            agendamento.horaAgendamento = (TimeSpan)dataReader["horaAgendamento"];
                            agendamento.observacoesAgendamento = dataReader["observacoesAgendamento"] == DBNull.Value ? null : (string)dataReader["observacoesAgendamento"];
                            agendamento.dataCadastroAgendamento = (DateTime)dataReader["dataCadastroAgendamento"];
                        }
                    }
                }
            }
            return agendamento;
        }

        public void Add(Models.Agendamento agendamento)
        {
            using (conn)
            {
                conn.Open();
                string commandText ="INSERT INTO Agendamento (idProprietario, idAnimal, idServico, idVeterinario, dataAgendamento, horaAgendamento, observacoesAgendamento, dataCadastroAgendamento) VALUES (@idProprietario, @idAnimal, @idServico, @idVeterinario, @dataAgendamento, @horaAgendamento, @observacoesAgendamento, @dataCadastroAgendamento) select convert(int, @@IDENTITY) as id;";

                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@idProprietario", System.Data.SqlDbType.Int)).Value = agendamento.idProprietario;
                    cmd.Parameters.Add(new SqlParameter("@idAnimal", System.Data.SqlDbType.Int)).Value = agendamento.idAnimal;
                    cmd.Parameters.Add(new SqlParameter("@idServico", System.Data.SqlDbType.Int)).Value = agendamento.idServico;
                    cmd.Parameters.Add(new SqlParameter("@idVeterinario", System.Data.SqlDbType.Int)).Value = agendamento.idVeterinario;
                    cmd.Parameters.Add(new SqlParameter("@dataAgendamento", System.Data.SqlDbType.Date)).Value = agendamento.dataAgendamento;
                    cmd.Parameters.Add(new SqlParameter("@horaAgendamento", System.Data.SqlDbType.Time)).Value = agendamento.horaAgendamento;

                    if (agendamento.observacoesAgendamento == null)
                        cmd.Parameters.Add(new SqlParameter("@observacoesAgendamento", System.Data.SqlDbType.VarChar)).Value = DBNull.Value;
                    else
                        cmd.Parameters.Add(new SqlParameter("@observacoesAgendamento", System.Data.SqlDbType.VarChar)).Value = agendamento.observacoesAgendamento;

                    cmd.Parameters.Add(new SqlParameter("@dataCadastroAgendamento", System.Data.SqlDbType.Date)).Value = agendamento.dataCadastroAgendamento;

                    agendamento.idAgendamento = (int)cmd.ExecuteScalar();
                }
            }
        }

        public int Update(int id, Models.Agendamento agendamento)
        {
            int linhasAfetadas = 0;

            using (conn)
            {
                conn.Open();
                string commandText = "UPDATE Agendamento SET idProprietario = @idProprietario, idAnimal = @idAnimal, idServico = @idServico, idVeterinario = @idVeterinario, dataAgendamento = @dataAgendamento, horaAgendamento = @horaAgendamento, observacoesAgendamento = @observacoesAgendamento, dataCadastroAgendamento = @dataCadastroAgendamento WHERE idAgendamento = @idAgendamento";

                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@idAgendamento", System.Data.SqlDbType.Int)).Value = id;
                    cmd.Parameters.Add(new SqlParameter("@idProprietario", System.Data.SqlDbType.Int)).Value = agendamento.idProprietario;
                    cmd.Parameters.Add(new SqlParameter("@idAnimal", System.Data.SqlDbType.Int)).Value = agendamento.idAnimal;
                    cmd.Parameters.Add(new SqlParameter("@idServico", System.Data.SqlDbType.Int)).Value = agendamento.idServico;
                    cmd.Parameters.Add(new SqlParameter("@idVeterinario", System.Data.SqlDbType.Int)).Value = agendamento.idVeterinario;
                    cmd.Parameters.Add(new SqlParameter("@dataAgendamento", System.Data.SqlDbType.Date)).Value = agendamento.dataAgendamento;
                    cmd.Parameters.Add(new SqlParameter("@horaAgendamento", System.Data.SqlDbType.Time)).Value = agendamento.horaAgendamento;

                    if (agendamento.observacoesAgendamento == null)
                        cmd.Parameters.Add(new SqlParameter("@observacoesAgendamento", System.Data.SqlDbType.VarChar)).Value = DBNull.Value;
                    else
                        cmd.Parameters.Add(new SqlParameter("@observacoesAgendamento", System.Data.SqlDbType.VarChar)).Value = agendamento.observacoesAgendamento;

                    cmd.Parameters.Add(new SqlParameter("@dataCadastroAgendamento", System.Data.SqlDbType.Date)).Value = agendamento.dataCadastroAgendamento;

                    linhasAfetadas = cmd.ExecuteNonQuery();
                }
            }
            return linhasAfetadas;
        }

        public int Delete(int id)
        {
            int linhasAfetadas = 0;

            using (conn)
            {
                conn.Open();
                string commandText = "DELETE FROM Agendamento WHERE idAgendamento = @idAgendamento";

                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@idAgendamento", System.Data.SqlDbType.Int)).Value = id;
                    linhasAfetadas = cmd.ExecuteNonQuery();
                }
            }
            return linhasAfetadas;
        }

        public List<Models.Agendamento> GetByQuery(string query)
        {
            List<Models.Agendamento> agendamentos = new List<Models.Agendamento>();
            Models.Agendamento agendamento = null;

            using(conn)
            {
                conn.Open();
                string commandText = query;

                using(SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        while(dataReader.Read())
                        {
                            agendamento = new Models.Agendamento();
                            agendamento.idAgendamento = (int)dataReader["idAgendamento"];
                            agendamento.idProprietario = (int)dataReader["idProprietario"];
                            agendamento.idAnimal = (int)dataReader["idAnimal"];
                            agendamento.idServico = (int)dataReader["idServico"];
                            agendamento.idVeterinario = (int)dataReader["idVeterinario"];
                            agendamento.dataAgendamento = (DateTime)dataReader["dataAgendamento"];
                            agendamento.horaAgendamento = (TimeSpan)dataReader["horaAgendamento"];
                            agendamento.observacoesAgendamento = dataReader["observacoesAgendamento"] == DBNull.Value ? null : (string)dataReader["observacoesAgendamento"];
                            agendamento.dataCadastroAgendamento = (DateTime)dataReader["dataCadastroAgendamento"];

                            agendamentos.Add(agendamento);
                        }
                    }
                }
            }
            return agendamentos;
        }
    }
}
