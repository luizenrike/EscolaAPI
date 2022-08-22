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
    public class AlunoProfile : Profile
    {
        public AlunoProfile()
        {
            // mapeamento para auxiliar no retorno do GetById
            CreateMap<Aluno, AlunoDTO>()
                .ForMember(destino => destino.Nome, opt => opt.MapFrom(origem => origem.Nome))
                .ForMember(destino => destino.Email, opt => opt.MapFrom(origem => origem.Email))
                .ForMember(destino => destino.Turma, opt => opt.MapFrom(origem => origem.Turma.Nome));

            // mapeamento para auxiliar no retorno do GetAll
            CreateMap<Aluno, AlunoBasicoDTO>()
                .ForMember(destino => destino.Id_Aluno, opt => opt.MapFrom(origem => origem.Id))
                .ForMember(destino => destino.Nome_Aluno, opt => opt.MapFrom(origem => origem.Nome))
                .ForMember(destino => destino.Turma_Aluno, opt => opt.MapFrom(origem => origem.Turma.Nome));
        }
    }
}
