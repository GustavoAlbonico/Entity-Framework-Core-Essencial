namespace GaSoft.Domain.Entities;

public  class Funcionario
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Cargo { get; set; }
    public decimal Salario { get; set; }
    public DateOnly DataContratacao { get; set; }
    public int DepartamentoId { get; set; }
    public virtual Departamento? Departamento { get; set; }
    public virtual FuncionarioDetalhe? FuncionarioDetalhe { get; set; }

    public virtual ICollection<FuncionarioProjeto> FuncionariosProjetos { get; set; } = new List<FuncionarioProjeto>(); 
}
