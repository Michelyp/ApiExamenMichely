﻿using ApiExamenMichely.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiExamenMichely.Data
{
    public class SeriesContext:DbContext
    {
        public SeriesContext(DbContextOptions<SeriesContext> options)
                    : base(options) { }
        public DbSet<PersonajeSerie> Personajes { get; set; }
    }
}
