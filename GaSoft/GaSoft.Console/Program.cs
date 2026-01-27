
using GaSoft.Domain.Entities;
using GaSoft.EFCore.Context;

using (AppDbContext context = new AppDbContext())
{
    context.Database.EnsureDeleted();
    Console.WriteLine("Criando o banco de dados... \n");
    context.Database.EnsureCreated();

    Console.WriteLine("Criando um departamento...\n");
    //CriarDepartamento(context);
    Console.WriteLine("Departamento criado...\n");

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

