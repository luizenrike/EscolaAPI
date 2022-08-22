using AutoMapper;
using EscolaAPI.Application.DTOs;
using EscolaAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaAPI.Application.Profiles
{
    public class TurmaProfile : Profile
    {
        public TurmaProfile()
        {
            
            // Mapeamento para auxiliar no retorno do GetById
            CreateMap<Turma, TurmaDTO>()
                .ForMember(destino => destino.Id, opt => opt.MapFrom(origem => origem.Id))
                .ForMember(destino => destino.Nome, opt => opt.MapFrom(origem => origem.Nome))
                .ForMember(destino => destino.Professor, opt => opt.MapFrom(origem => origem.Professor.Nome))
                .ForMember(destino => destino.Disciplina, opt => opt.MapFrom(origem => origem.Disciplina.Nome))
                .ForMember(destino => destino.ListaAlunos, opt => opt.MapFrom(origem => origem.Alunos));

            // Mapeamento para auxiliar no retorno do GetAll
            CreateMap<Turma, TurmaBasicaDTO>()
                .ForMember(destino => destino.Id_Turma, opt => opt.MapFrom(origem => origem.Id))
                .ForMember(destino => destino.Nome_Turma, opt => opt.MapFrom(origem => origem.Nome));

        }

    }
}
