using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Repositories.Database.SQLServer.ADO
{
    public class Proprietarios : IRepository<Models.Proprietario>, ExtendedIRepository<Models.Proprietario>
    {
        private readonly SqlConnection conn;
        
        public Proprietarios(String connectionString)
        {
            this.conn = new SqlConnection(connectionString);
        }
        
        public List<Models.Proprietario> Get()
        {
            List<Models.Proprietario> proprietarios = new List<Models.Proprietario>();

            using(conn)
            {
                conn.Open();
                string commandText = "SELECT idProprietario, nomeProprietario, emailProprietario, dataNascimentoProprietario, estadoProprietario, cidadeProprietario, bairroProprietario, ruaProprietario, numeroProprietario, complementoProprietario, telefoneProprietario, cpfcnpjProprietario, dataCadastroProprietario FROM Proprietario";

                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Models.Proprietario proprietario = new Models.Proprietario();
                            proprietario.idProprietario = (int)dataReader["idProprietario"];
                            proprietario.nomeProprietario = (string)dataReader["nomeProprietario"];
                            proprietario.emailProprietario = (string)dataReader["emailProprietario"];
                            proprietario.dataNascimentoProprietario = (DateTime)dataReader["dataNascimentoProprietario"];
                            proprietario.estadoProprietario = (string)dataReader["estadoProprietario"];
                            proprietario.cidadeProprietario = (string)dataReader["cidadeProprietario"];
                            proprietario.bairroProprietario = (string)dataReader["bairroProprietario"];
                            proprietario.ruaProprietario = (string)dataReader["ruaProprietario"];
                            proprietario.numeroProprietario = (string)dataReader["numeroProprietario"];
                            proprietario.complementoProprietario = dataReader["complementoProprietario"] == DBNull.Value ? null : (string)dataReader["complementoProprietario"];
                            proprietario.telefoneProprietario = (string)dataReader["telefoneProprietario"];
                            proprietario.cpfcnpjProprietario = (string)dataReader["cpfcnpjProprietario"];
                            proprietario.dataCadastroProprietario = (DateTime)dataReader["dataCadastroProprietario"];

                            proprietarios.Add(proprietario);
                        }
                    }
                }
            }
            return proprietarios;
        }
        
        public Models.Proprietario GetById(int id)
        {
            List<Models.Proprietario> proprietarios = new List<Models.Proprietario>();
            Models.Proprietario proprietario = null;

            using(conn)
            {
                conn.Open();

                using(SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT idProprietario, nomeProprietario, emailProprietario, dataNascimentoProprietario,estadoProprietario, cidadeProprietario, bairroProprietario, ruaProprietario, numeroProprietario, complementoProprietario, telefoneProprietario, cpfcnpjProprietario, dataCadastroProprietario FROM Proprietario WHERE idProprietario = @idProprietario";
                    cmd.Parameters.Add(new SqlParameter("@idProprietario", System.Data.SqlDbType.Int)).Value = id;

                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        if(dataReader.Read())
                        {
                            proprietario = new Models.Proprietario();
                            proprietario.idProprietario = (int)dataReader["idProprietario"];
                            proprietario.nomeProprietario = (string)dataReader["nomeProprietario"];
                            proprietario.emailProprietario = (string)dataReader["emailProprietario"];
                            proprietario.dataNascimentoProprietario = (DateTime)dataReader["dataNascimentoProprietario"];
                            proprietario.estadoProprietario = (string)dataReader["estadoProprietario"];
                            proprietario.cidadeProprietario = (string)dataReader["cidadeProprietario"];
                            proprietario.bairroProprietario = (string)dataReader["bairroProprietario"];
                            proprietario.ruaProprietario = (string)dataReader["ruaProprietario"];
                            proprietario.numeroProprietario = (string)dataReader["numeroProprietario"];
                            proprietario.complementoProprietario = dataReader["complementoProprietario"] == DBNull.Value ? null : (string)dataReader["complementoProprietario"];
                            proprietario.telefoneProprietario = (string)dataReader["telefoneProprietario"];
                            proprietario.cpfcnpjProprietario = (string)dataReader["cpfcnpjProprietario"];
                            proprietario.dataCadastroProprietario = (DateTime)dataReader["dataCadastroProprietario"];
                        }
                    }
                }
            }
            return proprietario;
        }
        
        public void Add(Models.Proprietario proprietario)
        {
            using(conn)
            {
                conn.Open();
                string commandText = "INSERT INTO Proprietario (nomeProprietario, emailProprietario, dataNascimentoProprietario, estadoProprietario, cidadeProprietario, bairroProprietario, ruaProprietario, numeroProprietario, complementoProprietario, telefoneProprietario, cpfcnpjProprietario, dataCadastroProprietario) VALUES (@nomeProprietario, @emailProprietario, @dataNascimentoProprietario, @estadoProprietario, @cidadeProprietario, @bairroProprietario, @ruaProprietario, @numeroProprietario, @complementoProprietario, @telefoneProprietario, @cpfcnpjProprietario, @dataCadastroProprietario); select convert(int, @@IDENTITY) as id;";

                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@nomeProprietario", System.Data.SqlDbType.VarChar)).Value = proprietario.nomeProprietario;
                    cmd.Parameters.Add(new SqlParameter("@emailProprietario", System.Data.SqlDbType.VarChar)).Value = proprietario.emailProprietario;
                    cmd.Parameters.Add(new SqlParameter("@dataNascimentoProprietario", System.Data.SqlDbType.DateTime)).Value = proprietario.dataNascimentoProprietario;
                    cmd.Parameters.Add(new SqlParameter("@estadoProprietario", System.Data.SqlDbType.VarChar)).Value = proprietario.estadoProprietario;
                    cmd.Parameters.Add(new SqlParameter("@cidadeProprietario", System.Data.SqlDbType.VarChar)).Value = proprietario.cidadeProprietario;
                    cmd.Parameters.Add(new SqlParameter("@bairroProprietario", System.Data.SqlDbType.VarChar)).Value = proprietario.bairroProprietario;
                    cmd.Parameters.Add(new SqlParameter("@ruaProprietario", System.Data.SqlDbType.VarChar)).Value = proprietario.ruaProprietario;
                    cmd.Parameters.Add(new SqlParameter("@numeroProprietario", System.Data.SqlDbType.VarChar)).Value = proprietario.numeroProprietario;
                    
                    if (proprietario.complementoProprietario == null)
                        cmd.Parameters.Add(new SqlParameter("@complementoProprietario", System.Data.SqlDbType.VarChar)).Value = DBNull.Value;
                    else
                        cmd.Parameters.Add(new SqlParameter("@complementoProprietario", System.Data.SqlDbType.VarChar)).Value = proprietario.complementoProprietario;

                    cmd.Parameters.Add(new SqlParameter("@telefoneProprietario", System.Data.SqlDbType.VarChar)).Value = proprietario.telefoneProprietario;
                    cmd.Parameters.Add(new SqlParameter("@cpfcnpjProprietario", System.Data.SqlDbType.VarChar)).Value = proprietario.cpfcnpjProprietario;
                    cmd.Parameters.Add(new SqlParameter("@dataCadastroProprietario", System.Data.SqlDbType.DateTime)).Value = proprietario.dataCadastroProprietario;

                    proprietario.idProprietario = (int)cmd.ExecuteScalar();
                }
            }
        }
        
        public int Update(int id, Models.Proprietario proprietario)
        {
            int linhasAfetadas = 0;

            using(conn)
            {
                conn.Open();

                using(SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE Proprietario SET nomeProprietario = @nomeProprietario, emailProprietario = @emailProprietario, dataNascimentoProprietario = @dataNascimentoProprietario, estadoProprietario = @estadoProprietario, cidadeProprietario = @cidadeProprietario, bairroProprietario = @bairroProprietario, ruaProprietario = @ruaProprietario, numeroProprietario = @numeroProprietario, complementoProprietario = @complementoProprietario, telefoneProprietario = @telefoneProprietario, cpfcnpjProprietario = @cpfcnpjProprietario, dataCadastroProprietario = @dataCadastroProprietario WHERE idProprietario = @idProprietario";

                    cmd.Parameters.Add(new SqlParameter("@idProprietario", System.Data.SqlDbType.Int)).Value = id;
                    cmd.Parameters.Add(new SqlParameter("@nomeProprietario", System.Data.SqlDbType.VarChar)).Value = proprietario.nomeProprietario;
                    cmd.Parameters.Add(new SqlParameter("@emailProprietario", System.Data.SqlDbType.VarChar)).Value = proprietario.emailProprietario;
                    cmd.Parameters.Add(new SqlParameter("@dataNascimentoProprietario", System.Data.SqlDbType.DateTime)).Value = proprietario.dataNascimentoProprietario;
                    cmd.Parameters.Add(new SqlParameter("@estadoProprietario", System.Data.SqlDbType.VarChar)).Value = proprietario.estadoProprietario;
                    cmd.Parameters.Add(new SqlParameter("@cidadeProprietario", System.Data.SqlDbType.VarChar)).Value = proprietario.cidadeProprietario;
                    cmd.Parameters.Add(new SqlParameter("@bairroProprietario", System.Data.SqlDbType.VarChar)).Value = proprietario.bairroProprietario;
                    cmd.Parameters.Add(new SqlParameter("@ruaProprietario", System.Data.SqlDbType.VarChar)).Value = proprietario.ruaProprietario;
                    cmd.Parameters.Add(new SqlParameter("@numeroProprietario", System.Data.SqlDbType.VarChar)).Value = proprietario.numeroProprietario;
                    
                    if (proprietario.complementoProprietario == null)
                        cmd.Parameters.Add(new SqlParameter("@complementoProprietario", System.Data.SqlDbType.VarChar)).Value = DBNull.Value;
                    else
                        cmd.Parameters.Add(new SqlParameter("@complementoProprietario", System.Data.SqlDbType.VarChar)).Value = proprietario.complementoProprietario;

                    cmd.Parameters.Add(new SqlParameter("@telefoneProprietario", System.Data.SqlDbType.VarChar)).Value = proprietario.telefoneProprietario;
                    cmd.Parameters.Add(new SqlParameter("@cpfcnpjProprietario", System.Data.SqlDbType.VarChar)).Value = proprietario.cpfcnpjProprietario;
                    cmd.Parameters.Add(new SqlParameter("@dataCadastroProprietario", System.Data.SqlDbType.DateTime)).Value = proprietario.dataCadastroProprietario;

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

                using(SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "DELETE FROM Proprietario WHERE idProprietario = @idProprietario";
                    cmd.Parameters.Add(new SqlParameter("@idProprietario", System.Data.SqlDbType.Int)).Value = id;

                    linhasAfetadas = cmd.ExecuteNonQuery();
                }
            }
            return linhasAfetadas;
        }
        
        public List<Models.Proprietario> GetByFilter(string filter)
        {
            List<Models.Proprietario> proprietarios = new List<Models.Proprietario>();
            Models.Proprietario proprietario = null;

            using(conn)
            {
                conn.Open();

                using(SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT idProprietario, nomeProprietario, emailProprietario, dataNascimentoProprietario, estadoProprietario, cidadeProprietario, bairroProprietario, ruaProprietario, numeroProprietario, complementoProprietario, telefoneProprietario, cpfcnpjProprietario, dataCadastroProprietario FROM Proprietario WHERE nomeProprietario LIKE @nomeProprietario";
                    cmd.Parameters.Add(new SqlParameter("@nomeProprietario", System.Data.SqlDbType.VarChar)).Value = "%" + filter + "%";

                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            proprietario = new Models.Proprietario();
                            proprietario.idProprietario = (int)dataReader["idProprietario"];
                            proprietario.nomeProprietario = (string)dataReader["nomeProprietario"];
                            proprietario.emailProprietario = (string)dataReader["emailProprietario"];
                            proprietario.dataNascimentoProprietario = (DateTime)dataReader["dataNascimentoProprietario"];
                            proprietario.estadoProprietario = (string)dataReader["estadoProprietario"];
                            proprietario.cidadeProprietario = (string)dataReader["cidadeProprietario"];
                            proprietario.bairroProprietario = (string)dataReader["bairroProprietario"];
                            proprietario.ruaProprietario = (string)dataReader["ruaProprietario"];
                            proprietario.numeroProprietario = (string)dataReader["numeroProprietario"];
                            proprietario.complementoProprietario = dataReader["complementoProprietario"] == DBNull.Value ? null : (string)dataReader["complementoProprietario"];
                            proprietario.telefoneProprietario = (string)dataReader["telefoneProprietario"];
                            proprietario.cpfcnpjProprietario = (string)dataReader["cpfcnpjProprietario"];
                            proprietario.dataCadastroProprietario = (DateTime)dataReader["dataCadastroProprietario"];

                            proprietarios.Add(proprietario);
                        }
                    }
                }
            }
            return proprietarios;
        }

        public List<Models.Proprietario> GetByQuery(string query)
        {
            List<Models.Proprietario> proprietarios = new List<Models.Proprietario>();
            Models.Proprietario proprietario = null;

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
                            proprietario = new Models.Proprietario();
                            proprietario.idProprietario = (int)dataReader["idProprietario"];
                            proprietario.nomeProprietario = (string)dataReader["nomeProprietario"];
                            proprietario.emailProprietario = (string)dataReader["emailProprietario"];
                            proprietario.dataNascimentoProprietario = (DateTime)dataReader["dataNascimentoProprietario"];
                            proprietario.estadoProprietario = (string)dataReader["estadoProprietario"];
                            proprietario.cidadeProprietario = (string)dataReader["cidadeProprietario"];
                            proprietario.bairroProprietario = (string)dataReader["bairroProprietario"];
                            proprietario.ruaProprietario = (string)dataReader["ruaProprietario"];
                            proprietario.numeroProprietario = (string)dataReader["numeroProprietario"];
                            proprietario.complementoProprietario = dataReader["complementoProprietario"] == DBNull.Value ? null : (string)dataReader["complementoProprietario"];
                            proprietario.telefoneProprietario = (string)dataReader["telefoneProprietario"];
                            proprietario.cpfcnpjProprietario = (string)dataReader["cpfcnpjProprietario"];
                            proprietario.dataCadastroProprietario = (DateTime)dataReader["dataCadastroProprietario"];

                            proprietarios.Add(proprietario);
                        }
                    }
                }
            }
            return proprietarios;
        }
    }
}
