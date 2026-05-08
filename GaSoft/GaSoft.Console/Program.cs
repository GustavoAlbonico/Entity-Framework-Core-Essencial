
using GaSoft.Domain.Entities;
using GaSoft.Domain.Entities.Enum;
using GaSoft.EFCore.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;

using AppDbContext _context = new AppDbContext();

//_context.Database.EnsureDeleted();
//Console.WriteLine("Criando o banco de dados... \n");
//_context.Database.EnsureCreated();

//Exercicio1(_context);
//Exercicio2(_context);
//Exercicio3(_context);
//Exercicio5(_context);
//Exercicio6(_context);

/*
//EAGER LOADING
var departamentos = _context.Departamentos
                            .Include(d => d.Funcionarios)
                            .ThenInclude(f => f.FuncionarioDetalhe)
                            .ToList();

//LAZY LOADING com proxies
//nesse caso está gerando o problema n+1 se eu querer acessar funcionarios.
var departamentos1 = _context.Departamentos
                            .ToList();

//EXPLICIT LOADING
var departamento = _context.Departamentos.FirstOrDefault(d => d.Id == 1);

if(departamento != null)
{
    _context.Entry(departamento)
            .Collection(d => d.Funcionarios)
            .Load();

    foreach (var funcionario in departamento.Funcionarios)
    {

    }
}

//apenas valores chumbanos n pode ser dinamico
//não é aplicado em joins
var clientesAtivos = _context.Clientes.ToList(); //com query filter
var clientes = _context.Clientes.IgnoreQueryFilters().ToList(); // sem query filter

//Split query -> divide joins para otimizar e trazer menos dados repetidos
var departamentos3 = _context.Departamentos
                             .Include(d => d.Funcionarios)
                             .AsSplitQuery()
                             .ToList();

//AsNoTrackingWithIdentityResolution -> utiliza identity resolution porém sem change tracker
var departamentos3 = _context.Projetos
                             .AsNoTrackingWithIdentityResolution()
                             .Include(p => p.Cliente)
                             .ToList();

*/


Console.ReadKey();

