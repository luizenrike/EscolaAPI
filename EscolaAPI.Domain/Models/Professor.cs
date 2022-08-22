using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaAPI.Domain.Models
{
    public class Professor : EntidadeBase
    {
        public string Nome { get; set; }
        public Turma Turma { get; set; }
    }
}
