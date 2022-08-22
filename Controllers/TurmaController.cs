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
    public class TurmaController : ControllerBase
    {
        public TurmaController(TurmaService Service)
        {
            _Service = Service;
        }
        private readonly TurmaService _Service;

        [HttpGet]
        [Authorize]
        public List<TurmaBasicaDTO> GetAll() => _Service.GetAll();

        [HttpGet("{Id}")]
        [Authorize]
        public TurmaDTO GetById(int Id) => _Service.GetById(Id);

        [HttpPost]
        [Authorize]
        public void PostTurma(CriarTurmaDTO InfoTurma) => _Service.PostTurma(InfoTurma);

        [HttpPut("{Id}")]
        [Authorize]
        public void PutTurma(CriarTurmaDTO InfoTurma, int Id) => _Service.PutTurma(InfoTurma, Id);

        [HttpDelete("{Id}")]
        [Authorize(Roles = "administrador")]
        public void DeleteTurma(int Id) => _Service.DeleteTurma(Id);
    }
}
