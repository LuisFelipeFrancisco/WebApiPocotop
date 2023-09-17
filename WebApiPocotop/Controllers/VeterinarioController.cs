using System;
using System.Web.Http;

namespace WebApiPocotop.Controllers
{
    public class VeterinarioController : ApiController
    {
        private readonly Repositories.IRepository<Models.Veterinario> repository;
        public VeterinarioController()
        {
            repository = new Repositories.Database.SQLServer.ADO.Veterinarios(Configurations.SQLServer.getConnectionString());
        }

        // GET: api/Veterinario
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(repository.Get());
            }
            catch (Exception ex)
            {
                //Logger.Log.write(ex, WebApi.Configurations.Log.getLogPath());
                return InternalServerError();
            }
        }

        // GET: api/Veterinario/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Models.Veterinario veterinario = repository.GetById(id);
                if (veterinario == null)
                    return NotFound();
                else
                    return Ok(veterinario);
            }
            catch (Exception ex)
            {
                //Logger.Log.write(ex, WebApi.Configurations.Log.getLogPath());
                return InternalServerError();
            }
        }

        // POST: api/Veterinario
        public IHttpActionResult Post(Models.Veterinario veterinario)
        {
            try
            {
                //if (!ModelState.IsValid)
                    //return BadRequest(ModelState);

                repository.Add(veterinario);

                return Ok(veterinario);
            }
            catch (Exception ex)
            {
                //Logger.Log.write(ex, WebApi.Configurations.Log.getLogPath());
                return InternalServerError();
            }
        }

        // PUT: api/Veterinario/5
        public IHttpActionResult Put(int id, Models.Veterinario veterinario)
        {
            try
            {
                if (id != veterinario.idVeterinario)
                    ModelState.AddModelError("Id", "O id informado na URL é diferente do id informado no corpo da requisição");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                int linhasAfetadas = repository.Update(id, veterinario);

                if (linhasAfetadas == 0)
                    return NotFound();

                return Ok(veterinario);
            }
            catch (Exception ex)
            {
                //Logger.Log.write(ex, WebApi.Configurations.Log.getLogPath());
                return InternalServerError();
            }
        }

        // DELETE: api/Veterinario/5
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
                //Logger.Log.write(ex, WebApi.Configurations.Log.getLogPath());
                return InternalServerError();
            }
        }
    }
}
