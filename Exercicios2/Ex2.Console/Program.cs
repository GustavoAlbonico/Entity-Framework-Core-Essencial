using Ex2.Domain.Entities;
using Ex2.Domain.Entities.Enum;
using Ex2.EFCore.Context;
using Microsoft.EntityFrameworkCore;

using AppDbContext _context = new AppDbContext();

_context.Database.EnsureDeleted();
Console.WriteLine("Criando banco de dados....\n\n");
_context.Database.EnsureCreated();

getLivros(_context);
getLivrosAdmin(_context);
putLivroStatus(_context, 6, Status.Emprestado);
getLivro(_context, 6);
deleteLivro(_context, 6);
getLivro(_context, 6);
getLivros(_context);

Console.ReadKey();

void getLivros(AppDbContext context)
{
    var livros = context.Livros.ToList();

    Console.WriteLine("\n---------USUARIO----------\n");

    foreach (var livro in livros)
    {
        Console.WriteLine($"Titulo:{livro.Titulo} Data:{livro.DataPublicacao:dd/MM/yyyy} Status: {livro.Status} SoftDelete:{livro.IsDeleted}");
    }
}

void getLivro(AppDbContext context,int id)
{
    var livro = context.Livros.Find(id);

    if (livro is not null)
    {
        Console.WriteLine($"Titulo:{livro.Titulo} Data:{livro.DataPublicacao:dd/MM/yyyy} Status: {livro.Status} SoftDelete:{livro.IsDeleted}");
    }
        else
    {
        Console.WriteLine("Livro não encontrado!");
    }
}

void getLivrosAdmin(AppDbContext context)
{
    var livros = context.Livros.IgnoreQueryFilters().ToList();

    Console.WriteLine("\n---------ADMIN----------\n");

    foreach (var livro in livros)
    {
        Console.WriteLine($"Titulo:{livro.Titulo} Data:{livro.DataPublicacao:dd/MM/yyyy} Status: {livro.Status} SoftDelete:{livro.IsDeleted}");
    }
}

void putLivroStatus(AppDbContext context,int id, Status status)
{
    Console.WriteLine("\nAlterando Status...\n");

    var livro = context.Livros.Find(id);

    if (livro is not null)
    {
        livro.Status = status;

        context.Update(livro);
        context.SaveChanges();
        Console.WriteLine("\nStatus Alterado\n");
    }
    else
    {
        Console.WriteLine("Livro não encontrado!");
    }
}

void deleteLivro(AppDbContext context, int id)
{
    Console.WriteLine("\n Soft Delete...\n");
    var livro = context.Livros.Find(id);

    if(livro is not null)
    {
        livro.IsDeleted = true;
        context.Update(livro);
        context.SaveChanges();

        Console.WriteLine("\n Soft Delete Concluido\n");
    } else
    {
        Console.WriteLine("Livro não encontrado!");
    }
}