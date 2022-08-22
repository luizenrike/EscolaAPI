using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaAPI.Domain.Models
{
    public class Aluno : EntidadeBase
    {
        public string Nome { get; set; }
        public int TurmaId { get; set; }
        public string Email { get; set; }
        public Turma Turma { get; set; }
    }
}
