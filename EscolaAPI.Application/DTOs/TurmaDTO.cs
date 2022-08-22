using EscolaAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaAPI.Application.DTOs
{
    public class TurmaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Professor { get; set; }
        public string Disciplina { get; set; }
        public List<AlunoDTO> ListaAlunos { get; set; }
    }
}
