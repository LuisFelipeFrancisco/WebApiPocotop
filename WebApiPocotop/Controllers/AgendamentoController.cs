using Dapper;
using Newtonsoft.Json;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;

namespace WebApiPocotop.Controllers
{
    public class AgendamentoController : ApiController
    {
        private readonly Repositories.IRepository<Models.Agendamento> repository;

        public AgendamentoController()
        {
            repository = new Repositories.Database.SQLServer.ADO.Agendamentos(Configurations.SQLServer.getConnectionString());
        }

        // GET: api/Agendamento
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(repository.Get());
            }
            catch (Exception ex)
            {
                Logger.Log.write(ex, Configurations.Log.getLogPath());
                return InternalServerError();
            }
        }

        // GET: api/Agendamento/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Models.Agendamento agendamento = repository.GetById(id);
                if (agendamento == null)
                    return NotFound();
                else
                    return Ok(agendamento);
            }
            catch (Exception ex)
            {
                Logger.Log.write(ex, Configurations.Log.getLogPath());
                return InternalServerError();
            }
        }

        // POST: api/Agendamento
        public IHttpActionResult Post(Models.Agendamento agendamento)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                repository.Add(agendamento);

                return Ok(agendamento);
            }
            catch (Exception ex)
            {
                Logger.Log.write(ex, Configurations.Log.getLogPath());
                return InternalServerError();
            }
        }
        // PUT: api/Agendamento/5
        public IHttpActionResult Put(int id, Models.Agendamento agendamento)
        {
            try
            {
                if (id != agendamento.idAgendamento)
                    ModelState.AddModelError("Id", "O id informado na URL é diferente do id informado no corpo da requisição");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                int linhasAfetadas = repository.Update(id, agendamento);

                if (linhasAfetadas == 0)
                    return NotFound();

                return Ok(agendamento);
            }
            catch (Exception ex)
            {
                Logger.Log.write(ex, Configurations.Log.getLogPath());
                return InternalServerError();
            }
        }

        // DELETE: api/Agendamento/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                int linhasAfetadas = repository.Delete(id);

                if (linhasAfetadas == 0)
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                Logger.Log.write(ex, Configurations.Log.getLogPath());
                return InternalServerError();
            }
        }

        // GET: api/Agendamento/?Query?comando=string
        [Route("api/Agendamento/Query")]
        public IHttpActionResult GetByQuery(string comando)
        {
            try
            {
                return Ok(repository.GetByQuery(comando));
            }
            catch (Exception ex)
            {
                Logger.Log.write(ex, Configurations.Log.getLogPath());
                return InternalServerError();
            }
        }

        // GET: api/Agendamento/?Query2?comando=string
        [Route("api/Agendamento/Query2")]
        public IHttpActionResult GetByQuery2([FromUri] string comando)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Configurations.SQLServer.getConnectionString()))
                {
                    conn.Open();

                    // Execute a consulta usando Dapper
                    var results = conn.Query<dynamic>(comando).AsList();

                    // Retorne os resultados como JSON
                    return Ok(results);
                }
            }
            catch (Exception ex)
            {
                Logger.Log.write(ex, Configurations.Log.getLogPath());
                return InternalServerError();
            }
        }

    }
}
