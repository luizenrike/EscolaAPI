using EscolaAPI.Domain.Interfaces;
using EscolaAPI.Domain.Models;
using EscolaAPI.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaAPI.Infra.Repositories
{
    public class DisciplinaRepository : BaseRepository<Disciplina>, IDisciplinaRepository
    {
        public DisciplinaRepository(EscolaContext database) : base(database)
        {

        }

        public Disciplina GetByName(string Nome)
        {
            return Database.Disciplinas.Where(d => d.Nome.ToLower() == Nome.ToLower()).FirstOrDefault();
        }

        public new Disciplina GetById(int Id)
        {
            return Database.Disciplinas
                .Include(d => d.ListaTurmas)
                .ThenInclude(t => t.Professor)
                .Where(d => d.Id == Id).FirstOrDefault();    
        }
    }
}
