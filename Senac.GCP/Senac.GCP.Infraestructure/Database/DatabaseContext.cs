using Microsoft.EntityFrameworkCore;
using Senac.GCP.Domain.Entities;
using System;

namespace Senac.GCP.Infraestructure.Database
{
    public sealed class DatabaseContext : DbContext
    {
        public DatabaseContext() { }

        public DatabaseContext(DbContextOptions options) : base(options) { }

        public DbSet<UsuarioEntity> Usuario { get; set; }

        public DbSet<EstadoEntity> Estado { get; set; }

        public DbSet<MunicipioEntity> Municipio { get; set; }

    }
}
