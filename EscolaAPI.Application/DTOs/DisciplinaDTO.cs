using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaAPI.Application.DTOs
{
    public class DisciplinaDTO
    {
        public string Nome { get; set; }
        public List<TurmaDTO> ListaTurmas { get; set; }
    }
}
