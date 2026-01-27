using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
