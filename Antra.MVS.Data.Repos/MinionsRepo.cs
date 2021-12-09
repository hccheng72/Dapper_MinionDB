using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;// add

using Antra.MVS.Data.Entities;

namespace Antra.MVS.Data.Repos
{
    class MinionsRepo : IRepo<Minions>
    {
        MVSDbContext _db;
        public MinionsRepo()
        {
            _db = new MVSDbContext();
        }
        public int Delete(int id)
        {
            string cmd = "delete from Minions where id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>(); //why object
            parameters.Add("@id", id); //what if want to add more than one id?
            return _db.Execute(cmd, parameters);
        }

        public int Insert(Minions entity)
        {
            string cmd = "insert into Minions values (@name, @age, @townId)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@name", entity.Name);
            parameters.Add("@age", entity.Age);
            parameters.Add("@townId", entity.TownId);
            return _db.Execute(cmd, parameters);
        }

        public int Update(Minions entity)
        {
            string cmd = "update Minios set name=@name, age=@age, townId=@townId where id=@id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@name", entity.Name);
            parameters.Add("@age", entity.Age);
            parameters.Add("@townId", entity.TownId);
            parameters.Add("@id", entity.Id);
            return _db.Execute(cmd, parameters);
        }

        public IEnumerable<Minions> GetAll()
        {
            string cmd = "select id, name, age, townId from Minions";
            DataTable dt = _db.Query(cmd, null);

            List<Minions> list = new List<Minions>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Minions minion = new Minions();
                    minion.Id = Convert.ToInt32(row["Id"]);
                    minion.Name = Convert.ToString(row["Name"]);
                    minion.Age = Convert.ToInt32(row["Age"]);
                    minion.TownId = Convert.ToInt32(row["TownId"]);
                    list.Add(minion);
                }
            }
            return list;
        }

        public Minions GetRowById(int id)
        {
            string cmd = "select id, name, age, townId from Minions where id=@id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            DataTable dt = _db.Query(cmd, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                Minions minion = new Minions();
                minion.Id = Convert.ToInt32(row["Id"]);
                minion.Name = Convert.ToString(row["Name"]);
                minion.Age = Convert.ToInt32(row["Age"]);
                minion.TownId = Convert.ToInt32(row["TownId"]);
                return minion;
            }
            return null;
        }
    }
}
