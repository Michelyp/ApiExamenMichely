using ApiExamenMichely.Models;
using ApiExamenMichely.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.ConstrainedExecution;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ApiExamenMichely.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerSerie : ControllerBase
    {
        private RepositorySeries repo;

        public ControllerSerie(RepositorySeries repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonajeSerie>>> Get()
        {
            return await this.repo.GetPersonajeAsync();
        }
        [HttpGet]
        [Route("[action]/{serie}")]
        public async Task<ActionResult<PersonajeSerie>> PersonajesSerie(string serie)
        {
            return await this.repo.FindSerieAsync(serie);
        }
        [HttpGet]
        [Route("[action]/serie")]
        public async Task<ActionResult<List<string>>> PersonajesSerie()
        {
            return await this.repo.GetPersonajeSerieAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonajeSerie>> FindPersonaje(int id)
        {
            return await this.repo.FindPersonajeAsync(id);
        }


        [HttpPost]
        public async Task<ActionResult>
            InsertPersonaje(PersonajeSerie per)
        {
            await this.repo.InsertPersonajeAsync(per.Nombre, per.Imagen, per.Serie);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult>
            UpdatePersonaje(PersonajeSerie per)
        {
            await this.repo.UpdatePersonajeAsync(per.IdPersonaje, per.Nombre, per.Imagen, per.Serie);
            return Ok();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeletePersonaje(int id)
        {
            await this.repo.DeletePersonajeAsync(id);
            return Ok();
        }


       

    }
}