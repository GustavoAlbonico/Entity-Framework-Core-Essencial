using System;
using System.Collections.Generic;

namespace GaSoft.EFCore.MinhasEntidades;

public partial class Funcionario
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Cargo { get; set; } = null!;

    public decimal Salario { get; set; }

    public DateOnly DataContratacao { get; set; }

    public int DepartamentoId { get; set; }

    public virtual Departamento Departamento { get; set; } = null!;

    public virtual FuncionarioDetalhe? FuncionarioDetalhe { get; set; }

    public virtual ICollection<FuncionariosProjeto> FuncionariosProjetos { get; set; } = new List<FuncionariosProjeto>();
}
