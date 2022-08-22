﻿using EscolaAPI.Application.DTOs;
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
    public class DisciplinaController : ControllerBase
    {
        public DisciplinaController(DisciplinaService Service)
        {
            _Service = Service;
        }
        private readonly DisciplinaService _Service;

        [HttpGet]
        [Authorize]
        public List<DisciplinaBasicaDTO> GetAll() => _Service.GetAll();
        
        [HttpGet("{Id}")]
        [Authorize]
        public DisciplinaDTO GetById(int Id) => _Service.GetById(Id);

        [HttpPost]
        [Authorize]
        public void PostDisciplina(CriarDisciplinaDTO InfoDisciplina) => _Service.PostDisciplina(InfoDisciplina);

        [HttpPut("{Id}")]
        [Authorize]
        public void PutDisciplina(CriarDisciplinaDTO InfoDisciplina, int Id) => _Service.PutDisciplina(InfoDisciplina, Id);

        [HttpDelete("{Id}")]
        [Authorize(Roles = "administrador")]
        public void DeleteDisciplina(int Id) => _Service.DeleteDisciplina(Id);

    }
}