/*
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

void CriarDepartamento(AppDbContext context)
{
    var departamentos = new List<Departamento>
    {
        new Departamento { Nome = "Financeiro", Descricao = "Desenvolvimento de projetos"},
        new Departamento { Nome = "Marketing", Descricao = "Promoção de produtos"},
        new Departamento { Nome = "RH", Descricao = "Recursos Humanos"},
    };

    context.Departamentos.AddRange(departamentos);
    context.SaveChanges();
}

void Exercicio1(AppDbContext context)
{

    var funcionarios = context.Funcionarios.Where(f => f.Salario > 5000 && f.FuncionarioDetalhe.Genero == Genero.Masculino)
                                           .Include(f => f.FuncionarioDetalhe)
                                           .Include(f => f.Departamento)
                                           .Include(f => f.FuncionariosProjetos
                                            .Where(fp => fp.HorasTrabalhadas > 100))
                                           .ThenInclude(fp => fp.Projeto)
                                           .ToList();

    Console.WriteLine("----------------------------- Execercicio 1 -----------------------------");




    foreach (var funcionario in funcionarios)
    {
        var projetos = new StringBuilder();

        foreach (var projeto in funcionario.FuncionariosProjetos)
            projetos.Append($"\n\t\t Nome:{projeto.Projeto.Nome} Horas Trabalhadas:{projeto.HorasTrabalhadas}");

        Console.WriteLine($"Nome:{funcionario.Nome} Salario:{funcionario.Salario} Genero:{funcionario.FuncionarioDetalhe.Genero} \n\t Departamento:{funcionario.Departamento?.Nome} \n\tProjeto:{projetos} \n");
    }
       
}

void Exercicio2(AppDbContext context)
{

    var funcionarios = context.Funcionarios.OrderBy(f => f.Nome)
                                           .Skip(10)
                                           .Take(5)
                                           .Select(f => new
                                           {
                                               NomeFuncionario = f.Nome,
                                               NomeDepartamento = f.Departamento.Nome,
                                               TotalHorasTrabalhadasProjetos = f.FuncionariosProjetos.Sum(fp => fp.HorasTrabalhadas)

                                           })
                                           .ToList();
    Console.WriteLine("----------------------------- Execercicio 2 -----------------------------");

    foreach (var funcionario in funcionarios)
    {
        Console.WriteLine($"NomeFuncionario:{funcionario.NomeFuncionario} NomeDepartamento:{funcionario.NomeDepartamento} TotalHorasTrabalhadas:{funcionario.TotalHorasTrabalhadasProjetos} \n");
    }
}

void Exercicio3(AppDbContext context)
{
  
    var departamentos = context.Departamentos.Include(d =>
        d.Funcionarios.Where(
            f => f.DataContratacao >= DateOnly.FromDateTime(new DateTime(2023, 8, 1)).AddMonths(-6)
        )
    )
    .Select(departamento => new {
        Nome = departamento.Nome,
        Funcionarios = departamento.Funcionarios,
        ValorTotalSalario = departamento.Funcionarios.Sum(funcionario => funcionario.Salario)
    })
    .ToList();

    Console.WriteLine("----------------------------- Execercicio 3 -----------------------------");

    foreach (var departamento in departamentos)
    {
        var funcionariosString = new StringBuilder("");
        foreach (var funcionario in departamento.Funcionarios)
        {
            funcionariosString.AppendLine($"\t\tNome:{funcionario.Nome} Contratação:{funcionario.DataContratacao.ToString("dd/MM/yyyy")}");
        }

        Console.WriteLine($"\nDepartamento:\n\tNome:{departamento.Nome}\n\tValor Salário Gasto:{departamento.ValorTotalSalario:C}\n\tFuncionarios:\n{funcionariosString}");
    }


}

void Exercicio5(AppDbContext context)
{

    var funcionarios = context.Funcionarios
        .Include(funcionario => funcionario.FuncionariosProjetos)
            .ThenInclude(funcionarioProjeto => funcionarioProjeto.Projeto)
                 .ThenInclude(projeto => projeto.Cliente)
        .Select(funcionario => new {
            NomeFuncionario = funcionario.Nome,
            Projetos = funcionario.FuncionariosProjetos.Select(fp => new
            {
                NomeProjeto = fp.Projeto.Nome,
                NomeCliente = fp.Projeto.Cliente.Nome
            })
        })
        .ToList();


    foreach(var funcionario in funcionarios)
    {
        var projetos = new StringBuilder("");

        foreach(var projeto in funcionario.Projetos)
        {
            projetos.AppendLine($"\t\tProjeto:{projeto.NomeProjeto}\n\t\tCiente:{projeto.NomeCliente}\n");
        }

        Console.WriteLine($"\nFuncionario:\n\tNome:{funcionario.NomeFuncionario}\n\tProjetos:\n{projetos}");
    }

    Console.WriteLine("----------------------------- Execercicio 5 -----------------------------");
}

void Exercicio6(AppDbContext context)
{
    var funcionario = context.Funcionarios.FirstOrDefault(f => f.Id == 19);


    context.Entry(funcionario)
           .Reference(f => f.Departamento)
           .Load();

    context.Entry(funcionario)
          .Reference(f => f.FuncionarioDetalhe)
          .Load();

    context.Entry(funcionario)
          .Collection(f => f.FuncionariosProjetos)
          .Query()
          .Include(fp => fp.Projeto)
          .Load();

    Console.WriteLine($"Funcionário: {funcionario.Nome}");
    Console.WriteLine($"Departamento: {funcionario.Departamento?.Nome}");
    Console.WriteLine($"Endereço Residencial: {funcionario.FuncionarioDetalhe?.EnderecoResidencial}");
    Console.WriteLine("Projetos:");

    foreach (var projeto in funcionario.FuncionariosProjetos)
    {
        Console.WriteLine($"\tProjeto: {projeto.Projeto.Nome}, Horas Trabalhadas: {projeto.HorasTrabalhadas}");
    }

    Console.WriteLine("----------------------------- Execercicio 6 -----------------------------");
}


void MudancasEstado(AppDbContext context)
{
    // 1. Criando uma nova entidade
    var novoCliente = new Cliente
    {
        Nome = "João Silva",
        Email = "joao@email.com",
        Telefone = "99999-9999",
        Ativo = true
    };

    Console.WriteLine($"Estado Inicial: {context.Entry(novoCliente).State}");

    // 2. Adicionando a entidade
    context.Clientes.Add(novoCliente); // Estado: Added
    Console.WriteLine($"Estado antes de SaveChanges(): {context.Entry(novoCliente).State}");

    // 3. Chamando SaveChanges
    context.SaveChanges(); // Salva no banco
    Console.WriteLine($"Estado após SaveChanges(): {context.Entry(novoCliente).State}");

    // 4. Modificando a entidade
    novoCliente.Nome = "João da Silva"; // Estado: Modified
    Console.WriteLine($"Estado após modificação: {context.Entry(novoCliente).State}");

}

void MudancasEstadoDesconectado()
{
    // 1. Criando a entidade
    var novoCliente = new Cliente
    {
        Nome = "Maria Souza",
        Email = "maria@email.com",
        Telefone = "98888-7777",
        Ativo = true
    };

    // 2. Primeiro contexto - INSERT
    using (var context = new AppDbContext())
    {
        context.Clientes.Add(novoCliente);
        Console.WriteLine($"Estado antes de SaveChanges(): {context.Entry(novoCliente).State}");

        context.SaveChanges();
        Console.WriteLine($"Estado após SaveChanges(): {context.Entry(novoCliente).State}");
    }

    // 3. Alterando fora do contexto
    novoCliente.Nome = "Maria da Silva";

    // 4. Segundo contexto - UPDATE (entidade desconectada)
    using (var context = new AppDbContext())
    {
        context.Entry(novoCliente).State = EntityState.Modified;
        Console.WriteLine($"Estado ao anexar e modificar: {context.Entry(novoCliente).State}");

        context.SaveChanges();
        Console.WriteLine($"Estado após SaveChanges(): {context.Entry(novoCliente).State}");
    }

    // 5. Terceiro contexto - DELETE (ou soft delete)
    using (var context = new AppDbContext())
    {
        // HARD DELETE
        context.Entry(novoCliente).State = EntityState.Deleted;

        // SOFT DELETE (alternativa)
        // novoCliente.Ativo = false;
        // context.Entry(novoCliente).State = EntityState.Modified;

        Console.WriteLine($"Estado ao anexar e marcar como Deleted: {context.Entry(novoCliente).State}");

        context.SaveChanges();
        Console.WriteLine($"Estado após exclusão: {context.Entry(novoCliente).State}");
    }

}

void Execute(AppDbContext context)
{

    Console.WriteLine("Execute UPDATE");

    context.Funcionarios
        .Where(f => f.Departamento!.Nome == "TI" && f.Cargo == "programador junior")
        .ExecuteUpdate(s => s
        .SetProperty(b => b.Cargo, "Progamador Pleno")
        .SetProperty(b => b.Salario, b => b.Salario * 1.15m));

    Console.WriteLine("Execute DELETE");

    context.Funcionarios.Where(f => f.DepartamentoId == 2)
           .ExecuteDelete();

}

void Migrations()
{
 
 // dotnet ef migrations add IncluiFuncionarioEDetalhe --project GaSoft.EFCore --startup-project GaSoft.Console

 // dotnet ef database update --project GaSoft.EFCore --startup-project GaSoft.Console

 // --verbose -> debug
}

void Scaffold() {
   //gerar entidades atraves do banco de dados

   //dotnet ef dbcontext scaffold "Server=localhost\SQLEXPRESS;Database=gasoftdatabase2;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o MinhasEntidades -c MeuArquivoContext -p GaSoft.EFCore
}

void MigrationsProducao(){
    //utilizar dotnet ef migrations script --idempotent --output migrations-prod.sql --project GaSoft.EFCore -context AppDbContext
    //vai gerarl um script sql e não ser necessário passar permissões de servidor
}

void OnDeleteComportamentos() {

//Cascade

//Ao excluir a entidade principal, as entidades dependentes também são excluídas automaticamente.
//(É o padrão quando a FK não é nula, int por exemplo)

//Restrict

//Impede a exclusão da entidade principal se houver dependentes relacionados. Deve-se excluir os dependentes manualmente primeiro.

//SetNull

//Ao excluir a entidade principal, a chave estrangeira dos dependentes é definida como null (somente se a FK permitir null).
//(É o padrão quando a FK é nula (int?))

//NoAction

//Sem ação no banco de dados. O EF Core não faz nada automaticamente. O comportamento depende da configuração do banco de dados.

//ClientSetNull

//Semelhante ao SetNull, mas o EF Core define a FK como null apenas no cliente (em memória). O banco de dados não aplica a lógica.
    
}

*/

