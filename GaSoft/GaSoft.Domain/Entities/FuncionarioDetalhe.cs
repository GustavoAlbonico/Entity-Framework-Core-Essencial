using GaSoft.Domain.Entities.Enum;

namespace GaSoft.Domain.Entities;

public class FuncionarioDetalhe
{
    public int Id { get; set; }
    public string? EnderecoResidencial { get; set; }
    public DateTime DataNascimento { get; set; }
    public string? Celular {  get; set; }
    public Genero? Genero { get; set; }
    public string? Foto { get; set; }
    public EstadoCivil? EstadoCivil { get; set; }
    public string? CPF { get; set; }
    public string? Nacionalidade { get; set; }
    public Escolaridade? Escolaridade { get; set; }
    public int FuncionarioId { get; set; }
    public Funcionario? Funcionario { get; set; }
}
