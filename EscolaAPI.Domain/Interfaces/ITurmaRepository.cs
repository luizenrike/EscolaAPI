using EscolaAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaAPI.Domain.Interfaces
{
    public interface ITurmaRepository : IBaseRepository <Turma>
    {
        Turma GetByName(string nome);
        new Turma GetById(int Id);

    }
}
