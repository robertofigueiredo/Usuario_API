using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Mapping
{
    public class UsuarioMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .ToTable("Usuarios");

            modelBuilder.Entity<Usuario>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Usuario>()
               .Property(x => x.Id)
               .HasColumnName("Id")
               .ValueGeneratedNever();

            modelBuilder.Entity<Usuario>()
                .Property(x => x.Nome)
                .HasColumnName("Nome"); 
            
            modelBuilder.Entity<Usuario>()
                .Property(x => x.Sobrenome)
                .HasColumnName("Sobrenome");

            modelBuilder.Entity<Usuario>()
                .Property(x => x.Ativo)
                .HasColumnName("Ativo");

            modelBuilder.Entity<Usuario>()
                .Property(x => x.DataDeCriacao)
                .HasColumnName("DataDeCriacao");

            modelBuilder.Entity<Usuario>()
                .Property(x => x.DataDeAlteracao)
                .HasColumnName("DataDeAlteracao");
        }
    }
}
