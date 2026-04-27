using GaSoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GaSoft.EFCore.Configurations;

public class DepartamentoConfiguration:IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> entity)
    {
        entity.Property(e => e.Nome)
              .HasMaxLength(100)
              .IsRequired();

        entity.Property(e => e.Descricao)
              .HasMaxLength(200)
              .IsRequired();

        entity.HasData(
              new Departamento { Id = 1, Nome = "Financeiro", Descricao = "Gestão das finanças" },
              new Departamento { Id = 2, Nome = "Marketing", Descricao = "Promoção de produtos" },
              new Departamento { Id = 3, Nome = "RH", Descricao = "Recursos Humanos" },
              new Departamento { Id = 4, Nome = "Suporte", Descricao = "Atendimento ao cliente" },
              new Departamento { Id = 5, Nome = "TI", Descricao = "Tecnologia da Informação" },
              new Departamento { Id = 6, Nome = "Vendas", Descricao = "Gestão de Vendas" }
        );
    }
}
