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
    public class ProfessorController : ControllerBase
    {
        public ProfessorController(ProfessorService Service)
        {
            _Service = Service;
        }
        private readonly ProfessorService _Service;

        [HttpGet]
        [Authorize]
        public List<ProfessorBasicoDTO> GetAll() => _Service.GetAll();

        [HttpGet("{Id}")]
        [Authorize]
        public ProfessorDTO GetById(int Id) => _Service.GetById(Id);

        [HttpGet("nome/{Nome}")]
        [Authorize]
        public ProfessorDTO GetByName(string Nome) => _Service.GetByName(Nome);

        [HttpPost]
        [Authorize]
        public void PostProfessor(CriarProfessorDTO InfoProfessor) => _Service.PostProfessor(InfoProfessor);

        [HttpPut("{Id}")]
        [Authorize]
        public void PutProfessor(CriarProfessorDTO InfoProfessor, int Id) => _Service.PutProfessor(InfoProfessor, Id);

        [HttpDelete("{Id}")]
        [Authorize(Roles = "administrador")]
        public void DeleteProfessor(int Id) => _Service.DeleteProfessor(Id);


    }
}
