using Ex2.Domain.Entities;
using Ex2.Domain.Entities.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2.EFCore.Context;

public class AppDbContext : DbContext
{
    public DbSet<Livro> Livors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(AppConfig.GetConnectionString())
                      .UseSnakeCaseNamingConvention()
                      .LogTo(Console.WriteLine,
                        new[] { DbLoggerCategory.Database.Command.Name },
                        Microsoft.Extensions.Logging.LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Livro>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Titulo)
            .HasMaxLength(255)
            .IsRequired();

            entity.Property(e => e.DataPublicacao)
            .IsRequired();

            entity.Property(e => e.IsDeleted)
            .HasDefaultValue(true)
            .IsRequired();

            entity.Property(e => e.Status)
            .IsRequired();

            entity.HasQueryFilter(
                e => e.DataPublicacao > new DateTime(2020, 12, 31) &&
                e.IsDeleted == false &&
                e.Status != Status.EmRevisao
            );

            entity.HasData(
                new Livro { Id = 1, Titulo = "As aventuras de Robson", DataPublicacao = new DateTime(2022,8,10),Status = Status.Disponivel },
                new Livro { Id = 2, Titulo = "As aventuras de Leonardo", DataPublicacao = new DateTime(2022, 8, 10), Status = Status.Disponivel },
                new Livro { Id = 3, Titulo = "As aventuras de Lucas", DataPublicacao = new DateTime(2022, 8, 10), Status = Status.Disponivel },
                new Livro { Id = 1, Titulo = "As aventuras de Lenilde", DataPublicacao = new DateTime(2022, 8, 10), Status = Status.Disponivel }
            );
        });
    }
}
