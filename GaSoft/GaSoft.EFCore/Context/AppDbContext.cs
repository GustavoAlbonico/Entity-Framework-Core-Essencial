using GaSoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GaSoft.EFCore.Context;

internal class AppDbContext : DbContext
{
    public DbSet<Departamento> Departamento { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(AppConfig.GetConnectionString());
    }
}
