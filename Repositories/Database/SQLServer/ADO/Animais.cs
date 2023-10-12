using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Repositories.Database.SQLServer.ADO
{
    public class Animais : IRepository<Models.Animal>
    {
        private readonly SqlConnection conn;

        public Animais(String connectionString)
        {
            this.conn = new SqlConnection(connectionString);
        }

        public List<Models.Animal> Get()
        {
            List<Models.Animal> animais = new List<Models.Animal>();

            using (conn)
            {
                conn.Open();
                string commandText = "SELECT idAnimal, idProprietario, fotoAnimal, nomeAnimal, sexoAnimal, registroAnimal, dataNascimentoAnimal, racaAnimal, pelagemAnimal, temperamentoAnimal, observacoesAnimal, dataCadastroAnimal FROM Animal";

                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Models.Animal animal = new Models.Animal();
                            animal.idAnimal = (int)dataReader["idAnimal"];
                            animal.idProprietario = (int)dataReader["idProprietario"];
                            animal.fotoAnimal = dataReader["fotoAnimal"] == DBNull.Value ? null : (string)dataReader["fotoAnimal"];
                            animal.nomeAnimal = (string)dataReader["nomeAnimal"];
                            animal.sexoAnimal = (string)dataReader["sexoAnimal"];
                            animal.registroAnimal = dataReader["registroAnimal"] == DBNull.Value ? null : (string)dataReader["registroAnimal"];
                            animal.dataNascimentoAnimal = (DateTime)dataReader["dataNascimentoAnimal"];
                            animal.racaAnimal = (string)dataReader["racaAnimal"];
                            animal.pelagemAnimal = dataReader["pelagemAnimal"] == DBNull.Value ? null : (string)dataReader["pelagemAnimal"];
                            animal.temperamentoAnimal = dataReader["temperamentoAnimal"] == DBNull.Value ? null : (string)dataReader["temperamentoAnimal"];
                            animal.observacoesAnimal = dataReader["observacoesAnimal"] == DBNull.Value ? null : (string)dataReader["observacoesAnimal"];
                            animal.dataCadastroAnimal = (DateTime)dataReader["dataCadastroAnimal"];

                            animais.Add(animal);
                        }
                    }
                }
            }
            return animais;
        }

        public Models.Animal GetById(int id)
        {
            List<Models.Animal> animais = new List<Models.Animal>();
            Models.Animal animal = null;

            using(conn)
            {
                conn.Open();

                using(SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT idAnimal, idProprietario, fotoAnimal, nomeAnimal, sexoAnimal, registroAnimal, dataNascimentoAnimal, racaAnimal, pelagemAnimal, temperamentoAnimal, observacoesAnimal, dataCadastroAnimal FROM Animal WHERE idAnimal = @idAnimal";
                    cmd.Parameters.Add(new SqlParameter("@idAnimal", System.Data.SqlDbType.Int)).Value = id;

                    using(SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        if(dataReader.Read())
                        {
                            animal = new Models.Animal();
                            animal.idAnimal = (int)dataReader["idAnimal"];
                            animal.idProprietario = (int)dataReader["idProprietario"];
                            animal.fotoAnimal = dataReader["fotoAnimal"] == DBNull.Value ? null : (string)dataReader["fotoAnimal"];
                            animal.nomeAnimal = (string)dataReader["nomeAnimal"];
                            animal.sexoAnimal = (string)dataReader["sexoAnimal"];
                            animal.registroAnimal = dataReader["registroAnimal"] == DBNull.Value ? null : (string)dataReader["registroAnimal"];
                            animal.dataNascimentoAnimal = (DateTime)dataReader["dataNascimentoAnimal"];
                            animal.racaAnimal = (string)dataReader["racaAnimal"];
                            animal.pelagemAnimal = dataReader["pelagemAnimal"] == DBNull.Value ? null : (string)dataReader["pelagemAnimal"];
                            animal.temperamentoAnimal = dataReader["temperamentoAnimal"] == DBNull.Value ? null : (string)dataReader["temperamentoAnimal"];
                            animal.observacoesAnimal = dataReader["observacoesAnimal"] == DBNull.Value ? null : (string)dataReader["observacoesAnimal"];
                            animal.dataCadastroAnimal = (DateTime)dataReader["dataCadastroAnimal"];
                        }
                    }
                }
            }
            return animal;
        }

        public void Add(Models.Animal animal)
        {
            using (conn)
            {
                conn.Open();
                string commandText = "INSERT INTO Animal (idProprietario, fotoAnimal, nomeAnimal, sexoAnimal, registroAnimal, dataNascimentoAnimal, racaAnimal, pelagemAnimal, temperamentoAnimal, observacoesAnimal, dataCadastroAnimal) VALUES (@idProprietario, @fotoAnimal, @nomeAnimal, @sexoAnimal, @registroAnimal, @dataNascimentoAnimal, @racaAnimal, @pelagemAnimal, @temperamentoAnimal, @observacoesAnimal, @dataCadastroAnimal); select convert(int, @@IDENTITY) as id;";

                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@idProprietario", animal.idProprietario));

                    if (animal.fotoAnimal == null)
                        cmd.Parameters.Add(new SqlParameter("@fotoAnimal", DBNull.Value));
                    else
                        cmd.Parameters.Add(new SqlParameter("@fotoAnimal", animal.fotoAnimal));

                    cmd.Parameters.Add(new SqlParameter("@nomeAnimal", animal.nomeAnimal));
                    cmd.Parameters.Add(new SqlParameter("@sexoAnimal", animal.sexoAnimal));
                    
                    if (animal.registroAnimal == null)
                        cmd.Parameters.Add(new SqlParameter("@registroAnimal", DBNull.Value));
                    else
                        cmd.Parameters.Add(new SqlParameter("@registroAnimal", animal.registroAnimal));

                    cmd.Parameters.Add(new SqlParameter("@dataNascimentoAnimal", animal.dataNascimentoAnimal));
                    cmd.Parameters.Add(new SqlParameter("@racaAnimal", animal.racaAnimal));

                    if (animal.pelagemAnimal == null)
                        cmd.Parameters.Add(new SqlParameter("@pelagemAnimal", DBNull.Value));
                    else
                        cmd.Parameters.Add(new SqlParameter("@pelagemAnimal", animal.pelagemAnimal));

                    if (animal.temperamentoAnimal == null)
                        cmd.Parameters.Add(new SqlParameter("@temperamentoAnimal", DBNull.Value));
                    else
                        cmd.Parameters.Add(new SqlParameter("@temperamentoAnimal", animal.temperamentoAnimal));

                    if (animal.observacoesAnimal == null)
                        cmd.Parameters.Add(new SqlParameter("@observacoesAnimal", DBNull.Value));
                    else
                        cmd.Parameters.Add(new SqlParameter("@observacoesAnimal", animal.observacoesAnimal));

                    cmd.Parameters.Add(new SqlParameter("@dataCadastroAnimal", animal.dataCadastroAnimal));

                    animal.idAnimal = (int)cmd.ExecuteScalar();
                }
            }
        }

        public int Update(int id, Models.Animal animal)
        {
            int linhasAfetadas = 0;

            using(conn)
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE Animal SET idProprietario = @idProprietario, fotoAnimal = @fotoAnimal, nomeAnimal = @nomeAnimal, sexoAnimal = @sexoAnimal, registroAnimal = @registroAnimal, dataNascimentoAnimal = @dataNascimentoAnimal, racaAnimal = @racaAnimal, pelagemAnimal = @pelagemAnimal, temperamentoAnimal = @temperamentoAnimal, observacoesAnimal = @observacoesAnimal, dataCadastroAnimal = @dataCadastroAnimal WHERE idAnimal = @idAnimal";

                    cmd.Parameters.Add(new SqlParameter("@idAnimal", System.Data.SqlDbType.Int)).Value = id;
                    cmd.Parameters.Add(new SqlParameter("@idProprietario", System.Data.SqlDbType.Int)).Value = animal.idProprietario;

                    if (animal.fotoAnimal == null)
                        cmd.Parameters.Add(new SqlParameter("@fotoAnimal", System.Data.SqlDbType.VarChar)).Value = DBNull.Value;
                    else
                        cmd.Parameters.Add(new SqlParameter("@fotoAnimal", System.Data.SqlDbType.VarChar)).Value = animal.fotoAnimal;

                    cmd.Parameters.Add(new SqlParameter("@nomeAnimal", System.Data.SqlDbType.VarChar)).Value = animal.nomeAnimal;
                    cmd.Parameters.Add(new SqlParameter("@sexoAnimal", System.Data.SqlDbType.VarChar)).Value = animal.sexoAnimal;

                    if (animal.registroAnimal == null)
                        cmd.Parameters.Add(new SqlParameter("@registroAnimal", System.Data.SqlDbType.VarChar)).Value = DBNull.Value;
                    else
                        cmd.Parameters.Add(new SqlParameter("@registroAnimal", System.Data.SqlDbType.VarChar)).Value = animal.registroAnimal;   
                    
                    cmd.Parameters.Add(new SqlParameter("@dataNascimentoAnimal", System.Data.SqlDbType.Date)).Value = animal.dataNascimentoAnimal;
                    cmd.Parameters.Add(new SqlParameter("@racaAnimal", System.Data.SqlDbType.VarChar)).Value = animal.racaAnimal;

                    if (animal.pelagemAnimal == null)
                        cmd.Parameters.Add(new SqlParameter("@pelagemAnimal", System.Data.SqlDbType.VarChar)).Value = DBNull.Value;
                    else
                        cmd.Parameters.Add(new SqlParameter("@pelagemAnimal", System.Data.SqlDbType.VarChar)).Value = animal.pelagemAnimal;

                    if (animal.temperamentoAnimal == null)
                        cmd.Parameters.Add(new SqlParameter("@temperamentoAnimal", System.Data.SqlDbType.VarChar)).Value = DBNull.Value;
                    else
                        cmd.Parameters.Add(new SqlParameter("@temperamentoAnimal", System.Data.SqlDbType.VarChar)).Value = animal.temperamentoAnimal;

                    if (animal.observacoesAnimal == null)
                        cmd.Parameters.Add(new SqlParameter("@observacoesAnimal", System.Data.SqlDbType.VarChar)).Value = DBNull.Value;
                    else
                        cmd.Parameters.Add(new SqlParameter("@observacoesAnimal", System.Data.SqlDbType.VarChar)).Value = animal.observacoesAnimal;
                    
                    cmd.Parameters.Add(new SqlParameter("@dataCadastroAnimal", System.Data.SqlDbType.Date)).Value = animal.dataCadastroAnimal;

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
                    cmd.CommandText = "DELETE FROM Animal WHERE idAnimal = @idAnimal";
                    cmd.Parameters.Add(new SqlParameter("@idAnimal", System.Data.SqlDbType.Int)).Value = id;

                    linhasAfetadas = cmd.ExecuteNonQuery();
                }
            }
            return linhasAfetadas;
        }
    }
}
