using GaSoft.Domain.Entities;
using GaSoft.Domain.Entities.Enum;
using Microsoft.EntityFrameworkCore;

namespace GaSoft.EFCore.Context;

public class AppDbContext : DbContext
{
    public DbSet<Departamento> Departamentos { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<FuncionarioDetalhe> FuncionarioDetalhes { get; set; }
    public DbSet<Projeto> Projetos { get; set; }
    public DbSet<FuncionarioProjeto> FuncionariosProjetos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }

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

        modelBuilder.Entity<FuncionarioDetalhe>(entity =>
        {
            entity.Property(e => e.EnderecoResidencial)
                  .HasMaxLength(200)
                  .IsRequired();

            entity.Property(e => e.Celular)
                  .HasMaxLength(50)
                  .IsRequired();

            entity.Property(e => e.Foto)
                  .HasMaxLength(200)
                  .IsRequired();

            entity.Property(e => e.CPF)
                  .HasMaxLength(20)
                  .IsRequired();

            entity.Property(e => e.Nacionalidade)
                  .HasMaxLength(50)
                  .IsRequired();

            entity.Property(e => e.Genero)
                  .IsRequired();

            entity.Property(e => e.Escolaridade)
                  .IsRequired();

            entity.Property(e => e.EstadoCivil)
                  .IsRequired();

            entity.HasData(
                 new FuncionarioDetalhe { Id = 1, FuncionarioId = 1, EnderecoResidencial = "Rua A, 123", DataNascimento = new DateTime(1990, 5, 10), Celular = "999999999", Genero = Genero.Masculino, Foto = "foto1.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "12345678901", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.PosGraduacao },
                 new FuncionarioDetalhe { Id = 2, FuncionarioId = 2, EnderecoResidencial = "Rua B, 234", DataNascimento = new DateTime(1988, 11, 20), Celular = "988888888", Genero = Genero.Masculino, Foto = "foto2.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "23456789012", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
                 new FuncionarioDetalhe { Id = 3, FuncionarioId = 3, EnderecoResidencial = "Rua C, 345", DataNascimento = new DateTime(1992, 8, 15), Celular = "977777777", Genero = Genero.Feminino, Foto = "foto3.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "34567890123", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Mestrado },
                 new FuncionarioDetalhe { Id = 4, FuncionarioId = 4, EnderecoResidencial = "Rua D, 456", DataNascimento = new DateTime(1985, 2, 25), Celular = "966666666", Genero = Genero.Masculino, Foto = "foto4.jpg", EstadoCivil = EstadoCivil.Divorciado, CPF = "45678901234", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.PosGraduacao },
                 new FuncionarioDetalhe { Id = 5, FuncionarioId = 5, EnderecoResidencial = "Rua E, 567", DataNascimento = new DateTime(1994, 3, 5), Celular = "955555555", Genero = Genero.Feminino, Foto = "foto5.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "56789012345", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
                 new FuncionarioDetalhe { Id = 6, FuncionarioId = 6, EnderecoResidencial = "Rua F, 678", DataNascimento = new DateTime(1989, 12, 15), Celular = "944444444", Genero = Genero.Masculino, Foto = "foto6.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "67890123456", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Mestrado },

                 new FuncionarioDetalhe { Id = 7, FuncionarioId = 7, EnderecoResidencial = "Rua G, 789", DataNascimento = new DateTime(1991, 7, 21), Celular = "933333333", Genero = Genero.Feminino, Foto = "foto7.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "78901234567", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
                 new FuncionarioDetalhe { Id = 8, FuncionarioId = 8, EnderecoResidencial = "Rua H, 890", DataNascimento = new DateTime(1986, 4, 14), Celular = "922222222", Genero = Genero.Masculino, Foto = "foto8.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "89012345678", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Mestrado },
                 new FuncionarioDetalhe { Id = 9, FuncionarioId = 9, EnderecoResidencial = "Rua I, 901", DataNascimento = new DateTime(1993, 9, 12), Celular = "911111111", Genero = Genero.Feminino, Foto = "foto9.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "90123456789", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.PosGraduacao },
                 new FuncionarioDetalhe { Id = 10, FuncionarioId = 10, EnderecoResidencial = "Rua J, 101", DataNascimento = new DateTime(1995, 11, 18), Celular = "900000000", Genero = Genero.Masculino, Foto = "foto10.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "01234567890", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },

                 new FuncionarioDetalhe { Id = 11, FuncionarioId = 11, EnderecoResidencial = "Rua K, 111", DataNascimento = new DateTime(1987, 1, 22), Celular = "988888888", Genero = Genero.Feminino, Foto = "foto11.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "11111100111", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.PosGraduacao },
                 new FuncionarioDetalhe { Id = 12, FuncionarioId = 12, EnderecoResidencial = "Rua L, 121", DataNascimento = new DateTime(1990, 2, 2), Celular = "977777777", Genero = Genero.Masculino, Foto = "foto12.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "22222112222", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Mestrado },
                 new FuncionarioDetalhe { Id = 13, FuncionarioId = 13, EnderecoResidencial = "Rua M, 131", DataNascimento = new DateTime(1991, 3, 3), Celular = "966666666", Genero = Genero.Feminino, Foto = "foto13.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "33333322333", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
                 new FuncionarioDetalhe { Id = 14, FuncionarioId = 14, EnderecoResidencial = "Rua N, 141", DataNascimento = new DateTime(1992, 4, 4), Celular = "955555555", Genero = Genero.Masculino, Foto = "foto14.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "44444114444", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.PosGraduacao },
                 new FuncionarioDetalhe { Id = 15, FuncionarioId = 15, EnderecoResidencial = "Rua O, 151", DataNascimento = new DateTime(1993, 5, 5), Celular = "944444444", Genero = Genero.Feminino, Foto = "foto15.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "55555533555", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
                 new FuncionarioDetalhe { Id = 16, FuncionarioId = 16, EnderecoResidencial = "Rua P, 161", DataNascimento = new DateTime(1994, 6, 6), Celular = "933333333", Genero = Genero.Masculino, Foto = "foto16.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "66666446666", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Mestrado },
                 new FuncionarioDetalhe { Id = 17, FuncionarioId = 17, EnderecoResidencial = "Rua Q, 171", DataNascimento = new DateTime(1995, 7, 7), Celular = "922222222", Genero = Genero.Feminino, Foto = "foto17.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "77777777777", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
                 new FuncionarioDetalhe { Id = 18, FuncionarioId = 18, EnderecoResidencial = "Rua R, 181", DataNascimento = new DateTime(1996, 8, 8), Celular = "911111111", Genero = Genero.Masculino, Foto = "foto18.jpg", EstadoCivil = EstadoCivil.Divorciado, CPF = "87788888888", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Tecnico },
                 new FuncionarioDetalhe { Id = 19, FuncionarioId = 19, EnderecoResidencial = "Rua S, 191", DataNascimento = new DateTime(1997, 9, 9), Celular = "900000000", Genero = Genero.Feminino, Foto = "foto19.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "99999799999", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Mestrado },
                 new FuncionarioDetalhe { Id = 20, FuncionarioId = 20, EnderecoResidencial = "Rua T, 201", DataNascimento = new DateTime(1988, 10, 10), Celular = "988888888", Genero = Genero.Masculino, Foto = "foto20.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "00100000000", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },

                 new FuncionarioDetalhe { Id = 21, FuncionarioId = 21, EnderecoResidencial = "Rua U, 211", DataNascimento = new DateTime(1989, 11, 11), Celular = "977777777", Genero = Genero.Feminino, Foto = "foto21.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "11112222202", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
                 new FuncionarioDetalhe { Id = 22, FuncionarioId = 22, EnderecoResidencial = "Rua V, 521", DataNascimento = new DateTime(1990, 12, 12), Celular = "966666666", Genero = Genero.Masculino, Foto = "foto22.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "22223033333", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Mestrado },
                 new FuncionarioDetalhe { Id = 23, FuncionarioId = 23, EnderecoResidencial = "Rua W, 231", DataNascimento = new DateTime(1991, 1, 13), Celular = "955555555", Genero = Genero.Feminino, Foto = "foto23.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "33334444044", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
                 new FuncionarioDetalhe { Id = 24, FuncionarioId = 24, EnderecoResidencial = "Rua X, 141", DataNascimento = new DateTime(1992, 2, 14), Celular = "944444444", Genero = Genero.Masculino, Foto = "foto24.jpg", EstadoCivil = EstadoCivil.Divorciado, CPF = "44045555555", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.PosGraduacao },
                 new FuncionarioDetalhe { Id = 25, FuncionarioId = 25, EnderecoResidencial = "Rua Y, 251", DataNascimento = new DateTime(1993, 3, 15), Celular = "933333333", Genero = Genero.Feminino, Foto = "foto25.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "55556606666", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Tecnico },
                 new FuncionarioDetalhe { Id = 26, FuncionarioId = 26, EnderecoResidencial = "Rua Z, 461", DataNascimento = new DateTime(1994, 4, 16), Celular = "922222222", Genero = Genero.Masculino, Foto = "foto26.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "66667777777", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Mestrado },
                 new FuncionarioDetalhe { Id = 27, FuncionarioId = 27, EnderecoResidencial = "Rua AA, 271", DataNascimento = new DateTime(1995, 5, 17), Celular = "911111111", Genero = Genero.Feminino, Foto = "foto27.jpg", EstadoCivil = EstadoCivil.Viuvo, CPF = "77778888888", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
                 new FuncionarioDetalhe { Id = 28, FuncionarioId = 28, EnderecoResidencial = "Rua AB, 181", DataNascimento = new DateTime(1996, 6, 18), Celular = "900000000", Genero = Genero.Masculino, Foto = "foto28.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "88889999999", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.PosGraduacao },

                 new FuncionarioDetalhe { Id = 29, FuncionarioId = 29, EnderecoResidencial = "Rua UU, 271", DataNascimento = new DateTime(1989, 11, 11), Celular = "977777777", Genero = Genero.Masculino, Foto = "foto29.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "11182222222", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.PosGraduacao },
                 new FuncionarioDetalhe { Id = 30, FuncionarioId = 30, EnderecoResidencial = "Rua VV, 241", DataNascimento = new DateTime(1990, 12, 12), Celular = "966646666", Genero = Genero.Masculino, Foto = "foto30.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "22229333333", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Mestrado },
                 new FuncionarioDetalhe { Id = 31, FuncionarioId = 31, EnderecoResidencial = "Rua WW, 261", DataNascimento = new DateTime(1991, 1, 13), Celular = "955557555", Genero = Genero.Feminino, Foto = "foto31.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "33335444444", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Tecnico },
                 new FuncionarioDetalhe { Id = 32, FuncionarioId = 32, EnderecoResidencial = "Rua XX, 801", DataNascimento = new DateTime(1992, 2, 14), Celular = "944448444", Genero = Genero.Masculino, Foto = "foto32.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "44447555555", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.PosGraduacao },
                 new FuncionarioDetalhe { Id = 33, FuncionarioId = 33, EnderecoResidencial = "Rua YY, 21", DataNascimento = new DateTime(1993, 3, 15), Celular = "93333383", Genero = Genero.Feminino, Foto = "foto33.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "55556666966", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
                 new FuncionarioDetalhe { Id = 34, FuncionarioId = 34, EnderecoResidencial = "Rua ZZ, 121", DataNascimento = new DateTime(1994, 4, 16), Celular = "922222322", Genero = Genero.Masculino, Foto = "foto34.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "66667477777", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Mestrado },
                 new FuncionarioDetalhe { Id = 35, FuncionarioId = 35, EnderecoResidencial = "Rua AAA, 21", DataNascimento = new DateTime(1995, 5, 17), Celular = "911111011", Genero = Genero.Masculino, Foto = "foto35.jpg", EstadoCivil = EstadoCivil.Viuvo, CPF = "77778881888", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Tecnico },
                 new FuncionarioDetalhe { Id = 36, FuncionarioId = 36, EnderecoResidencial = "Rua ABC, 28", DataNascimento = new DateTime(1996, 6, 18), Celular = "900001100", Genero = Genero.Masculino, Foto = "foto36.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "88882999999", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.PosGraduacao },

                 new FuncionarioDetalhe { Id = 37, FuncionarioId = 37, EnderecoResidencial = "Rua XYC, 24", DataNascimento = new DateTime(1992, 2, 14), Celular = "944440044", Genero = Genero.Masculino, Foto = "foto37.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "44445555555", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.PosGraduacao },
                 new FuncionarioDetalhe { Id = 38, FuncionarioId = 38, EnderecoResidencial = "Rua YED, 21", DataNascimento = new DateTime(1993, 3, 15), Celular = "933300333", Genero = Genero.Masculino, Foto = "foto38.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "55556666766", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
                 new FuncionarioDetalhe { Id = 39, FuncionarioId = 39, EnderecoResidencial = "Rua ZAB, 191", DataNascimento = new DateTime(1994, 4, 16), Celular = "922112222", Genero = Genero.Masculino, Foto = "foto39.jpg", EstadoCivil = EstadoCivil.Divorciado, CPF = "66367777777", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Tecnico },
                 new FuncionarioDetalhe { Id = 40, FuncionarioId = 40, EnderecoResidencial = "Rua AAT, 601", DataNascimento = new DateTime(1995, 5, 17), Celular = "911001111", Genero = Genero.Feminino, Foto = "foto40.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "77778880888", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
                 new FuncionarioDetalhe { Id = 41, FuncionarioId = 41, EnderecoResidencial = "Rua ABR, 721", DataNascimento = new DateTime(1996, 6, 18), Celular = "900110000", Genero = Genero.Masculino, Foto = "foto41.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "88889199999", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Tecnico },

                 new FuncionarioDetalhe { Id = 42, FuncionarioId = 42, EnderecoResidencial = "Rua ACY, 210", DataNascimento = new DateTime(1997, 7, 19), Celular = "988778888", Genero = Genero.Feminino, Foto = "foto42.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "99990000000", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Mestrado },
                 new FuncionarioDetalhe { Id = 43, FuncionarioId = 43, EnderecoResidencial = "Rua ADX, 39", DataNascimento = new DateTime(1998, 7, 19), Celular = "988779888", Genero = Genero.Feminino, Foto = "foto43.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "99990000002", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Tecnico },
                 new FuncionarioDetalhe { Id = 44, FuncionarioId = 44, EnderecoResidencial = "Rua AJW, 491", DataNascimento = new DateTime(1998, 11, 9), Celular = "988770866", Genero = Genero.Masculino, Foto = "foto44.jpg", EstadoCivil = EstadoCivil.Divorciado, CPF = "99990700001", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
                 new FuncionarioDetalhe { Id = 45, FuncionarioId = 45, EnderecoResidencial = "Rua ADT, 501", DataNascimento = new DateTime(1988, 8, 20), Celular = "977776777", Genero = Genero.Masculino, Foto = "foto45.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "00001111111", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Tecnico }
            );
    });

        modelBuilder.Entity<FuncionarioProjeto>(entity =>
        {
            entity.HasKey(e => new { e.FuncionarioId, e.ProjetoId });
        });

        modelBuilder.Entity<Projeto>(entity =>
        {
            entity.Property(e => e.Nome)
                  .HasMaxLength(100)
                  .IsRequired();

            entity.Property(e => e.Descricao)
                  .HasMaxLength(200)
                  .IsRequired();

            entity.Property(e => e.Orcamento)
                  .HasPrecision(20, 2);

            //DateTime é do tipo struct e o enum com numero definidos tambem
            //nesse caso ele é automaticamente definido como not null

        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.Property(e => e.Nome)
                  .HasMaxLength(100)
                  .IsRequired();

            entity.Property(e => e.Email)
                  .HasMaxLength(200)
                  .IsRequired();

            entity.Property(e => e.Telefone)
                  .HasMaxLength(50)
                  .IsRequired();

            entity.HasData(
                  new Cliente { Id = 1, Nome = "Grupo ABroad SA", Email = "abroad@email.com", Telefone = "55-11 9980-0099" },
                  new Cliente { Id = 2, Nome = "Construtora ABC", Email = "abcconstru@email.com", Telefone = "55-31 8957-1022" },
                  new Cliente { Id = 3, Nome = "EduFuture Corp.", Email = "edufuture@email.com", Telefone = "55-11 8750-4422" },
                  new Cliente { Id = 4, Nome = "Tech Innovators Ltda", Email = "innovators@email.com", Telefone = "55-11 9950-9622" },
                  new Cliente { Id = 5, Nome = "Health Solutions Inc.", Email = "healtsolutions@email.com", Telefone = "55-21 9852-9655" }
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
