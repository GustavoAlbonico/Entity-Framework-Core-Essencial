
using GaSoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GaSoft.EFCore.Configurations;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> entity)
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

        entity.HasIndex(e => e.Nome);

        entity.HasIndex(e => e.Email)
              .IsUnique();

        entity.HasQueryFilter(e => e.Ativo);


        entity.HasData(
              new Cliente { Id = 1, Nome = "Grupo ABroad SA", Email = "abroad@email.com", Telefone = "55-11 9980-0099", Ativo = true },
              new Cliente { Id = 2, Nome = "Construtora ABC", Email = "abcconstru@email.com", Telefone = "55-31 8957-1022", Ativo = true },
              new Cliente { Id = 3, Nome = "EduFuture Corp.", Email = "edufuture@email.com", Telefone = "55-11 8750-4422", Ativo = true },
              new Cliente { Id = 4, Nome = "Tech Innovators Ltda", Email = "innovators@email.com", Telefone = "55-11 9950-9622", Ativo = true },
              new Cliente { Id = 5, Nome = "Health Solutions Inc.", Email = "healtsolutions@email.com", Telefone = "55-21 9852-9655", Ativo = false }
        );

    }
}
