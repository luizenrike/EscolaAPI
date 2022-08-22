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
    public class DisciplinaService
    {
        public DisciplinaService(IDisciplinaRepository repositorio, IMapper mapper)
        {
            _Repositorio = repositorio;
            _Mapper = mapper;
        }
        private readonly IDisciplinaRepository _Repositorio;
        private readonly IMapper _Mapper;

        public List<DisciplinaBasicaDTO> GetAll()
        {
            List<Disciplina> Disciplinas = _Repositorio.GetAll();
            List<DisciplinaBasicaDTO> Retorno = _Mapper.Map<List<DisciplinaBasicaDTO>>(Disciplinas);

            return Retorno;
        }

        public DisciplinaDTO GetById(int Id)
        {
            Disciplina Disc = _Repositorio.GetById_2(Id);
            DisciplinaDTO DTO = _Mapper.Map <DisciplinaDTO> (Disc);

            return DTO;


        }

        public void PostDisciplina(CriarDisciplinaDTO InfoDisciplina)
        {
            Disciplina NovaDisciplina = new Disciplina();
            NovaDisciplina.Nome = InfoDisciplina.Nome;
            _Repositorio.Insert(NovaDisciplina);

        }

        public void PutDisciplina(CriarDisciplinaDTO InfoDisciplina, int Id)
        {
            Disciplina Att = _Repositorio.GetById(Id);
            if (Att != null)
            {
                Att.Nome = InfoDisciplina.Nome;
                _Repositorio.Update(Att);
            }

        }

        public void DeleteDisciplina(int Id)
        {
            Disciplina Remove = _Repositorio.GetById(Id);
            if (Remove != null)
                _Repositorio.Delete(Remove);
        }


    }
}
