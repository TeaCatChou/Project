using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Repository<T> : IRepository<T> where T : class
    {
        ProjectEntities db = null;
        private DbSet<T> Dbset = null;
        public Repository()
        {
            db = new ProjectEntities();
            Dbset = db.Set<T>();
        }
        public void Create(T _entity)
        {
            Dbset.Add(_entity);
            db.SaveChanges();
        }

        public void Delete(T _entity)
        {
            Dbset.Remove(_entity);
            db.SaveChanges();
        }

        public void Edit(T _entity)
        {
            db.Entry(_entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return Dbset;
        }

        public T GetById(Guid? guid)
        {
            return Dbset.Find(guid);
        }

        public T GetId(int id)
        {
            return Dbset.Find(id);
        }
    }
}