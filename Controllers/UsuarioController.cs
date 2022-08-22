using EscolaAPI.Application.DTOs;
using EscolaAPI.Application.Services;
using EscolaAPI.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EscolaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _Service;
        public UsuarioController(UsuarioService service)
        {
            _Service = service;
        }
        


        [HttpGet("Login")]
        public string Login([FromQuery]string Nome, [FromQuery]string Senha)
        {
            Usuario User = _Service.GetLogin(Nome, Senha);
            if(User != null)
                return _Service.GenerateToken(User);
            return null;
        }


        [HttpPost]
        [Authorize(Roles = "administrador")]
        public void PostUsuario(CriarUsuarioDTO InfoUsuario) => _Service.PostUsuario(InfoUsuario);

        
        [HttpPut("{Id}")]
        [Authorize(Roles = "administrador")]
        public void PutUsuario(CriarUsuarioDTO InfoUsuario, int Id) => _Service.PutUsuario(InfoUsuario, Id);

        
        [HttpDelete("{Id}")]
        [Authorize(Roles = "administrador")]
        public void DeleteUsuario(int Id) => _Service.DeleteUsuario(Id);    
        



    }
}
