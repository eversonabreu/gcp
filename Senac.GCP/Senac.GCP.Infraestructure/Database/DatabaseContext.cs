using Microsoft.EntityFrameworkCore;
using Senac.GCP.Domain.Entities;

namespace Senac.GCP.Infraestructure.Database
{
    public sealed class DatabaseContext : DbContext
    {
        public DatabaseContext() { }

        public DatabaseContext(DbContextOptions options) : base(options) { }

        public DbSet<UsuarioEntity> Usuario { get; set; }
    }
}
