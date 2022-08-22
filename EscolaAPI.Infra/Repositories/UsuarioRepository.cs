using EscolaAPI.Domain.Interfaces;
using EscolaAPI.Domain.Models;
using EscolaAPI.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaAPI.Infra.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(EscolaContext context) : base(context)
        {

        }

        public Usuario GetLogin(string Nome, string Senha)
        {
            return Database.Usuarios.Where(u => u.Nome.ToLower() == Nome.ToLower() && u.Senha == Senha).FirstOrDefault();
        }
    }
}
