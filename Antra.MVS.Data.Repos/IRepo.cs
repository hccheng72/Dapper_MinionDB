using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.MVS.Data.Repos
{
    public interface IRepo<Entity> where Entity : class
    {
        int Insert(Entity entity);
        int Update(Entity entity);
        int Delete(int id);
        IEnumerable<Entity> GetAll();
        Entity GetRowById(int id);
    }
}
