using GaSoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaSoft.EFCore.Configurations;

public class FuncionarioDepartamentoViewConfiguration : IEntityTypeConfiguration<FuncionarioDepartamentoView>
{
    public void Configure(EntityTypeBuilder<FuncionarioDepartamentoView> entity)
    {
        entity.HasNoKey();

        entity.ToView("view_FuncionariosDepartamentos");

        entity.Property(e => e.NomeFuncionario).HasMaxLength(100);
        entity.Property(e => e.Cargo).HasMaxLength(50);
        entity.Property(e => e.NomeDepartamento).HasMaxLength(100);
        entity.Property(e => e.DescricaoDepartamento).HasMaxLength(250); 
    }
}
