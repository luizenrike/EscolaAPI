using EscolaAPI.Application.DTOs;
using EscolaAPI.Domain.Interfaces;
using EscolaAPI.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EscolaAPI.Application.Services
{
    public class UsuarioService
    {
        private readonly IConfiguration _Configuration;
        private readonly IUsuarioRepository _Repositorio;

        public UsuarioService(IUsuarioRepository repositorio, IConfiguration configuration)
        {
            _Repositorio = repositorio;
            _Configuration = configuration;
        }
        

        //public List<Usuario> GetAll() => _Repositorio.GetAll();

        //public Usuario GetById(int Id) => _Repositorio.GetById(Id);

        public Usuario GetLogin(string Nome, string Senha) => _Repositorio.GetLogin(Nome, Senha);

        public void PostUsuario(CriarUsuarioDTO InfoUsuario)
        {
            Usuario NovoUsuario = new Usuario();
            NovoUsuario.Nome = InfoUsuario.Nome;
            NovoUsuario.Senha = InfoUsuario.Senha;
            NovoUsuario.Cargo = InfoUsuario.Cargo;

            _Repositorio.Insert(NovoUsuario);
        }

        public void PutUsuario(CriarUsuarioDTO InfoUsuario, int Id)
        {
            Usuario Att = _Repositorio.GetById(Id);
            if(Att != null)
            {
                Att.Nome = InfoUsuario.Nome;
                Att.Senha = InfoUsuario.Senha;
                Att.Cargo = InfoUsuario.Cargo;
                _Repositorio.Update(Att);
            }
        }

        public void DeleteUsuario(int Id)
        {
            Usuario Remove = _Repositorio.GetById(Id);
            if (Remove != null)
                _Repositorio.Delete(Remove);
        }

        public string GenerateToken(Usuario Usuario)
        {
            string SecretKeyConfig = _Configuration.GetSection("secretKey").Value;
            byte[] secretKey = Encoding.ASCII.GetBytes(SecretKeyConfig);
            var tokenHandler = new JwtSecurityTokenHandler();


            // adicionando permissões no Token:
            var PermissaoNome = new Claim("Nome", Usuario.Nome);
            var PermissaoCargo = new Claim(ClaimTypes.Role, Usuario.Cargo);
            List<Claim> Permissoes = new List<Claim>();
            Permissoes.Add(PermissaoCargo);
            Permissoes.Add(PermissaoNome);
            var Claims = new ClaimsIdentity(Permissoes);

            var TokenDescriptor = new SecurityTokenDescriptor();
            TokenDescriptor.Subject = Claims;

            //adicionando tempo de expiração no Token:
            TokenDescriptor.Expires = DateTime.Now.AddHours(8); // o token expira dentro de duas horas

            TokenDescriptor.Issuer = Usuario.Nome;
            TokenDescriptor.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature);

            string Token = tokenHandler.CreateEncodedJwt(TokenDescriptor);
            return Token;
        }

    }
}
