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
    public class AlunoController : ControllerBase
    {
        public AlunoController(AlunoService Service)
        {
            _Service = Service;
        }
        private readonly AlunoService _Service;

        [HttpGet]
        [Authorize]
        public List<AlunoBasicoDTO> GetAll() => _Service.GetAll();

        [HttpGet("{Id}")]
        [Authorize]
        public Aluno GetById(int Id) => _Service.GetById(Id);

        [HttpPost]
        [Authorize]
        public void PostAluno(CriarAlunoDTO InfoAluno) => _Service.PostAluno(InfoAluno);

        [HttpPut("{Id}")]
        [Authorize]
        public void PutAluno(CriarAlunoDTO InfoAluno, int Id) => _Service.PutAluno(InfoAluno, Id);

        [HttpDelete("{Id}")]
        [Authorize(Roles = "administrador")]
        public void DeleteAluno(int Id) => _Service.DeleteAluno(Id);

    }
}
