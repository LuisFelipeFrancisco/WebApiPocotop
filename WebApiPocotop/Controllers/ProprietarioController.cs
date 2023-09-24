using System;
using System.Web.Http;

namespace WebApiPocotop.Controllers
{
    public class ProprietarioController : ApiController
    {
        private readonly Repositories.IRepository<Models.Proprietario> repository;
        public ProprietarioController()
        {
             repository = new Repositories.Database.SQLServer.ADO.Proprietarios(Configurations.SQLServer.getConnectionString());
        }
        // GET: api/Proprietario
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

        // GET: api/Proprietario/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Models.Proprietario proprietario = repository.GetById(id);
                if (proprietario == null)
                    return NotFound();
                else
                    return Ok(proprietario);
            }
            catch (Exception ex)
            {
                Logger.Log.write(ex, Configurations.Log.getLogPath());
                return InternalServerError();
            }
        }

        // POST: api/Proprietario
        public IHttpActionResult Post(Models.Proprietario proprietario)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                repository.Add(proprietario);

                return Ok(proprietario);
            }
            catch (Exception ex)
            {
                Logger.Log.write(ex, Configurations.Log.getLogPath());
                return InternalServerError();
            }
        }

        // PUT: api/Proprietario/5
        public IHttpActionResult Put(int id, Models.Proprietario proprietario)
        {
            try
            {
                if (id != proprietario.idProprietario)
                    ModelState.AddModelError("Id", "O id informado na URL é diferente do id informado no corpo da requisição");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                int linhasAfetadas = repository.Update(id, proprietario);

                if (linhasAfetadas == 0)
                    return NotFound();

                return Ok(proprietario);
            }
            catch (Exception ex)
            {
                Logger.Log.write(ex, Configurations.Log.getLogPath());
                return InternalServerError();
            }
        }

        // DELETE: api/Proprietario/5
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

        // GET: api/Proprietario/Filter?nome=string
        [Route("api/Proprietario/Filter")]
        public IHttpActionResult Get(string nome)
        {
            try
            {
                return Ok(repository.GetByFilter(nome));
            }
            catch (Exception ex)
            {
                Logger.Log.write(ex, Configurations.Log.getLogPath());
                return InternalServerError();
            }
        }
    }
}
