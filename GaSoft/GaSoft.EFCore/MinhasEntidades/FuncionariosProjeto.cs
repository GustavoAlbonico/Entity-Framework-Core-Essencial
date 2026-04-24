using System;
using System.Collections.Generic;

namespace GaSoft.EFCore.MinhasEntidades;

public partial class FuncionariosProjeto
{
    public int FuncionarioId { get; set; }

    public int ProjetoId { get; set; }

    public int HorasTrabalhadas { get; set; }

    public virtual Funcionario Funcionario { get; set; } = null!;

    public virtual Projeto Projeto { get; set; } = null!;
}
