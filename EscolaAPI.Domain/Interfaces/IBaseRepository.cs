using EscolaAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaAPI.Domain.Interfaces
{
    public interface IBaseRepository <T> where T : EntidadeBase
    {
        List<T> GetAll();
        T GetById(int Id);
        void Insert(T Entity);
        void Update(T Entity);
        void Delete (T Entity);

    }
}
