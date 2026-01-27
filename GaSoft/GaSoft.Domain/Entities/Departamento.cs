using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaSoft.Domain.Entities;

//[Table("Setores",Schema = "gasoft")]
public class Departamento
{

    //[DatabaseGenerated(DatabaseGeneratedOption.None)] //faz n gerar id automaticamente
    public long Id { get; set; }

    //[Column("Nome_Departamento")]
    //[MaxLength(100)]
    //[Column(TypeName = "nvarchar(100)")]
    public string? Nome { get; set; }

    //[Column(TypeName = "varchar(200)")]
    //[Required]
    public string? Descricao { get; set; }

    public ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();

    //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    //public DateTime dataCriacao { get; set; }


    //(string?) -> as colunas na tabela vão permitir valores NULL
    //(string.Empty) -> as colunas na tabela são criadas como NOT NULL
    //usar um cronstrutor para inicializar as propriedades -> as colunas na tabela são criadas como NOT NULL
}
