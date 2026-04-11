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
    public DbSet<Professor> Professores { get; set; }
    public DbSet<Aluno> Alunos { get; set; }
    public DbSet<Curso> Cursos { get; set; }

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

        modelBuilder.Entity<Aluno>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Nome)
                  .HasMaxLength(255)
                  .IsRequired();

            entity.HasOne(e => e.Curso)
                  .WithMany(e => e.Alunos)
                  .HasForeignKey(e => e.CursoId);

            entity.HasData(
                // Curso 1 (10 alunos)
                new Aluno { Id = 1, Nome = "Aluno 1", CursoId = 1 },
                new Aluno { Id = 2, Nome = "Aluno 2", CursoId = 1 },
                new Aluno { Id = 3, Nome = "Aluno 3", CursoId = 1 },
                new Aluno { Id = 4, Nome = "Aluno 4", CursoId = 1 },
                new Aluno { Id = 5, Nome = "Aluno 5", CursoId = 1 },
                new Aluno { Id = 6, Nome = "Aluno 6", CursoId = 1 },
                new Aluno { Id = 7, Nome = "Aluno 7", CursoId = 1 },
                new Aluno { Id = 8, Nome = "Aluno 8", CursoId = 1 },
                new Aluno { Id = 9, Nome = "Aluno 9", CursoId = 1 },
                new Aluno { Id = 10, Nome = "Aluno 10", CursoId = 1 },

                // Curso 2 (10 alunos)
                new Aluno { Id = 11, Nome = "Aluno 11", CursoId = 2 },
                new Aluno { Id = 12, Nome = "Aluno 12", CursoId = 2 },
                new Aluno { Id = 13, Nome = "Aluno 13", CursoId = 2 },
                new Aluno { Id = 14, Nome = "Aluno 14", CursoId = 2 },
                new Aluno { Id = 15, Nome = "Aluno 15", CursoId = 2 },
                new Aluno { Id = 16, Nome = "Aluno 16", CursoId = 2 },
                new Aluno { Id = 17, Nome = "Aluno 17", CursoId = 2 },
                new Aluno { Id = 18, Nome = "Aluno 18", CursoId = 2 },
                new Aluno { Id = 19, Nome = "Aluno 19", CursoId = 2 },
                new Aluno { Id = 20, Nome = "Aluno 20", CursoId = 2 },

                // Curso 3 (10 alunos)
                new Aluno { Id = 21, Nome = "Aluno 21", CursoId = 3 },
                new Aluno { Id = 22, Nome = "Aluno 22", CursoId = 3 },
                new Aluno { Id = 23, Nome = "Aluno 23", CursoId = 3 },
                new Aluno { Id = 24, Nome = "Aluno 24", CursoId = 3 },
                new Aluno { Id = 25, Nome = "Aluno 25", CursoId = 3 },
                new Aluno { Id = 26, Nome = "Aluno 26", CursoId = 3 },
                new Aluno { Id = 27, Nome = "Aluno 27", CursoId = 3 },
                new Aluno { Id = 28, Nome = "Aluno 28", CursoId = 3 },
                new Aluno { Id = 29, Nome = "Aluno 29", CursoId = 3 },
                new Aluno { Id = 30, Nome = "Aluno 30", CursoId = 3 }
            );

        });

        modelBuilder.Entity<Professor>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Nome)
                  .HasMaxLength(255)
                  .IsRequired();

            entity.HasData(
                new Professor { Id = 1, Nome = "Professor 1" },
                new Professor { Id = 2, Nome = "Professor 2" },
                new Professor { Id = 3, Nome = "Professor 3" },
                new Professor { Id = 4, Nome = "Professor 4" },
                new Professor { Id = 5, Nome = "Professor 5" }
            );
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Nome)
                  .HasMaxLength(255)
                  .IsRequired();

            entity.HasOne(e => e.Coordenador)
                  .WithOne(e => e.Curso)
                  .HasForeignKey<Curso>(c => c.CoordenadorId)
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(c => c.CoordenadorId)
                  .IsUnique();

            entity.HasData(
                new Curso { Id = 1, Nome = "Curso 1", CoordenadorId = 1 },
                new Curso { Id = 2, Nome = "Curso 2", CoordenadorId = 2 },
                new Curso { Id = 3, Nome = "Curso 3", CoordenadorId = 3 }
            );
        });
    }
}
