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
                .Setup(x => x.GetById(It.IsAny<int>())).Returns(T);

            // atuação
            TurmaDTO Retorno = _Sut.GetById(1);


            // verificação
            
            Assert.Equal("primeira", Retorno.Nome);
            _Repositorio
                .Verify(x => x.GetById(1), Times.Once());
        }

        [Fact]
        public void TestePost_Turma()
        {
            // preparação
            CriarTurmaDTO NovaTurma = new CriarTurmaDTO();
            Disciplina Disc = new Disciplina();
            Professor Prof = new Professor();
            Disc.Id = 1;
            Disc.Nome = "filosofia";

            Prof.Id = 1;
            Prof.Nome = "alvaro";


            NovaTurma.Nome = "primeira";
            NovaTurma.Disciplina = "filosofia";
            NovaTurma.Professor = "alvaro";

            _RepositorioDisciplina
                .Setup(x => x.GetByName(It.IsAny<string>())).Returns(Disc);

            _RepositorioProfessor
                .Setup(x => x.GetByName(It.IsAny<string>())).Returns(Prof);

            // atuação
            _Sut.PostTurma(NovaTurma);

            // verificação
            _Repositorio
                .Verify(x => x.Insert(It.Is<Turma>(t => t.Nome == NovaTurma.Nome)), Times.Once());
        }

        [Fact]
        public void TestePut_Turma()
        {
            // preparação
            CriarTurmaDTO T = new CriarTurmaDTO();
            Disciplina Disc = new Disciplina();
            Professor Prof = new Professor();
            Turma Att = new Turma();

            Att.Id = 1;
            Att.Nome = "primeira";
            Att.Disciplina = Disc;
            Att.Professor = Prof;


            Disc.Id = 1;
            Disc.Nome = "geografia";

            Prof.Id = 1;
            Prof.Nome = "carlos";


            T.Nome = "primeira";
            T.Disciplina = "matematica";
            T.Professor = "joao";

            _Repositorio
                .Setup(x => x.GetById(It.IsAny<int>())).Returns(Att);

            _RepositorioDisciplina
                .Setup(x => x.GetByName(It.IsAny<string>())).Returns(Disc);

            _RepositorioProfessor
                .Setup(x => x.GetByName(It.IsAny<string>())).Returns(Prof);

            // atuação
            _Sut.PutTurma(T, 1);

            // verificação
            _Repositorio
                .Verify(x => x.Update(Att), Times.Once());

        }

        [Fact]
        public void TesteDelete_Turma()
        {
            // preparação
            Turma T = new Turma();
            T.Id = 1;
            T.Nome = "primeira";

            _Repositorio
                .Setup(x => x.GetById(It.IsAny<int>())).Returns(T);


            // atuação
            _Sut.DeleteTurma(T.Id);

            // verificação
            _Repositorio
                .Verify(x => x.Delete(T), Times.Once());
        }
        
    }
}
