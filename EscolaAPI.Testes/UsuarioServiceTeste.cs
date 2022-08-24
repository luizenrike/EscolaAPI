using EscolaAPI.Application.DTOs;
using EscolaAPI.Application.Services;
using EscolaAPI.Domain.Interfaces;
using EscolaAPI.Domain.Models;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EscolaAPI.Testes
{
    public class UsuarioServiceTeste
    {
        private readonly Mock<IUsuarioRepository> _Repositorio;
        private readonly IConfiguration _Configuration;
        private readonly UsuarioService _Sut;

        public UsuarioServiceTeste()
        {
            _Repositorio = new Mock<IUsuarioRepository>();
            _Sut = new UsuarioService(_Repositorio.Object, _Configuration);

        }

        [Fact]
        public void TesteGetLogin_Usuario()
        {
            //preparação
            Usuario User = new Usuario();
            User.Nome = "teste";
            User.Senha = "123";
            User.Cargo = "funcionario";

            _Repositorio
                .Setup(x => x.GetLogin(It.IsAny<string>(), It.IsAny<string>())).Returns(User);


            //atuação
            Usuario Retorno = _Sut.GetLogin("a", "b");

            // verificação
            Assert.Equal(Retorno.Nome, User.Nome);
            _Repositorio
                .Verify(x => x.GetLogin("a", "b"), Times.Once());
        }

        [Fact]
        public void TestePost_Usuario()
        {
            // preparação
            CriarUsuarioDTO NovoUsuario = new CriarUsuarioDTO();
            NovoUsuario.Nome = "adm";
            NovoUsuario.Senha = "123";
            NovoUsuario.Cargo = "administrador";



            // atuação
            _Sut.PostUsuario(NovoUsuario);

            // verificação
            _Repositorio
                .Verify(x => x.Insert(It.Is<Usuario>(u => u.Nome == NovoUsuario.Nome)), Times.Once());
        }

        [Fact]
        public void TestePut_Usuario()
        {
            // preparação
            CriarUsuarioDTO User = new CriarUsuarioDTO();
            User.Nome = "adm";
            User.Senha = "123";
            User.Cargo = "administrador";

            Usuario Att = new Usuario();
            Att.Id = 1;
            Att.Nome = User.Nome;
            Att.Senha = User.Senha;
            Att.Cargo = User.Cargo;

            _Repositorio
                .Setup(x => x.GetById(It.IsAny<int>())).Returns(Att);

            // atuação
            _Sut.PutUsuario(User, 1);

            // verificação
            _Repositorio
                .Verify(x => x.Update(Att), Times.Once());
        }

        [Fact]
        public void TesteDelete_Usuario()
        {
            // preparação
            Usuario U = new Usuario();
            U.Id = 1;
            U.Nome = "teste";
            U.Senha = "123";
            U.Cargo = "teste";

            _Repositorio
                .Setup(x => x.GetById(It.IsAny<int>())).Returns(U);

            // atuação
            _Sut.DeleteUsuario(1);

            // verificação
            _Repositorio
                .Verify(x => x.Delete(U), Times.Once());
        }

    }
}
