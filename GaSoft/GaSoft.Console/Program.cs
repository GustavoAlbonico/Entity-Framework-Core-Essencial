
using GaSoft.Domain.Entities;
using GaSoft.Domain.Entities.Enum;
using GaSoft.EFCore.Context;
using Microsoft.EntityFrameworkCore;

using AppDbContext _context = new AppDbContext();

_context.Database.EnsureDeleted();
Console.WriteLine("Criando o banco de dados... \n");
_context.Database.EnsureCreated();

//EAGER LOADING
var departamentos = _context.Departamentos
                            .Include(d => d.Funcionarios)
                            .ThenInclude(f => f.FuncionarioDetalhe)
                            .ToList();

//LAZY LOADING com proxies
//nesse caso está gerando o problema n+1 se eu querer acessar funcionarios.
var departamentos1 = _context.Departamentos
                            .ToList();


Console.ReadKey();

void IncluirFuncionarioEDetalhe(AppDbContext context)
{
    var detalheFuncionario1 = new FuncionarioDetalhe
    {
        EnderecoResidencial = "Rua Exemplo, 123",
        DataNascimento = new DateTime(1985, 5, 10),
        Celular = "1234567890",
        Genero = Genero.Masculino,
        Foto = "foto1.jpg",
        EstadoCivil = EstadoCivil.Solteiro,
        CPF = "123.456.789-00",
        Nacionalidade = "Brasileiro",
        Escolaridade = Escolaridade.Superior
    };

    var funcionario1 = new Funcionario
    {
        Nome = "Robertinho detalhhes",
        Cargo = "Dev",
        Salario = 3000m,
        DataContratacao = new DateOnly(2024, 6, 7),
        DepartamentoId = 5,
        FuncionarioDetalhe = detalheFuncionario1,
    };

    context.Funcionarios.Add(funcionario1);
    context.SaveChanges();
}

void IncluirFuncionario(AppDbContext context)
{
    var funcionario = new Funcionario
    {
        Nome = "Jão Silva",
        Cargo = "Analista",
        Salario = 5000.00m,
        DataContratacao = new DateOnly(2023, 1, 15),
        DepartamentoId = 1, //esse departamento já foi cadastrado
    };

    context.Funcionarios.Add(funcionario);
    context.SaveChanges();
}

void IncluirFuncionarioAddRange(AppDbContext context)
{
    var funcionarios = new List<Funcionario> {
        new Funcionario
        {
            Nome = "Tiago Silva",
            Cargo = "Desenvolvedor Frontend",
            Salario = 4000.00m,
            DataContratacao = new DateOnly(2024, 1, 15),
            DepartamentoId = 2, //esse departamento já foi cadastrado
        },
         new Funcionario
         {
             Nome = "Luisa Silva",
             Cargo = "Desenvolvedor Backend",
             Salario = 4000.00m,
             DataContratacao = new DateOnly(2020, 1, 15),
             DepartamentoId = 3, //esse departamento já foi cadastrado
         }
    };

    context.Funcionarios.AddRange(funcionarios);
    context.SaveChanges();
}

void IncluirFuncionarioAddRelacional(AppDbContext context)
{
    var departamento = new Departamento
    {
        Nome = "Recursos Humanos",
        Descricao = "paga a galera"
    };

    departamento.Funcionarios.Add(new Funcionario
    {
        Nome = "Roberta Silva",
        Cargo = "RH",
        Salario = 3000.00m,
        DataContratacao = new DateOnly(2022, 1, 15),
    });

    context.Departamentos.Add(departamento);
    context.SaveChanges();
}

void IncluirFuncionarioAddRangeRelacional(AppDbContext context)
{
    var departamento = new Departamento
    {
        Nome = "Vendas",
        Descricao = "Vendas e Compras"
    };

    var funcionarios = new List<Funcionario>
    {
        new Funcionario
        {
            Nome = "Beatriz Souza",
            Cargo = "Coordenadora de compras",
            Salario =  4700.00m,
            DataContratacao = new DateOnly(2020,3,1),
            Departamento = departamento
        },

        new Funcionario
        {
            Nome = "Julio Soarez",
            Cargo = "Vendedor",
            Salario =  3800.00m,
            DataContratacao = new DateOnly(2021,3,1),
            Departamento = departamento
        }
    };

    context.Funcionarios.AddRange(funcionarios);
    context.SaveChanges();
}

//void CriarDepartamento(AppDbContext context)
//{
//    var departamentos = new List<Departamento>
//    {
//        new Departamento { Nome = "Financeiro", Descricao = "Desenvolvimento de projetos"},
//        new Departamento { Nome = "Marketing", Descricao = "Promoção de produtos"},
//        new Departamento { Nome = "RH", Descricao = "Recursos Humanos"},
//    };

//    context.Departamento.AddRange(departamentos);
//    context.SaveChanges();
//}

