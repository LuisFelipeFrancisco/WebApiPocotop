using System;
using System.Web.Http;

namespace WebApiPocotop.Controllers
{
    public class ServicoController : ApiController
    {
        private readonly Repositories.IRepository<Models.Servico> repository;

        public ServicoController()
        {
            repository = new Repositories.Database.SQLServer.ADO.Servicos(Configurations.SQLServer.getConnectionString());
        }

        // GET: api/Servico
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

        // GET: api/Servico/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Models.Servico servico = repository.GetById(id);
                if (servico == null)
                    return NotFound();
                else
                    return Ok(servico);
            }
            catch (Exception ex)
            {
                Logger.Log.write(ex, Configurations.Log.getLogPath());
                return InternalServerError();
            }
        }

        // POST: api/Servico
        public IHttpActionResult Post(Models.Servico servico)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                repository.Add(servico);

                return Ok(servico);
            }
            catch (Exception ex)
            {
                Logger.Log.write(ex, Configurations.Log.getLogPath());
                return InternalServerError();
            }
        }

        // PUT: api/Servico/5
        public IHttpActionResult Put(int id, Models.Servico servico)
        {
            try
            {
                if (id != servico.idServico)
                    ModelState.AddModelError("Id", "O id informado na URL é diferente do id informado no corpo da requisição");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                int linhasAfetadas = repository.Update(id, servico);

                if (linhasAfetadas == 0)
                    return NotFound();

                return Ok(servico);
            }
            catch (Exception ex)
            {
                Logger.Log.write(ex, Configurations.Log.getLogPath());
                return InternalServerError();
            }
        }

        // DELETE: api/Servico/5
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
    }
}