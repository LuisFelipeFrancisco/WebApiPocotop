using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Repositories.Database.SQLServer.ADO
{
    public class Veterinarios : IRepository<Models.Veterinario>, ExtendedIRepository<Models.Veterinario>
    {
        private readonly SqlConnection conn;
        //private readonly string chaveCache;

        public Veterinarios(String connectionString)
        {
            this.conn = new SqlConnection(connectionString);
            //this.chaveCache = "veterinarios";
        }
        
        public List<Models.Veterinario> Get()
        {
            List<Models.Veterinario> veterinarios = new List<Models.Veterinario>();

            using(conn)
            {
                conn.Open();
                string commadText = "SELECT idVeterinario, nomeVeterinario, dataNascimentoVeterinario, fotoVeterinario, emailVeterinario, senhaVeterinario, estadoVeterinario, cidadeVeterinario, bairroVeterinario, ruaVeterinario, numeroVeterinario, complementoVeterinario, telefoneVeterinario, crmvVeterinario, dataCadastroVeterinario FROM Veterinario";
                
                using (SqlCommand cmd = new SqlCommand(commadText, conn))
                {
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Models.Veterinario veterinario = new Models.Veterinario();
                            veterinario.idVeterinario = (int)dataReader["idVeterinario"];
                            veterinario.nomeVeterinario = (string)dataReader["nomeVeterinario"];
                            veterinario.dataNascimentoVeterinario = (DateTime)dataReader["dataNascimentoVeterinario"];
                            veterinario.fotoVeterinario = dataReader["fotoVeterinario"] == DBNull.Value ? null : (string)dataReader["fotoVeterinario"];
                            veterinario.emailVeterinario = (string)dataReader["emailVeterinario"];
                            veterinario.senhaVeterinario = (string)dataReader["senhaVeterinario"];
                            veterinario.estadoVeterinario = (string)dataReader["estadoVeterinario"];
                            veterinario.cidadeVeterinario = (string)dataReader["cidadeVeterinario"];
                            veterinario.bairroVeterinario = (string)dataReader["bairroVeterinario"];
                            veterinario.ruaVeterinario = (string)dataReader["ruaVeterinario"];
                            veterinario.numeroVeterinario = (string)dataReader["numeroVeterinario"];
                            veterinario.complementoVeterinario = dataReader["complementoVeterinario"] == DBNull.Value ? null : (string)dataReader["complementoVeterinario"];
                            veterinario.telefoneVeterinario = (string)dataReader["telefoneVeterinario"];
                            veterinario.crmvVeterinario = (string)dataReader["crmvVeterinario"];
                            veterinario.dataCadastroVeterinario = (DateTime)dataReader["dataCadastroVeterinario"];

                            veterinarios.Add(veterinario);
                        }
                    }
                }
            }
            return veterinarios;
        }

        public Models.Veterinario GetById(int id)
        {
            List<Models.Veterinario> veterinarios = new List<Models.Veterinario>();
            Models.Veterinario veterinario = null;

            using(conn)
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT idVeterinario, nomeVeterinario, dataNascimentoVeterinario, fotoVeterinario, emailVeterinario, senhaVeterinario, estadoVeterinario, cidadeVeterinario, bairroVeterinario, ruaVeterinario, numeroVeterinario, complementoVeterinario, telefoneVeterinario, crmvVeterinario, dataCadastroVeterinario FROM Veterinario WHERE idVeterinario = @idVeterinario";
                    cmd.Parameters.Add(new SqlParameter("@idVeterinario", System.Data.SqlDbType.Int)).Value = id;

                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            veterinario = new Models.Veterinario();
                            veterinario.idVeterinario = (int)dataReader["idVeterinario"];
                            veterinario.nomeVeterinario = (string)dataReader["nomeVeterinario"];
                            veterinario.dataNascimentoVeterinario = (DateTime)dataReader["dataNascimentoVeterinario"];
                            veterinario.fotoVeterinario = dataReader["fotoVeterinario"] == DBNull.Value ? null : (string)dataReader["fotoVeterinario"];
                            veterinario.emailVeterinario = (string)dataReader["emailVeterinario"];
                            veterinario.senhaVeterinario = (string)dataReader["senhaVeterinario"];
                            veterinario.estadoVeterinario = (string)dataReader["estadoVeterinario"];
                            veterinario.cidadeVeterinario = (string)dataReader["cidadeVeterinario"];
                            veterinario.bairroVeterinario = (string)dataReader["bairroVeterinario"];
                            veterinario.ruaVeterinario = (string)dataReader["ruaVeterinario"];
                            veterinario.numeroVeterinario = (string)dataReader["numeroVeterinario"];
                            veterinario.complementoVeterinario = dataReader["complementoVeterinario"] == DBNull.Value ? null : (string)dataReader["complementoVeterinario"];
                            veterinario.telefoneVeterinario = (string)dataReader["telefoneVeterinario"];
                            veterinario.crmvVeterinario = (string)dataReader["crmvVeterinario"];
                            veterinario.dataCadastroVeterinario = (DateTime)dataReader["dataCadastroVeterinario"];
                        }
                    }
                }
            }
            return veterinario;
        }

        public void Add(Models.Veterinario veterinario)
        {
            using(conn)
            {
                conn.Open();
                string commadText = "INSERT INTO Veterinario (nomeVeterinario, dataNascimentoVeterinario, fotoVeterinario, emailVeterinario, senhaVeterinario, estadoVeterinario, cidadeVeterinario, bairroVeterinario, ruaVeterinario, numeroVeterinario, complementoVeterinario, telefoneVeterinario, crmvVeterinario, dataCadastroVeterinario) VALUES (@nomeVeterinario, @dataNascimentoVeterinario, @fotoVeterinario, @emailVeterinario, @senhaVeterinario, @estadoVeterinario, @cidadeVeterinario, @bairroVeterinario, @ruaVeterinario, @numeroVeterinario, @complementoVeterinario, @telefoneVeterinario, @crmvVeterinario, @dataCadastroVeterinario); select convert(int, @@IDENTITY) as id;";

                using (SqlCommand cmd = new SqlCommand(commadText,conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@nomeVeterinario", System.Data.SqlDbType.VarChar)).Value = veterinario.nomeVeterinario;
                    cmd.Parameters.Add(new SqlParameter("@dataNascimentoVeterinario", System.Data.SqlDbType.DateTime)).Value = veterinario.dataNascimentoVeterinario;
                    
                    if (veterinario.fotoVeterinario == null)
                        cmd.Parameters.Add(new SqlParameter("@fotoVeterinario", System.Data.SqlDbType.VarChar)).Value = DBNull.Value;
                    else
                        cmd.Parameters.Add(new SqlParameter("@fotoVeterinario", System.Data.SqlDbType.VarChar)).Value = veterinario.fotoVeterinario;
                    
                    cmd.Parameters.Add(new SqlParameter("@emailVeterinario", System.Data.SqlDbType.VarChar)).Value = veterinario.emailVeterinario;
                    cmd.Parameters.Add(new SqlParameter("@senhaVeterinario", System.Data.SqlDbType.VarChar)).Value = veterinario.senhaVeterinario;
                    cmd.Parameters.Add(new SqlParameter("@estadoVeterinario", System.Data.SqlDbType.VarChar)).Value = veterinario.estadoVeterinario;
                    cmd.Parameters.Add(new SqlParameter("@cidadeVeterinario", System.Data.SqlDbType.VarChar)).Value = veterinario.cidadeVeterinario;
                    cmd.Parameters.Add(new SqlParameter("@bairroVeterinario", System.Data.SqlDbType.VarChar)).Value = veterinario.bairroVeterinario;
                    cmd.Parameters.Add(new SqlParameter("@ruaVeterinario", System.Data.SqlDbType.VarChar)).Value = veterinario.ruaVeterinario;
                    cmd.Parameters.Add(new SqlParameter("@numeroVeterinario", System.Data.SqlDbType.VarChar)).Value = veterinario.numeroVeterinario;
                    
                    if (veterinario.complementoVeterinario == null)
                        cmd.Parameters.Add(new SqlParameter("@complementoVeterinario", System.Data.SqlDbType.VarChar)).Value = DBNull.Value;
                    else
                        cmd.Parameters.Add(new SqlParameter("@complementoVeterinario", System.Data.SqlDbType.VarChar)).Value = veterinario.complementoVeterinario;
                    
                    cmd.Parameters.Add(new SqlParameter("@telefoneVeterinario", System.Data.SqlDbType.VarChar)).Value = veterinario.telefoneVeterinario;
                    cmd.Parameters.Add(new SqlParameter("@crmvVeterinario", System.Data.SqlDbType.VarChar)).Value = veterinario.crmvVeterinario;
                    cmd.Parameters.Add(new SqlParameter("@dataCadastroVeterinario", System.Data.SqlDbType.DateTime)).Value = veterinario.dataCadastroVeterinario;

                    veterinario.idVeterinario = (int)cmd.ExecuteScalar();
                }
            }
        }

        public int Update(int id, Models.Veterinario veterinario)
        {
            int linhasAfetadas = 0;

            using (conn)
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.CommandText = "UPDATE Veterinario SET nomeVeterinario = @nomeVeterinario, dataNascimentoVeterinario = @dataNascimentoVeterinario, fotoVeterinario = @fotoVeterinario, emailVeterinario = @emailVeterinario, senhaVeterinario = @senhaVeterinario, estadoVeterinario = @estadoVeterinario, cidadeVeterinario = @cidadeVeterinario, bairroVeterinario = @bairroVeterinario, ruaVeterinario = @ruaVeterinario, numeroVeterinario = @numeroVeterinario, complementoVeterinario = @complementoVeterinario, telefoneVeterinario = @telefoneVeterinario, crmvVeterinario = @crmvVeterinario, dataCadastroVeterinario = @dataCadastroVeterinario WHERE idVeterinario = @idVeterinario";

                    cmd.Parameters.Add(new SqlParameter("@idVeterinario", System.Data.SqlDbType.Int)).Value = id;
                    cmd.Parameters.Add(new SqlParameter("@nomeVeterinario", System.Data.SqlDbType.VarChar)).Value = veterinario.nomeVeterinario;
                    cmd.Parameters.Add(new SqlParameter("@dataNascimentoVeterinario", System.Data.SqlDbType.DateTime)).Value = veterinario.dataNascimentoVeterinario;

                    if (veterinario.fotoVeterinario == null)
                        cmd.Parameters.Add(new SqlParameter("@fotoVeterinario", System.Data.SqlDbType.VarChar)).Value = DBNull.Value;
                    else
                        cmd.Parameters.Add(new SqlParameter("@fotoVeterinario", System.Data.SqlDbType.VarChar)).Value = veterinario.fotoVeterinario;
                    
                    cmd.Parameters.Add(new SqlParameter("@emailVeterinario", System.Data.SqlDbType.VarChar)).Value = veterinario.emailVeterinario;
                    cmd.Parameters.Add(new SqlParameter("@senhaVeterinario", System.Data.SqlDbType.VarChar)).Value = veterinario.senhaVeterinario;
                    cmd.Parameters.Add(new SqlParameter("@estadoVeterinario", System.Data.SqlDbType.VarChar)).Value = veterinario.estadoVeterinario;
                    cmd.Parameters.Add(new SqlParameter("@cidadeVeterinario", System.Data.SqlDbType.VarChar)).Value = veterinario.cidadeVeterinario;
                    cmd.Parameters.Add(new SqlParameter("@bairroVeterinario", System.Data.SqlDbType.VarChar)).Value = veterinario.bairroVeterinario;
                    cmd.Parameters.Add(new SqlParameter("@ruaVeterinario", System.Data.SqlDbType.VarChar)).Value = veterinario.ruaVeterinario;
                    cmd.Parameters.Add(new SqlParameter("@numeroVeterinario", System.Data.SqlDbType.VarChar)).Value = veterinario.numeroVeterinario;

                    if (veterinario.complementoVeterinario == null)
                        cmd.Parameters.Add(new SqlParameter("@complementoVeterinario", System.Data.SqlDbType.VarChar)).Value = DBNull.Value;
                    else
                        cmd.Parameters.Add(new SqlParameter("@complementoVeterinario", System.Data.SqlDbType.VarChar)).Value = veterinario.complementoVeterinario;
                    
                    cmd.Parameters.Add(new SqlParameter("@telefoneVeterinario", System.Data.SqlDbType.VarChar)).Value = veterinario.telefoneVeterinario;
                    cmd.Parameters.Add(new SqlParameter("@crmvVeterinario", System.Data.SqlDbType.VarChar)).Value = veterinario.crmvVeterinario;
                    cmd.Parameters.Add(new SqlParameter("@dataCadastroVeterinario", System.Data.SqlDbType.DateTime)).Value = veterinario.dataCadastroVeterinario;
                    
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

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.CommandText = "DELETE FROM Veterinario WHERE idVeterinario = @idVeterinario";

                    cmd.Parameters.Add(new SqlParameter("@idVeterinario", System.Data.SqlDbType.Int)).Value = id;

                    linhasAfetadas = cmd.ExecuteNonQuery();
                }
            }
            return linhasAfetadas;
        }

        public List<Models.Veterinario> GetByFilter(string filter)
        {
            List<Models.Veterinario> veterinarios = new List<Models.Veterinario>();
            Models.Veterinario veterinario = null;

            using(conn)
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT idVeterinario, nomeVeterinario, dataNascimentoVeterinario, fotoVeterinario, emailVeterinario, senhaVeterinario, estadoVeterinario, cidadeVeterinario, bairroVeterinario, ruaVeterinario, numeroVeterinario, complementoVeterinario, telefoneVeterinario, crmvVeterinario, dataCadastroVeterinario FROM Veterinario WHERE nomeVeterinario LIKE @nomeVeterinario";
                    cmd.Parameters.Add(new SqlParameter("@nomeVeterinario", System.Data.SqlDbType.VarChar)).Value = "%" + filter + "%";

                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            veterinario = new Models.Veterinario();
                            veterinario.idVeterinario = (int)dataReader["idVeterinario"];
                            veterinario.nomeVeterinario = (string)dataReader["nomeVeterinario"];
                            veterinario.dataNascimentoVeterinario = (DateTime)dataReader["dataNascimentoVeterinario"];
                            veterinario.fotoVeterinario = dataReader["fotoVeterinario"] == DBNull.Value ? null : (string)dataReader["fotoVeterinario"];
                            veterinario.emailVeterinario = (string)dataReader["emailVeterinario"];
                            veterinario.senhaVeterinario = (string)dataReader["senhaVeterinario"];
                            veterinario.estadoVeterinario = (string)dataReader["estadoVeterinario"];
                            veterinario.cidadeVeterinario = (string)dataReader["cidadeVeterinario"];
                            veterinario.bairroVeterinario = (string)dataReader["bairroVeterinario"];
                            veterinario.ruaVeterinario = (string)dataReader["ruaVeterinario"];
                            veterinario.numeroVeterinario = (string)dataReader["numeroVeterinario"];
                            veterinario.complementoVeterinario = dataReader["complementoVeterinario"] == DBNull.Value ? null : (string)dataReader["complementoVeterinario"];
                            veterinario.telefoneVeterinario = (string)dataReader["telefoneVeterinario"];
                            veterinario.crmvVeterinario = (string)dataReader["crmvVeterinario"];
                            veterinario.dataCadastroVeterinario = (DateTime)dataReader["dataCadastroVeterinario"];

                            veterinarios.Add(veterinario);
                        }
                    }
                }
            }
            return veterinarios;
        }

        public List<Models.Veterinario> GetByQuery(string query)
        {
            // Endpoint vai me passar a query e eu vou executar no banco e retornar o resultado
            List<Models.Veterinario> veterinarios = new List<Models.Veterinario>();
            Models.Veterinario veterinario = null;

            using(conn)
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = query;

                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            veterinario = new Models.Veterinario();
                            veterinario.idVeterinario = (int)dataReader["idVeterinario"];
                            veterinario.nomeVeterinario = (string)dataReader["nomeVeterinario"];
                            veterinario.dataNascimentoVeterinario = (DateTime)dataReader["dataNascimentoVeterinario"];
                            veterinario.fotoVeterinario = dataReader["fotoVeterinario"] == DBNull.Value ? null : (string)dataReader["fotoVeterinario"];
                            veterinario.emailVeterinario = (string)dataReader["emailVeterinario"];
                            veterinario.senhaVeterinario = (string)dataReader["senhaVeterinario"];
                            veterinario.estadoVeterinario = (string)dataReader["estadoVeterinario"];
                            veterinario.cidadeVeterinario = (string)dataReader["cidadeVeterinario"];
                            veterinario.bairroVeterinario = (string)dataReader["bairroVeterinario"];
                            veterinario.ruaVeterinario = (string)dataReader["ruaVeterinario"];
                            veterinario.numeroVeterinario = (string)dataReader["numeroVeterinario"];
                            veterinario.complementoVeterinario = dataReader["complementoVeterinario"] == DBNull.Value ? null : (string)dataReader["complementoVeterinario"];
                            veterinario.telefoneVeterinario = (string)dataReader["telefoneVeterinario"];
                            veterinario.crmvVeterinario = (string)dataReader["crmvVeterinario"];
                            veterinario.dataCadastroVeterinario = (DateTime)dataReader["dataCadastroVeterinario"];

                            veterinarios.Add(veterinario);
                        }
                    }
                }
            }
            return veterinarios;
        }
    }
}
