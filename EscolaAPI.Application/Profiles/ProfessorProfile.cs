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
    public class ProfessorProfile : Profile
    {
        public ProfessorProfile()
        {
            CreateMap<Professor, ProfessorBasicoDTO>()
                .ForMember(destino => destino.Id_Professor, opt => opt.MapFrom(origem => origem.Id))
                .ForMember(destino => destino.Nome_Professor, opt => opt.MapFrom(origem => origem.Nome));

            // mapeamento para auxiliar no retorno do GetAll e GetByNome
            CreateMap<Professor, ProfessorDTO>()
                .ForMember(destino => destino.Id, opt => opt.MapFrom(origem => origem.Id))
                .ForMember(destino => destino.Nome, opt => opt.MapFrom(origem => origem.Nome))
                .ForMember(destino => destino.Turma, opt => opt.MapFrom(origem => origem.Turma.Nome));
        }

    }
}
