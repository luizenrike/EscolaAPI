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
    public class AlunoServiceTeste
    {
        private readonly Mock<IAlunoRepository> _Repositorio;
        private readonly Mock<ITurmaRepository> _RepositorioTurma;
        private readonly AlunoService _Sut;

        public AlunoServiceTeste()
        {
            _Repositorio = new Mock<IAlunoRepository>();
            _RepositorioTurma = new Mock<ITurmaRepository>();   
            var Mapper = new MapperConfiguration(x => x.AddProfile(new AlunoProfile())).CreateMapper();
            _Sut = new AlunoService(_Repositorio.Object, _RepositorioTurma.Object, Mapper);
        }

        [Fact]
        public void TesteGetAll_Aluno()
        {
            // preparação
            List<Aluno> Alunos = new List<Aluno>();
            Aluno a1 = new Aluno();
            Aluno a2 = new Aluno();
            Aluno a3 = new Aluno();

            a1.Id = 1;
            a1.Nome = "Arnaldo";

            a2.Id = 2;
            a2.Nome = "Pereira";

            a3.Id = 3;
            a3.Nome = "José";

            Alunos.Add(a1);
            Alunos.Add(a2);
            Alunos.Add(a3);

            _Repositorio
                .Setup(x => x.GetAll()).Returns(Alunos);

            // atuação
            List<AlunoBasicoDTO> Retorno = new List<AlunoBasicoDTO>();
            Retorno = _Sut.GetAll();

            // verificação
            _Repositorio
                .Verify(x => x.GetAll(), Times.Once());
            Assert.NotEmpty(Retorno);
            Assert.Equal(3, Retorno.Count);
        }

        [Fact]
        public void TesteGetById_Aluno()
        {
            // preparação
            Aluno a1 = new Aluno();
            a1.Id = 1;
            a1.Nome = "carlos magno";

            _Repositorio
                .Setup(x => x.GetById(It.IsAny<int>())).Returns(a1);
            // atuação
            AlunoDTO Retorno = _Sut.GetById(a1.Id);

            // verificação
            Assert.Equal(Retorno.Nome, a1.Nome);
            _Repositorio
                .Verify(x => x.GetById(a1.Id), Times.Once());
        }

        [Fact]
        public void TestePost_Aluno()
        {
            // preparação
            CriarAlunoDTO NovoAluno = new CriarAlunoDTO();
            NovoAluno.Nome = "joao";
            NovoAluno.Email = "joao@gmail.com";

            Turma T = new Turma();
            T.Id = 1;
            T.Nome = "primeira";

            _RepositorioTurma
                .Setup(x => x.GetByName(It.IsAny<string>())).Returns(T);

            // atuação
            _Sut.PostAluno(NovoAluno);

            // verificação
            _Repositorio
                .Verify(x => x.Insert(It.Is<Aluno>(a => a.Nome == NovoAluno.Nome)), Times.Once());
        }

        [Fact]
        public void TestePut_Aluno()
        {
            // preparação
            Aluno Att = new Aluno();
            Att.Id = 1;
            Att.Nome = "Marcos";

            CriarAlunoDTO AttAluno = new CriarAlunoDTO();
            AttAluno.Nome = "Joao";

            Turma T = new Turma();
            T.Id = 2;
            T.Nome = "segunda";

            _RepositorioTurma
                .Setup(x => x.GetByName(It.IsAny<string>())).Returns(T);
            _Repositorio
                .Setup(x => x.GetById(It.IsAny<int>())).Returns(Att);

            // atuação
            _Sut.PutAluno(AttAluno, 1);

            // atuação
            _Repositorio
                .Verify(x => x.Update(Att), Times.Once());
        }

        [Fact]
        public void TesteDelete_Aluno()
        {
            // preparação
            Aluno A = new Aluno();
            A.Id = 1;
            A.Nome = "carlos";

            _Repositorio
                .Setup(x => x.GetById(It.IsAny<int>())).Returns(A);

            // atuação
            _Sut.DeleteAluno(1);

            // verificação
            _Repositorio
                .Verify(x => x.Delete(A), Times.Once());
        }

    }
}
