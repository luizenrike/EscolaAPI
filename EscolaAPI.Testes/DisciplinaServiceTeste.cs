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
    public class DisciplinaServiceTeste
    {
        private readonly Mock<IDisciplinaRepository> _Repositorio;
        private readonly DisciplinaService _Sut;

        public DisciplinaServiceTeste()
        {
            var Mapper = new MapperConfiguration(x => x.AddProfile(new DisciplinaProfile())).CreateMapper();
            _Repositorio = new Mock<IDisciplinaRepository>();
            _Sut = new DisciplinaService(_Repositorio.Object, Mapper);
        }

        [Fact]
        public void TesteGetAll_Disciplina()
        {
            // preparação
            List<Disciplina> Disciplinas = new List<Disciplina>();
            Disciplina d1 = new Disciplina();
            Disciplina d2 = new Disciplina();
            d1.Id = 1;
            d1.Nome = "d1";

            d2.Id = 2;
            d2.Nome = "d2";

            Disciplinas.Add(d1);
            Disciplinas.Add(d2);

            _Repositorio
                .Setup(x => x.GetAll()).Returns(Disciplinas);

            // atuação
            List<DisciplinaBasicaDTO> Retorno = new List<DisciplinaBasicaDTO>();
            Retorno = _Sut.GetAll();

            // verificação
            Assert.Equal(2, Retorno.Count);
            Assert.NotEmpty(Retorno);
            _Repositorio
                .Verify(x => x.GetAll(), Times.Once());
        }

        [Fact]
        public void TesteGetById_Disciplina()
        {
            // preparação
            Disciplina D = new Disciplina();
            D.Id = 1;
            D.Nome = "português";

            _Repositorio
                .Setup(x => x.GetById(It.IsAny<int>())).Returns(D);
            // atuação
            DisciplinaDTO Retorno = _Sut.GetById(D.Id);

            // verificação
            Assert.Equal(Retorno.Nome, D.Nome);
            _Repositorio
                .Verify(x => x.GetById(D.Id), Times.Once());
        }

        [Fact]
        public void TestePost_Disciplina()
        {
            // preparação
            CriarDisciplinaDTO NovaDisciplina = new CriarDisciplinaDTO();
            NovaDisciplina.Nome = "português";


            // atuação
            _Sut.PostDisciplina(NovaDisciplina);

            //verificação
            _Repositorio
                .Verify(x => x.Insert(It.Is<Disciplina>(d => d.Nome == NovaDisciplina.Nome)), Times.Once());
        }

        [Fact]
        public void TestePut_Disciplina()
        {
            // preparação
            CriarDisciplinaDTO D = new CriarDisciplinaDTO();
            D.Nome = "teste";

            Disciplina Att = new Disciplina();
            Att.Id = 1;
            Att.Nome = "português";

            _Repositorio
                .Setup(x => x.GetById(It.IsAny<int>())).Returns(Att);

            // atuação
            _Sut.PutDisciplina(D, 1);

            // verificação
            _Repositorio
                .Verify(x => x.Update(Att), Times.Once());
        }

        [Fact]
        public void TesteDelete_Disciplina()
        {
            // preparação
            Disciplina D = new Disciplina();
            D.Id = 1;
            D.Nome = "matemática";


            _Repositorio
                .Setup(x => x.GetById(It.IsAny<int>())).Returns(D);
            // atuação
            _Sut.DeleteDisciplina(1);

            // verificação
            _Repositorio.Verify(x => x.Delete(D), Times.Once());
        }

    }
}
