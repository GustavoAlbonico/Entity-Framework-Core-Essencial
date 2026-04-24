using System;
using System.Collections.Generic;

namespace GaSoft.EFCore.MinhasEntidades;

public partial class FuncionarioDetalhe
{
    public int Id { get; set; }

    public string EnderecoResidencial { get; set; } = null!;

    public DateTime DataNascimento { get; set; }

    public string Celular { get; set; } = null!;

    public int Genero { get; set; }

    public string Foto { get; set; } = null!;

    public int EstadoCivil { get; set; }

    public string Cpf { get; set; } = null!;

    public string Nacionalidade { get; set; } = null!;

    public int Escolaridade { get; set; }

    public int FuncionarioId { get; set; }

    public virtual Funcionario Funcionario { get; set; } = null!;
}
