using GaSoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GaSoft.EFCore.Context;

public class AppDbContext : DbContext
{
    public DbSet<Departamento> Departamento { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(AppConfig.GetConnectionString());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
