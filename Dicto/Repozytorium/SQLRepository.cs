using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dicto.Models;
using Microsoft.EntityFrameworkCore;

namespace Dicto.Repozytorium
{
    public class SQLRepository<T> : IRepository<T> where T : BaseModel
    {
            private ApplicationDbContext context;
            private DbSet<T> dbSet;

            public SQLRepository(ApplicationDbContext context)
            {
                this.context = context;
                this.dbSet = context.Set<T>();
            }

            public IQueryable<T> Collection()
            {
                return dbSet;
            }

            public void Commit()
            {
                context.SaveChanges();
            }

            public void Delete(string id)
            {
                var t = Find(id);
                if (context.Entry(t).State == EntityState.Detached)
                {
                    dbSet.Attach(t);
                }
                dbSet.Remove(t);
            }

            public T Find(string id)
            {
                return dbSet.Find(id);
            }

            public void Insert(T t)
            {
                dbSet.Add(t);
            }

            public void Update(T t)
            {
                dbSet.Attach(t);
                context.Entry(t).State = EntityState.Modified;
            }
        
    }
}
