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
    public class BaseRepository<T> : IBaseRepository<T> where T : EntidadeBase
    {

        public BaseRepository(EscolaContext database)
        {
            Database = database;
        }
        public readonly EscolaContext Database;

        public List<T> GetAll()
        {
            return Database.Set<T>().ToList();
        }

        public T GetById(int Id)
        {
            return Database.Set<T>().Where(x => x.Id == Id).FirstOrDefault();
        }

        public void Insert(T Entity)
        {
            Database.Set<T>().Add(Entity);
            Database.SaveChanges();
        }

        public void Update(T Entity)
        {
            Database.Set<T>().Update(Entity);
            Database.SaveChanges();
        }

        public void Delete(T Entity)
        {
            Database.Set<T>().Remove(Entity);
            Database.SaveChanges();
        }


    }
}
