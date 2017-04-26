using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing_OKM_2.Controllers
{
    interface IController<T>
    {
        void GetAllEntity();
        T GetEntityById(int id);
        void InsertEntity(T entity);
        void InsertAllEntities(IEnumerable<T> entities);
    }
}
