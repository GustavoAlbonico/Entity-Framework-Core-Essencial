using GaSoft.Domain.Entities;
using GaSoft.Domain.Entities.Enum;
using GaSoft.EFCore.FuncoesSQL;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GaSoft.EFCore.Context;

public class AppDbContext : DbContext
{
    public DbSet<Departamento> Departamentos { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<FuncionarioDetalhe> FuncionarioDetalhes { get; set; }
    public DbSet<Projeto> Projetos { get; set; }
    public DbSet<FuncionarioProjeto> FuncionariosProjetos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<FuncionarioDepartamentoView> FuncionariosDepartamentoView { get; set; }

    public IQueryable<Projeto> ProjetosAtivosApos(DateTime dataInicio)
                        => FromExpression(() => ProjetosAtivosApos(dataInicio));

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(AppConfig.GetConnectionString())
                      .UseSnakeCaseNamingConvention()
                      //.UseSqlServer(sql => sql.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))// slitquery global
                      //.UseLazyLoadingProxies() -> lazy loading
                      .LogTo(Console.WriteLine,
                        new[] { DbLoggerCategory.Database.Command.Name },
                        Microsoft.Extensions.Logging.LogLevel.Information);
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.HasDbFunction(() => FuncoesSql.CalcularAnosDeServico(default))
                    .HasName("CalcularAnosDeServico")
                    .HasSchema("dbo");

        modelBuilder
            .HasDbFunction(typeof(AppDbContext)
            .GetMethod(nameof(ProjetosAtivosApos), new[] { typeof(DateTime) })!)
            .HasName("ProjetosAtivosApos")
            .HasSchema("dbo");

        modelBuilder.HasSequence<int>("NumeroOSSequence")
                .StartsAt(2001)
                .IncrementsBy(10)
                .HasMin(2001)
                .HasMax(999999);
        //.IsCyclic();

        modelBuilder.Entity<Projeto>()
            .Property(p => p.NumeroOrdemServico)
            .HasDefaultValueSql("NEXT VALUE FOR NumeroOSSequence");

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
