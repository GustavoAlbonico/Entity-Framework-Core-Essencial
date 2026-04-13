using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2.Domain.Entities;

public class Professor
{
    public int Id { get; set; }
    public string? Nome { get; set; }

    public Curso? Curso { get; set; }
}
