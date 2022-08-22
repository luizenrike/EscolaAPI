using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaAPI.Domain.Models
{
    public class Turma : EntidadeBase
    {
        public string Nome { get; set; }
        public int DisciplinaID { get; set; }
        public int ProfessorID { get; set; }


        public Disciplina Disciplina { get; set; }
        public Professor Professor { get; set; }

        public List<Aluno> Alunos { get; set; }
    }
}
