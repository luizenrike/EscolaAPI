using EscolaAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaAPI.Domain.Interfaces
{
    public interface IDisciplinaRepository : IBaseRepository<Disciplina>
    {
        Disciplina GetByName(string nome);
        new Disciplina GetById(int Id);

    }
}
