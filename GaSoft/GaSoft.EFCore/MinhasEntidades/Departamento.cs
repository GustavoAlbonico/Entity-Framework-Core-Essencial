using System;
using System.Collections.Generic;

namespace GaSoft.EFCore.MinhasEntidades;

public partial class Departamento
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public virtual ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
}
