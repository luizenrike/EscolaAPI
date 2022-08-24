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
    public class TurmaRepository : BaseRepository<Turma>, ITurmaRepository
    {
        public TurmaRepository(EscolaContext database) : base(database)
        {

        }

        public Turma GetByName(string Nome)
        {
            return Database.Turmas.Where(t => t.Nome.ToLower() == Nome.ToLower()).FirstOrDefault();
        }

        public new Turma GetById(int Id)
        {
            return Database.Turmas
                .Include(t => t.Alunos)
                .Include(t => t.Disciplina)
                .Include(t => t.Professor)
                .Where(t => t.Id == Id).FirstOrDefault();
        }
    }
}
