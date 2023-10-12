using System;
using System.Web.Http;

namespace WebApiPocotop.Controllers
{
    public class AnimalController : ApiController
    {
        private readonly Repositories.IRepository<Models.Animal> repository;

        public AnimalController()
        {
            repository = new Repositories.Database.SQLServer.ADO.Animais(Configurations.SQLServer.getConnectionString());
        }
        // GET: api/Animal
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

        // GET: api/Animal/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Models.Animal animal = repository.GetById(id);
                if (animal == null)
                    return NotFound();
                else
                    return Ok(animal);
            }
            catch (Exception ex)
            {
                Logger.Log.write(ex, Configurations.Log.getLogPath());
                return InternalServerError();
            }
        }

        // POST: api/Animal
        public IHttpActionResult Post(Models.Animal animal)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                repository.Add(animal);

                return Ok(animal);
            }
            catch (Exception ex)
            {
                Logger.Log.write(ex, Configurations.Log.getLogPath());
                return InternalServerError();
            }
        }

        // PUT: api/Animal/5
        public IHttpActionResult Put(int id, Models.Animal animal)
        {
            try
            {
                if (id != animal.idAnimal)
                    ModelState.AddModelError("Id", "O id informado na URL é diferente do id informado no corpo da requisição");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                int linhasAfetadas = repository.Update(id, animal);

                if (linhasAfetadas == 0)
                    return NotFound();

                return Ok(animal);
            }
            catch (Exception ex)
            {
                Logger.Log.write(ex, Configurations.Log.getLogPath());
                return InternalServerError();
            }
        }

        // DELETE: api/Animal/5
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
