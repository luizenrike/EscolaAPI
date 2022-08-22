using AutoMapper;
using EscolaAPI.Application.DTOs;
using EscolaAPI.Domain.Interfaces;
using EscolaAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaAPI.Application.Services
{
    public class ProfessorService
    {
        public ProfessorService(IProfessorRepository repositorio, ITurmaRepository repositorioturma, IMapper mapper)
        {
            _Repositorio = repositorio;
            _RepositorioTurma = repositorioturma;
            _Mapper = mapper;
        }

        private readonly IProfessorRepository _Repositorio;
        private readonly ITurmaRepository _RepositorioTurma;
        private readonly IMapper _Mapper;

        public List<ProfessorBasicoDTO> GetAll()
        {
            List<Professor> Professores = _Repositorio.GetAll();
            List<ProfessorBasicoDTO> Retorno = _Mapper.Map<List<ProfessorBasicoDTO>>(Professores);
            return Retorno;
        }

        public ProfessorDTO GetByName(string Nome)
        {
            Professor prof = _Repositorio.GetByName(Nome);
            ProfessorDTO Retorno = _Mapper.Map<ProfessorDTO>(prof);

            return Retorno;
        }

        public ProfessorDTO GetById(int Id)
        {
            Professor prof = _Repositorio.GetById(Id);
            ProfessorDTO Retorno = _Mapper.Map<ProfessorDTO>(prof);

            return Retorno;
        }

        public void PostProfessor(CriarProfessorDTO InfoProfessor)
        {
            Professor NovoProfessor = new Professor();
            NovoProfessor.Nome = InfoProfessor.Nome;
            _Repositorio.Insert(NovoProfessor);
        }

        public void PutProfessor(CriarProfessorDTO InfoProfessor, int Id)
        {
            Professor Att = _Repositorio.GetById(Id);
            if(Att != null)
            {
                Att.Nome = InfoProfessor.Nome;
                _Repositorio.Update(Att);
            }
        }

        public void DeleteProfessor(int Id)
        {
            Professor Remove = _Repositorio.GetById(Id);
            if (Remove != null)
                _Repositorio.Delete(Remove);
        }
    }
}
