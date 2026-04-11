using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2.Domain.Entities;

public class Curso
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public List<Aluno> Alunos { get; set; } = new List<Aluno>();
    public Professor? Coordenador { get; set; }
    public int? CoordenadorId { get; set; }
}
