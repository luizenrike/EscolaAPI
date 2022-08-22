using EscolaAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaAPI.Infra.Context
{
    public class EscolaContext : DbContext
    {
        public EscolaContext(DbContextOptions <EscolaContext> Context) : base(Context)
        {

        }

        protected override void OnModelCreating(ModelBuilder Builder)
        {
            // *CRIANDO AS RELAÇÕES:
            //Uma disciplina possui várias turmas, mas uma turma só possui uma disciplina
            Builder.Entity<Disciplina>().HasMany(d => d.ListaTurmas).WithOne(t => t.Disciplina).HasForeignKey(t => t.DisciplinaID);
            
            // Uma turma possui vários alunos, mas um aluno só possui uma turma
            Builder.Entity<Turma>().HasMany(t => t.Alunos).WithOne(a => a.Turma).HasForeignKey(a => a.TurmaId);

            // Um Professor possui uma turma, e uma turma só possui um professor
            Builder.Entity<Professor>().HasOne(p => p.Turma).WithOne(t => t.Professor).HasForeignKey<Turma>(t => t.ProfessorID);


            // * DEFININDO CHAVES PRIMÁRIAS:
            Builder.Entity<Aluno>().HasKey(a => a.Id);
            Builder.Entity<Professor>().HasKey(p => p.Id);
            Builder.Entity<Turma>().HasKey(t => t.Id);
            Builder.Entity<Disciplina>().HasKey(d => d.Id);

            // * ATRIBUINDO REGRAS PARA AS PROPRIEDADES


            // * POPULANDO BANCO:
            Builder.Entity<Disciplina>().HasData(new Disciplina
            {
                Id = 1,
                Nome = "Matemática"
            });

            Builder.Entity<Aluno>().HasData(new Aluno
            {
                Id = 1,
                Nome = "Marcelo Cardoso",
                 TurmaId = 1,
                Email = "marcelo@gmail.com"
            });

            Builder.Entity<Professor>().HasData(new Professor
            {
                Id = 1,
                Nome = "Paulo Henrique"
            });

            Builder.Entity<Turma>().HasData(new Turma
            {
                Id = 1,
                Nome = "1A",
                DisciplinaID = 1,
                ProfessorID = 1
            });

            Builder.Entity<Usuario>().HasData(new Usuario
            {
                Id = 1,
                Nome = "admin",
                Senha = "admin",
                Cargo = "administrador"
            });

        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


    }
}
