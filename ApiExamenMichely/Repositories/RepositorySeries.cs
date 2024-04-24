using ApiExamenMichely.Data;
using ApiExamenMichely.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;

namespace ApiExamenMichely.Repositories
{
    public class RepositorySeries
    {

        private SeriesContext context;
        public RepositorySeries(SeriesContext context)
        {
            this.context = context;
        }

          


        private async Task<int> GetMaxIdPersonajeAsync()
        {
            if (this.context.Personajes.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await this.context.Personajes.MaxAsync(z => z.IdPersonaje) + 1;
            }
        }

        public async Task<List<PersonajeSerie>> GetPersonajeAsync()
        {
            return await this.context.Personajes.ToListAsync();
        }




        public async Task<PersonajeSerie> FindPersonajeAsync(int id)
        {
            return await this.context.Personajes.FirstOrDefaultAsync(x => x.IdPersonaje == id);
        }

        public async Task InsertPersonajeAsync(string nombre, string imagen, string serie)
        {
            PersonajeSerie per = new PersonajeSerie();
            per.IdPersonaje = await this.GetMaxIdPersonajeAsync();
            per.Nombre = nombre;
            per.Imagen = imagen;
            per.Serie = serie;
            this.context.Personajes.Add(per);
            this.context.SaveChangesAsync();
        }

        public async Task UpdatePersonajeAsync(int id, string nombre, string imagen, string serie)
        {
            PersonajeSerie per = await this.FindPersonajeAsync(id);
            per.Nombre = nombre;
            per.Imagen = imagen;
            per.Serie = serie;
            this.context.SaveChangesAsync();
        }



        public async Task DeletePersonajeAsync(int id)
        {
            PersonajeSerie per = await this.FindPersonajeAsync(id);
            this.context.Personajes.Remove(per);
            this.context.SaveChangesAsync();
        }

        public async Task<List<Serie>> GetSeriesSinAsync()
        {
            return await this.context.Series.ToListAsync();
        }

        public async Task<Serie> FindSerieAsync(string serie)
        {
            return await this.context.Series.Where(x => x.Nombre == serie).FirstAsync();
        }
        public async Task<List<PersonajeSerie>> GetPersonajeSerieAsync(string serie)
        {
            return await this.context.Personajes.Where(x => x.Nombre == serie).ToListAsync();
        }


    }
}
