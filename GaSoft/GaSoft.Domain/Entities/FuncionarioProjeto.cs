namespace GaSoft.Domain.Entities;

public class FuncionarioProjeto
{
    public int FuncionarioId { get; set; }
    public Funcionario? Funcionario { get; set; }

    public int ProjetoId { get; set; }
    public Projeto? Projeto { get; set; }

    public int HorasTrabalhadas { get; set; }
}
