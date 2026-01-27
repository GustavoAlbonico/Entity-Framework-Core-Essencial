namespace GaSoft.Domain.Entities;

public class FuncionarioDetalhe
{
    public int Id { get; set; }
    public string? EnderecoResidencial { get; set; }
    public DateTime DataNascimento { get; set; }
    public string? Celular {  get; set; }
    public string? Genero { get; set; }
    public string? Foto { get; set; }
    public string? EstadoCivil { get; set; }
    public string? CPF { get; set; }
    public string? Nacionalidade { get; set; }
    public string? Escolaridade { get; set; }
    public int FuncionarioId { get; set; }
    public Funcionario? Funcionario { get; set; }
}
