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
    public class ProfessorRepository : BaseRepository<Professor>, IProfessorRepository
    {
        public ProfessorRepository(EscolaContext database) : base(database)
        {

        }

        public Professor GetByName(string Nome)
        {
            return Database.Professores.Include(p => p.Turma).Where(p => p.Nome.ToLower() == Nome.ToLower()).FirstOrDefault();
        }

        public new Professor GetById(int Id)
        {
            return Database.Professores.Include(p => p.Turma).Where(p => p.Id == Id).FirstOrDefault();
        }
    }
}
