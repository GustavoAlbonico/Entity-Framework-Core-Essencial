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
    public DbSet<Livro> Livros { get; set; }

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
            .IsRequired();

            entity.Property(e => e.Status)
            .IsRequired();

            entity.HasQueryFilter(
                e => e.DataPublicacao > new DateTime(2020, 12, 31) &&
                e.IsDeleted == false &&
                e.Status != Status.EmRevisao
            );

            entity.HasData(
                new Livro { Id = 2, Titulo = "O mistério da floresta", DataPublicacao = new DateTime(2021, 5, 12), Status = Status.Emprestado, IsDeleted = false },
                new Livro { Id = 3, Titulo = "Viagem ao desconhecido", DataPublicacao = new DateTime(2020, 3, 8), Status = Status.EmRevisao, IsDeleted = false },
                new Livro { Id = 4, Titulo = "Segredos do oceano", DataPublicacao = new DateTime(2019, 11, 23), Status = Status.Disponivel, IsDeleted = true },
                new Livro { Id = 5, Titulo = "A última batalha", DataPublicacao = new DateTime(2023, 1, 15), Status = Status.Emprestado, IsDeleted = false },
                new Livro { Id = 6, Titulo = "Caminhos do destino", DataPublicacao = new DateTime(2022, 7, 30), Status = Status.EmRevisao, IsDeleted = false },
                new Livro { Id = 7, Titulo = "A ilha perdida", DataPublicacao = new DateTime(2018, 9, 14), Status = Status.Disponivel, IsDeleted = true },
                new Livro { Id = 8, Titulo = "Sombras da noite", DataPublicacao = new DateTime(2021, 12, 5), Status = Status.Emprestado, IsDeleted = false },
                new Livro { Id = 9, Titulo = "O código antigo", DataPublicacao = new DateTime(2020, 6, 19), Status = Status.EmRevisao, IsDeleted = false },
                new Livro { Id = 10, Titulo = "Entre montanhas", DataPublicacao = new DateTime(2017, 4, 2), Status = Status.Disponivel, IsDeleted = true },
                new Livro { Id = 11, Titulo = "O guardião do tempo", DataPublicacao = new DateTime(2023, 2, 28), Status = Status.Emprestado, IsDeleted = false },
                new Livro { Id = 12, Titulo = "Fragmentos de um sonho", DataPublicacao = new DateTime(2022, 10, 9), Status = Status.EmRevisao, IsDeleted = false },
                new Livro { Id = 13, Titulo = "Cidade das cinzas", DataPublicacao = new DateTime(2019, 8, 17), Status = Status.Disponivel, IsDeleted = true },
                new Livro { Id = 14, Titulo = "O enigma final", DataPublicacao = new DateTime(2021, 3, 25), Status = Status.Emprestado, IsDeleted = false },
                new Livro { Id = 15, Titulo = "Horizonte infinito", DataPublicacao = new DateTime(2020, 11, 11), Status = Status.EmRevisao, IsDeleted = false },
                new Livro { Id = 16, Titulo = "A chama eterna", DataPublicacao = new DateTime(2018, 1, 6), Status = Status.Disponivel, IsDeleted = true },
                new Livro { Id = 17, Titulo = "Ecos do passado", DataPublicacao = new DateTime(2023, 5, 20), Status = Status.Emprestado, IsDeleted = false },
                new Livro { Id = 18, Titulo = "A estrada esquecida", DataPublicacao = new DateTime(2022, 4, 13), Status = Status.EmRevisao, IsDeleted = false },
                new Livro { Id = 19, Titulo = "Além das estrelas", DataPublicacao = new DateTime(2019, 2, 27), Status = Status.Disponivel, IsDeleted = true },
                new Livro { Id = 20, Titulo = "O despertar", DataPublicacao = new DateTime(2021, 7, 7), Status = Status.Emprestado, IsDeleted = false },
                new Livro { Id = 21, Titulo = "Ventos do norte", DataPublicacao = new DateTime(2020, 9, 3), Status = Status.EmRevisao, IsDeleted = false }
            );
        });
    }
}
