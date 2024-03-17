using Data.Mapping;
using Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace Data.Context
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            UsuarioMap.Map(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Usuario> UsuarioAPI { get; set; }

    }
}
