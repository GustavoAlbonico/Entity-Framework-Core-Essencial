using Ex2.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2.EFCore.Context;

public class AppDbContext : DbContext
{
    public DbSet<Livro> Livors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(AppConfig.GetConnectionString())
                      .UseSnakeCaseNamingConvention()
                      .LogTo(Console.WriteLine,
                        new[] { DbLoggerCategory.Database.Command.Name },
                        Microsoft.Extensions.Logging.LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Livro>(entity =>
        {



        });

    }
}
