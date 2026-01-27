using GaSoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GaSoft.EFCore.Context;

public class AppDbContext : DbContext
{
    public DbSet<Departamento> Departamentos { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(AppConfig.GetConnectionString())
                      .UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Departamento>(entity =>
        {

            entity.Property(e => e.Nome)
                  .HasMaxLength(100)
                  .IsRequired();

            entity.Property(e => e.Descricao)
                  .HasMaxLength(200)
                  .IsRequired();

            //seed
            entity.HasData(
                 new Departamento {Id = 1, Nome = "Financeiro", Descricao = "Desenvolvimento de projetos" },
                 new Departamento {Id = 2, Nome = "Marketing", Descricao = "Promoção de produtos" },
                 new Departamento {Id = 3, Nome = "RH", Descricao = "Recursos Humanos" }
            );

        });

        modelBuilder.Entity<Funcionario>(entity =>
        {
            entity.Property(e => e.Nome)
                  .HasMaxLength(100)
                  .IsRequired();

            entity.Property(e => e.Cargo)
                  .HasMaxLength(100)
                  .IsRequired();

            entity.Property(e => e.Salario)
                  .HasPrecision(10, 2);

        });



        //modelBuilder.HasDefaultSchema("gasoft");
        //            entity.ToTable("Setores");
        //entity.Property(e => e.dataCriacao)
        //      .ValueGeneratedOnAddOrUpdate()
        //      .HasDefaultValueSql("GETDATE()");


        //modelBuilder.Entity<Departamento>()
        //            .HasKey(d => d.Id);

        //modelBuilder.Entity<Departamento>()
        //            .Property(d => d.Nome)
        //            .HasColumnType("nvarchar(110)")
        //            .IsRequired();

        //modelBuilder.Entity<Departamento>()
        //            .Property(d => d.Descricao)
        //            .HasColumnName("Descricao_Departamento")
        //            .HasMaxLength(200)
        //            .HasColumnType("varchar(210)");
    }
}
