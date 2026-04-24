using System;
using System.Collections.Generic;

namespace GaSoft.EFCore.MinhasEntidades;

public partial class Projeto
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public decimal Orcamento { get; set; }

    public DateTime DataInicio { get; set; }

    public DateTime DataAtualizacao { get; set; }

    public DateTime DataFim { get; set; }

    public int Status { get; set; }

    public int ClienteId { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ICollection<FuncionariosProjeto> FuncionariosProjetos { get; set; } = new List<FuncionariosProjeto>();
}
