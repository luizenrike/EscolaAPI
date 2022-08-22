using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaAPI.Domain.Models
{
    public class Disciplina : EntidadeBase
    {
        public string Nome { get; set; }
        public List<Turma> ListaTurmas { get; set; }
    }
}
