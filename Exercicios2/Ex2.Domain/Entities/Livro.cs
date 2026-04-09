using Ex2.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2.Domain.Entities;

public class Livro
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime DataPublicacao { get; set; }
    
    public Status Status { get; set; }

}
