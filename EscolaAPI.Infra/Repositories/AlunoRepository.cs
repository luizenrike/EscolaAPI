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
    public class AlunoRepository : BaseRepository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(EscolaContext database) : base(database)
        {

        }

        public new List<Aluno> GetAll()
        {
            return Database.Alunos.Include(a => a.Turma).ToList();
        }

    }
}
