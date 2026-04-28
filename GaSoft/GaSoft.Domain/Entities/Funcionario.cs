using System.Text;

namespace GaSoft.Domain.Entities;

public  class Funcionario
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Cargo { get; set; }
    public decimal Salario { get; set; }
    public DateOnly DataContratacao { get; set; }
    public int DepartamentoId { get; set; }
    public Departamento? Departamento { get; set; }
    public FuncionarioDetalhe? FuncionarioDetalhe { get; set; }

    public ICollection<Projeto> Projetos { get; set; } = new List<Projeto>(); //forma 1 de juncao

    //public ICollection<FuncionarioProjeto> FuncionariosProjetos { get; set; } = new List<FuncionarioProjeto>();

}
