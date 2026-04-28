using GaSoft.Domain.Entities.Enum;
using System.Globalization;

namespace GaSoft.Domain.Entities;

public class Projeto
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public decimal Orcamento { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public DateTime DataFim {  get; set; }

    public StatusProjeto Status {  get; set; }
    //public ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>(); //forma 1 e 2 de juncao

    public ICollection<FuncionarioProjeto> FuncionariosProjetos { get; set; } = new List<FuncionarioProjeto>(); //forma 3

    public int ClienteId { get; set; }
    public Cliente? Cliente { get; set; }
}
