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
    public class ProfessorServiceTeste
    {
        private readonly ProfessorService _Sut;
        private readonly Mock<IProfessorRepository> _Repositorio;
        private readonly Mock<ITurmaRepository> _RepositorioTurma;
        
        public ProfessorServiceTeste()
        {
            _Repositorio = new Mock<IProfessorRepository>();
            _RepositorioTurma = new Mock<ITurmaRepository>();
            var Mapper = new MapperConfiguration(x => x.AddProfile(new ProfessorProfile())).CreateMapper();
            _Sut = new ProfessorService(_Repositorio.Object, _RepositorioTurma.Object, Mapper);
        }

        [Fact]
        public void TesteGetAll_Professor()
        {
            // preparação
            List<Professor> Professores = new List<Professor>();
            Professor Prof_1 = new Professor();
            Professor Prof_2 = new Professor();

            Prof_1.Id = 1;
            Prof_1.Nome= "Carlos Augusto";

            Prof_2.Id = 2;
            Prof_2.Nome = "Maria Antonieta";

            Professores.Add(Prof_1);
            Professores.Add(Prof_2);

            _Repositorio.Setup(p => p.GetAll()).Returns(Professores);


            // atuação
            List<ProfessorBasicoDTO> Lista = _Sut.GetAll();

            // verificação
            _Repositorio
                .Verify(x => x.GetAll(), Times.Once());
            Assert.NotEmpty(Lista);

        }

        [Fact]
        public void TesteGetByName_Professor()
        {
            // preparação
            Professor Prof = new Professor();
            Prof.Id = 1;
            Prof.Nome = "Mario";

            _Repositorio
                .Setup(p => p.GetByName(It.IsAny<string>())).Returns(Prof);

            // atuação
            ProfessorDTO Retorno = new ProfessorDTO();
            Retorno = _Sut.GetByName("teste");

            // verificação
            Assert.NotNull(Retorno);
            Assert.Equal("Mario", Retorno.Nome);

        }

        [Fact]
        public void TestePost_Professor()
        {
            // preparação
            CriarProfessorDTO NovoProfessor = new CriarProfessorDTO();
            NovoProfessor.Nome = "Joao";

            //atuação
            _Sut.PostProfessor(NovoProfessor);

            //verificação
            _Repositorio
                .Verify(p => p.Insert(It.Is<Professor>(p => p.Nome == NovoProfessor.Nome)), Times.Once());
        }

        [Fact]
        public void TestePut_Professor()
        {
            // preparação
            CriarProfessorDTO Prof = new CriarProfessorDTO();
            Prof.Nome = "Joao";

            Professor Att = new Professor();
            Att.Nome = Prof.Nome;
            Att.Id = 1;

            _Repositorio
                .Setup(x => x.GetById(It.IsAny<int>())).Returns(Att);

            // atuação
            _Sut.PutProfessor(Prof, 1);


            // verificação
            _Repositorio
                .Verify(x => x.Update(Att), Times.Once());
        }

        [Fact]
        public void TesteDelete_Professor()
        {
            // preparação
            Professor Prof = new Professor();
            Prof.Id = 1;
            Prof.Nome = "Pedro";

            _Repositorio
                .Setup(x => x.GetById(It.IsAny<int>())).Returns(Prof);

            //atuação
            _Sut.DeleteProfessor(1);

            //verificação
            _Repositorio
                .Verify(x => x.Delete(Prof), Times.Once());

        }



    }
}
