using GaSoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GaSoft.EFCore.Context;

public class AppDbContext : DbContext
{
    public DbSet<Departamento> Departamentos { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<FuncionarioDetalhe> FuncionarioDetalhes { get; set; }

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
                  new Departamento { Id = 1, Nome = "Financeiro", Descricao = "Gestão das finanças" },
                  new Departamento { Id = 2, Nome = "Marketing", Descricao = "Promoção de produtos" },
                  new Departamento { Id = 3, Nome = "RH", Descricao = "Recursos Humanos" },
                  new Departamento { Id = 4, Nome = "Suporte", Descricao = "Atendimento ao cliente" },
                  new Departamento { Id = 5, Nome = "TI", Descricao = "Tecnologia da Informação" },
                  new Departamento { Id = 6, Nome = "Vendas", Descricao = "Gestão de Vendas" }
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

            entity.HasData(
               // Funcionários do Financeiro
               new Funcionario { Id = 1, Nome = "João Silva", Cargo = "Gerente de Finanças", Salario = 5250.00m, DataContratacao = new DateOnly(2023, 1, 15), DepartamentoId = 1 },
               new Funcionario { Id = 2, Nome = "Carlos Pereira", Cargo = "Analista Financeiro", Salario = 4500.00m, DataContratacao = new DateOnly(2021, 11, 10), DepartamentoId = 1 },
               new Funcionario { Id = 3, Nome = "Ana Souza", Cargo = "Analista Contábil", Salario = 4300.00m, DataContratacao = new DateOnly(2022, 2, 15), DepartamentoId = 1 },
               new Funcionario { Id = 4, Nome = "Marcos Lima", Cargo = "Assistente Financeiro", Salario = 3200.00m, DataContratacao = new DateOnly(2022, 5, 20), DepartamentoId = 1 },
               new Funcionario { Id = 5, Nome = "Fernanda Oliveira", Cargo = "Coordenadora Financeira", Salario = 4800.00m, DataContratacao = new DateOnly(2023, 4, 5), DepartamentoId = 1 },
               new Funcionario { Id = 6, Nome = "José Santos", Cargo = "Técnico em Contabilidade", Salario = 3400.00m, DataContratacao = new DateOnly(2023, 7, 18), DepartamentoId = 1 },

               // Funcionários do Marketing
               new Funcionario { Id = 7, Nome = "Lucia Benitez", Cargo = "Coordenador de Marketing", Salario = 4500.00m, DataContratacao = new DateOnly(2021, 11, 10), DepartamentoId = 2 },
               new Funcionario { Id = 8, Nome = "Pedro Cardoso", Cargo = "Analista de Marketing", Salario = 4100.00m, DataContratacao = new DateOnly(2022, 8, 22), DepartamentoId = 2 },
               new Funcionario { Id = 9, Nome = "Carla Teixeira", Cargo = "Especialista em SEO", Salario = 3900.00m, DataContratacao = new DateOnly(2022, 10, 15), DepartamentoId = 2 },
               new Funcionario { Id = 10, Nome = "Fabiana Costa", Cargo = "Gerente de Marketing", Salario = 5100.00m, DataContratacao = new DateOnly(2023, 3, 1), DepartamentoId = 2 },

               // Funcionários do RH
               new Funcionario { Id = 11, Nome = "Roberto Ferreira", Cargo = "Analista de Recursos Humanos", Salario = 4400.00m, DataContratacao = new DateOnly(2021, 9, 20), DepartamentoId = 3 },
               new Funcionario { Id = 12, Nome = "Beatriz Almeida", Cargo = "Gerente de Recursos Humanos", Salario = 5000.00m, DataContratacao = new DateOnly(2022, 3, 10), DepartamentoId = 3 },
               new Funcionario { Id = 13, Nome = "Lucas Santos", Cargo = "Coordenador de Recursos Humanos", Salario = 4600.00m, DataContratacao = new DateOnly(2022, 7, 15), DepartamentoId = 3 },
               new Funcionario { Id = 14, Nome = "Mariana Dias", Cargo = "Assistente de Recursos Humanos", Salario = 3200.00m, DataContratacao = new DateOnly(2023, 5, 5), DepartamentoId = 3 },

               // Funcionários do Suporte
               new Funcionario { Id = 15, Nome = "Juliana Mendes", Cargo = "Analista de Suporte", Salario = 3600.00m, DataContratacao = new DateOnly(2022, 6, 15), DepartamentoId = 4 },
               new Funcionario { Id = 16, Nome = "Rafael Souza", Cargo = "Técnico de Suporte", Salario = 3400.00m, DataContratacao = new DateOnly(2022, 8, 22), DepartamentoId = 4 },
               new Funcionario { Id = 17, Nome = "André Oliveira", Cargo = "Especialista em Suporte", Salario = 3800.00m, DataContratacao = new DateOnly(2022, 10, 15), DepartamentoId = 4 },
               new Funcionario { Id = 18, Nome = "Bruno Costa", Cargo = "Coordenador de Suporte", Salario = 4000.00m, DataContratacao = new DateOnly(2023, 1, 1), DepartamentoId = 4 },
               new Funcionario { Id = 19, Nome = "Aline Dias", Cargo = "Assistente de Suporte", Salario = 3200.00m, DataContratacao = new DateOnly(2023, 3, 10), DepartamentoId = 4 },

               // Funcionários de TI
               new Funcionario { Id = 20, Nome = "Fernando Carvalho", Cargo = "Analista de TI", Salario = 4500.00m, DataContratacao = new DateOnly(2021, 11, 10), DepartamentoId = 5 },
               new Funcionario { Id = 21, Nome = "Gustavo Almeida", Cargo = "Desenvolvedor de Sistemas", Salario = 5000.00m, DataContratacao = new DateOnly(2022, 2, 15), DepartamentoId = 5 },
               new Funcionario { Id = 22, Nome = "Renata Silva", Cargo = "Coordenadora de TI", Salario = 4800.00m, DataContratacao = new DateOnly(2022, 5, 20), DepartamentoId = 5 },
               new Funcionario { Id = 23, Nome = "Thiago Souza", Cargo = "Técnico de Redes", Salario = 3600.00m, DataContratacao = new DateOnly(2023, 4, 5), DepartamentoId = 5 },
               new Funcionario { Id = 24, Nome = "Vanessa Oliveira", Cargo = "Engenheira de Software", Salario = 5200.00m, DataContratacao = new DateOnly(2023, 7, 18), DepartamentoId = 5 },
               new Funcionario { Id = 25, Nome = "Leonardo Pereira", Cargo = "Especialista em Segurança da Informação", Salario = 5500.00m, DataContratacao = new DateOnly(2023, 8, 1), DepartamentoId = 5 },

               // Funcionários de Vendas
               new Funcionario { Id = 26, Nome = "Marta Carvalho", Cargo = "Gerente de Vendas", Salario = 5200.00m, DataContratacao = new DateOnly(2021, 10, 10), DepartamentoId = 6 },
               new Funcionario { Id = 27, Nome = "Ricardo Pereira", Cargo = "Representante de Vendas", Salario = 4500.00m, DataContratacao = new DateOnly(2022, 2, 15), DepartamentoId = 6 },
               new Funcionario { Id = 28, Nome = "Patrícia Santos", Cargo = "Assistente de Vendas", Salario = 3200.00m, DataContratacao = new DateOnly(2022, 5, 20), DepartamentoId = 6 },
               new Funcionario { Id = 29, Nome = "Alberto Lima", Cargo = "Coordenador de Vendas", Salario = 4800.00m, DataContratacao = new DateOnly(2022, 7, 18), DepartamentoId = 6 },
               new Funcionario { Id = 30, Nome = "Bianca Souza", Cargo = "Especialista em Vendas", Salario = 5000.00m, DataContratacao = new DateOnly(2023, 3, 5), DepartamentoId = 6 },
               new Funcionario { Id = 31, Nome = "Rogério Oliveira", Cargo = "Consultor de Vendas", Salario = 4700.00m, DataContratacao = new DateOnly(2023, 6, 10), DepartamentoId = 6 },
               new Funcionario { Id = 32, Nome = "Sofia Almeida", Cargo = "Técnico de Vendas", Salario = 3400.00m, DataContratacao = new DateOnly(2023, 9, 1), DepartamentoId = 6 }
            );

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
