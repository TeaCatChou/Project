using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public interface IRepository<T>
    {
        T GetById(Guid? guid);
        T GetId(int id);
        IEnumerable<T> GetAll();
        void Create(T _entity);
        void Edit(T _entity);
        void Delete(T _entity);

    }
}
