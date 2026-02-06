namespace GaSoft.Domain.Entities;

public class Cliente
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? Telefone { get; set; }

    //soft delete
    public bool Ativo {  get; set; }
    public ICollection<Projeto> Projetos { get; set; } = new List<Projeto>();
}
