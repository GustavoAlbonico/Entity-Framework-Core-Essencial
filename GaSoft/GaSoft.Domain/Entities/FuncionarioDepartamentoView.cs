using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaSoft.Domain.Entities;

public class FuncionarioDepartamentoView
{
    public int FuncionarioId { get; set; }
    public string? NomeFuncionario { get; set; }
    public string? Cargo { get; set; }
    public decimal Salario { get; set; }
    public DateOnly DataContratacao { get; set; }
    public int DepartamentoId { get; set; }
    public string? NomeDepartamento { get; set; }
    public string? DescricaoDepartamento { get; set; }
}
