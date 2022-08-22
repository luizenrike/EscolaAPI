using AutoMapper;
using EscolaAPI.Application.DTOs;
using EscolaAPI.Domain.Interfaces;
using EscolaAPI.Domain.Models;
using EscolaAPI.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaAPI.Application.Services
{
    public class AlunoService
    {
        public AlunoService(IAlunoRepository repositorio, ITurmaRepository repositorioturma, IMapper mapper)
        {
            _Repositorio = repositorio;
            _RepositorioTurma = repositorioturma;
            _Mapper = mapper;
        }
        private readonly IAlunoRepository _Repositorio;
        private readonly ITurmaRepository _RepositorioTurma;
        private readonly IMapper _Mapper;
        public List<AlunoBasicoDTO> GetAll()
        {
            List<Aluno> Alunos = _Repositorio.GetAll();
            List<AlunoBasicoDTO> Retorno = _Mapper.Map<List<AlunoBasicoDTO>>(Alunos);
            return Retorno;
        }

        public Aluno GetById(int Id)
        {
            return _Repositorio.GetById(Id);
        }

        public void PostAluno(CriarAlunoDTO InfoAluno)
        {
            Turma turma = _RepositorioTurma.GetByName(InfoAluno.Turma);
            Aluno NovoAluno = new Aluno();
            if(turma != null)
            {
                NovoAluno.Nome = InfoAluno.Nome;
                NovoAluno.Turma = turma;
                NovoAluno.Email = InfoAluno.Email;
                NovoAluno.TurmaId = turma.Id;
                _Repositorio.Insert(NovoAluno);
            }
        }

        public void PutAluno(CriarAlunoDTO InfoAluno, int Id)
        {
            Aluno Att = _Repositorio.GetById(Id);
            Turma turma = _RepositorioTurma.GetByName(InfoAluno.Turma);

            if (Att == null || turma == null)
                return;

            Att.Nome = InfoAluno.Nome;
            Att.Turma = turma;
            Att.Email = InfoAluno.Email;

            _Repositorio.Update(Att);
        }

        public void DeleteAluno(int Id)
        {
            Aluno Remove = _Repositorio.GetById(Id);
            if (Remove != null)
                _Repositorio.Delete(Remove);
        }
    }
}
