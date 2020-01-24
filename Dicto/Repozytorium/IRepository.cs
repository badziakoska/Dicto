using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dicto.Models;

namespace Dicto.Repozytorium
{
    public interface IRepository<T> where T : BaseModel
    {
        IQueryable<T> Collection();
        void Commit();
        void Delete(string id);
        T Find(string id);
        void Insert(T t);
        void Update(T t);

    }
}
