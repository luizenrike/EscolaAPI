using AutoMapper;
using EscolaAPI.Application.DTOs;
using EscolaAPI.Application.Profiles;
using EscolaAPI.Application.Services;
using EscolaAPI.Domain.Interfaces;
using EscolaAPI.Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EscolaAPI.Testes
{
    public class TurmaServiceTeste
    {
        private readonly Mock<ITurmaRepository> _Repositorio;
        private readonly Mock<IDisciplinaRepository> _RepositorioDisciplina;
        private readonly TurmaService _Sut;
        private readonly Mock<IProfessorRepository> _RepositorioProfessor;

        public TurmaServiceTeste()
        {
            _Repositorio = new Mock<ITurmaRepository>();
            _RepositorioDisciplina = new Mock<IDisciplinaRepository>();
            _RepositorioProfessor = new Mock<IProfessorRepository>();
            var Mapper = new MapperConfiguration(x => x.AddProfile(new TurmaProfile())).CreateMapper();
            _Sut = new TurmaService(_Repositorio.Object, Mapper, _RepositorioDisciplina.Object, _RepositorioProfessor.Object);
        }

        [Fact]
        public void TesteGetAll_Turma()
        {
            // preparação
            List<Turma> Turmas = new List<Turma>();
            Turma T1 = new Turma();
            Turma T2 = new Turma();

            T1.Id = 1;
            T1.Nome = "primeira";

            T2.Id = 2;
            T2.Nome = "segunda";

            Turmas.Add(T1);
            Turmas.Add(T2);

            _Repositorio
                .Setup(x => x.GetAll()).Returns(Turmas);

            // atuação
            List<TurmaBasicaDTO> Retorno = new List<TurmaBasicaDTO>();
            Retorno = _Sut.GetAll();

            // verificação
            _Repositorio
                .Verify(x => x.GetAll(), Times.Once());
            Assert.NotEmpty(Retorno);
            Assert.Equal(2, Retorno.Count);
        }


        [Fact]
        public void TesteGetById_Turma()
        {
            // preparação
            Turma T = new Turma();
            T.Id = 1;
            T.Nome = "primeira";
            T.Disciplina = null;
            T.Professor = null;
            T.Alunos = null;

            _Repositorio
                .Setup(x => x.GetById_2(It.IsAny<int>())).Returns(T);

            // atuação
            TurmaDTO Retorno = _Sut.GetById(1);


            // verificação
            
            Assert.Equal("primeira", Retorno.Nome);
            _Repositorio
                .Verify(x => x.GetById_2(1), Times.Once());
        }
        
    }
}
