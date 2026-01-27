
using GaSoft.Domain.Entities;
using GaSoft.EFCore.Context;

using (AppDbContext context = new AppDbContext())
{
    context.Database.EnsureDeleted();
    Console.WriteLine("Criando o banco de dados... \n");
    context.Database.EnsureCreated();

    //Console.WriteLine("Criando um Funcionario...\n");
    //IncluirFuncionario(context);
    //IncluirFuncionarioAddRange(context);
    //Console.WriteLine("Criadno Departamento e Funcionario...\n");
    //IncluirFuncionarioAddRelacional(context);
    //IncluirFuncionarioAddRangeRelacional(context);


    //Console.WriteLine("Criando um departamento...\n");
    //CriarDepartamento(context);
    // Console.WriteLine("Departamento criado...\n");

    //var departamentos = context.Departamentos.ToList();

    //foreach (var departamento in departamentos)
    //{
    //    Console.WriteLine($"ID: {departamento.Id}, Nome: {departamento.Nome}");
    //}

    //FirstOrDefault
    //var departamento = context.Departamentos.FirstOrDefault(d => d.Id == 1);

    //Console.WriteLine(departamento is not null ? $"ID: {departamento.Id}, Nome: {departamento.Nome}" : "Departamento não encontrado");
}

Console.ReadKey();
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