void fromSqlRaw(AppDbContext context)
{
    var departamentoId = 1;

    var funcionarios = context.Funcionarios
                       .FromSqlRaw("SELECT * FROM Funcionarios WHERE DepartamentoId = {0}", departamentoId)
                       .Include(f => f.Departamento)
                       .ToList();
}

void fromSql(AppDbContext context)
{
    var departamentoId = 1;

    var funcionarios = context.Funcionarios
                       .FromSql($"SELECT * FROM Funcionarios WHERE DepartamentoId = {departamentoId}")
                       .Include(f => f.Departamento)
                       .ToList();
}

async Task sqlQuery(AppDbContext context)
{
    var funcionarios = context.Database
                       .SqlQuery<FuncionarioSalarioDTO>
                       ($@"
                            SELECT f.Nome, f.Salario, f.Cargo, d.Nome as Departamento
                            FROM Funcionarios f
                            INNER JOIN Departamentos d ON f.DepartamentoId = d.DepartamentoId
                            ORDER BY f.Salario DESC
                       ").ToList();

    var departamentoId = 3;

    var total = await context.Database
                      .SqlQuery<decimal?>(
                       $"SELECT SUM(Salario) As Value FROM Funcionarios WHERE DepartamentoId = {departamentoId}"
                       )
                      .FirstOrDefaultAsync();
}


async Task storedProcedure(AppDbContext context)
{
    //CREATE PROCEDURE usp_ListarFuncionariosPorDepartamentos
    //    @DepartamentoId INT
    //AS
    //BEGIN
    //    SELECT Nome, Cargo, Salario
    //    FROM Funcionarios
    //    WHERE DepartamentoId = DepartamentoId
    //END

    var departamentoId = 2;
    var resultado = await context.Database
                     .SqlQuery<FuncionarioDTO>(
                      $"EXEC usp_ListarFuncionariosPorDepartamento {departamentoId}"
                      ).ToListAsync();
}

async Task storedProcedureAlterada(AppDbContext context)
{
    //ALTER PROCEDURE usp_ListarFuncionariosPorDepartamentos
    //    @DepartamentoId INT
    //AS
    //BEGIN
    //    SELECT Id, Nome, Cargo, Salario, DataContratacao, DepartamentoId
    //    FROM Funcionarios
    //    WHERE DepartamentoId = DepartamentoId
    //END

    var departamentoId = 2;

    var resultado = await context.Funcionarios
        .FromSqlRaw("EXEC usp_ListarFuncionariosPorDepartamento {0}", departamentoId)
        .ToListAsync();

    var resultado2 = await context.Funcionarios
        .FromSqlRaw("EXEC usp_ListarFuncionariosPorDepartamento @DepartamentoId",
        new SqlParameter("@DepartamentoId", departamentoId)) //MAIS SEGURO
        .ToListAsync();

    var resultado3 = await context.Funcionarios
        .FromSql($"EXEC usp_ListarFuncionariosPorDepartamento {departamentoId}")
        .ToListAsync();
}

async Task storedProcedureMigrations(AppDbContext context)
{
    /*
     * Fazer primeiro no banco de dados e testar para depois aplicar em migrations
     * 
       CREATE PROCEDURE usp_FuncionariosContratadosPorPeriodo
           @DataInicio DATE,
           @DataFim DATE
       AS
       BEGIN
           SELECT f.FuncionarioId,f.Nome,f.Cargo,f.Salario,f.DataContratacao,f.DepartamentoId
           FROM Funcionarios f
           WHERE f.DataContratacao BETWEEN @DataInicio AND @DataFim
           ORDER BY f.DataContratacao;
       END;

       depois de criada a migration:

       dotnet ef database update Cria_SP_FuncisContratadosPorPeriodo -p GaSoft.EFCore -c AppDbContext
    */

    //não precisa usar EXEC
    var dataInicio = new DateOnly(2023, 01, 01);
    var dataFim = new DateOnly(2023, 12, 31);

    //FromSqlRaw
    var funcionarios1 = await context.Funcionarios
        .FromSqlRaw("usp_FuncionariosContratadosPorPeriodo {0}, {1}",dataInicio, dataFim)
        .ToListAsync();

    //FromSqlRaw com com sqlParameter
    var parametros = new[]
    {
        new SqlParameter("@DataInicio",dataInicio),
        new SqlParameter("@DataFim",dataFim)
    };

    var funcionarios2 = await context.Funcionarios
        .FromSqlRaw("usp_FuncionariosContratadosPorPeriodo @DataInicio @DataFim",parametros)
        .ToListAsync();

    //FromSql
    var funcionarios3 = await context.Funcionarios
        .FromSql($"usp_FuncionariosContratadosPorPeriodo {dataInicio}, {dataFim}")
        .ToListAsync();

}

public record FuncionarioSalarioDTO(
  string Nome,
  decimal Salario,
  string Cargo,
  string Departamento
);

public record FuncionarioDTO (
    string Nome,
    decimal Salario,
    string Cargo
);