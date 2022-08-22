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
    public class DisciplinaProfile : Profile
    {
        public DisciplinaProfile()
        {
            // Mapeamento para auxiliar no retorno do GetById
            CreateMap<Disciplina, DisciplinaDTO>()
                .ForMember(destino => destino.ListaTurmas, opt => opt.MapFrom(origem => origem.ListaTurmas));

            // mapeamento para auxiliar no retorno do GetAll
            CreateMap<Disciplina, DisciplinaBasicaDTO>()
                .ForMember(destino => destino.Id_Disciplina, opt => opt.MapFrom(origem => origem.Id))
                .ForMember(destino => destino.Nome_Disciplina, opt => opt.MapFrom(origem => origem.Nome));
        }
    }
}
