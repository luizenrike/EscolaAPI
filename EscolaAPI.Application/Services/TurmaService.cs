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
    public class TurmaService
    {
        public TurmaService(ITurmaRepository repositorio, IMapper mapper, IDisciplinaRepository repositoriodisciplina, IProfessorRepository repositorioprofessor)
        {
            _Repositorio = repositorio;
            _Mapper = mapper;
            _RepositorioDisciplina = repositoriodisciplina;
            _RepositorioProfessor = repositorioprofessor;
        }
        private readonly ITurmaRepository _Repositorio;
        private readonly IDisciplinaRepository _RepositorioDisciplina;
        private readonly IProfessorRepository _RepositorioProfessor;
        private readonly IMapper _Mapper;

        public List<TurmaBasicaDTO> GetAll()
        {
            List<Turma> Turmas = _Repositorio.GetAll();
            List<TurmaBasicaDTO> Retorno = _Mapper.Map<List<TurmaBasicaDTO>>(Turmas);
            return Retorno;
            //return _Repositorio.GetAll();
        }

        public TurmaDTO GetById(int Id)
        {
            Turma Turma = _Repositorio.GetById(Id);
            TurmaDTO DTO = _Mapper.Map<TurmaDTO>(Turma);


            return DTO;
        }

        public void PostTurma(CriarTurmaDTO InfoTurma)
        {
            Turma NovaTurma = new Turma();
            Disciplina Disc = _RepositorioDisciplina.GetByName(InfoTurma.Disciplina);
            Professor Prof = _RepositorioProfessor.GetByName(InfoTurma.Professor);

            if (Disc == null || Prof == null)
                return;

            NovaTurma.Nome = InfoTurma.Nome;
            NovaTurma.Professor = Prof;
            NovaTurma.Disciplina = Disc;
            NovaTurma.ProfessorID = Prof.Id;
            NovaTurma.DisciplinaID = Disc.Id;

            _Repositorio.Insert(NovaTurma);
        }

        public void PutTurma(CriarTurmaDTO InfoTurma, int Id)
        {
            Turma Att = _Repositorio.GetById(Id);
            Disciplina Disc = _RepositorioDisciplina.GetByName(InfoTurma.Disciplina);
            Professor Prof = _RepositorioProfessor.GetByName(InfoTurma.Professor);

            if (Att == null || Disc == null || Prof == null)
                return;

            Att.Nome = InfoTurma.Nome;
            Att.Professor = Prof;
            Att.Disciplina = Disc;
            _Repositorio.Update(Att);

        }

        public void DeleteTurma(int Id)
        {
            Turma Remove = _Repositorio.GetById(Id);    
            if(Remove != null)
                _Repositorio.Delete(Remove);
            
        }
    }
}
