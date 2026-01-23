
using GaSoft.Domain.Entities;
using GaSoft.EFCore.Context;

using (AppDbContext context = new AppDbContext())
{
    context.Database.EnsureDeleted();
    Console.WriteLine("Criando o banco de dados... \n");
    context.Database.EnsureCreated();

    Console.WriteLine("Criando um departamento...\n");
    CriarDepartamento(context);
    Console.WriteLine("Departamento criado...\n");
}

Console.ReadKey();

void CriarDepartamento(AppDbContext context)
{
    var departamento = new Departamento
    {
        Nome = "Desenvolvimento",
        Descricao = "Desenvolvimento de projetos"
    };

    context.Departamento.Add(departamento);
    context.SaveChanges();
}

