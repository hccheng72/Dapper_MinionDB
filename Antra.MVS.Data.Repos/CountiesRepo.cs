using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;// add

using Antra.MVS.Data.Entities;

namespace Antra.MVS.Data.Repos
{
    class CountiesRepo : IRepo<Countries>
    {
        MVSDbContext _db;
        public CountiesRepo()
        {
            _db = new MVSDbContext();
        }
        public int Delete(int id)
        {
            string cmd = "delete from Countries where id=@id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            return _db.Execute(cmd, parameters);
        }

        public IEnumerable<Countries> GetAll()
        {
            string cmd = "select Id, Name from Countries";
            DataTable dt = _db.Query(cmd, null);
            if (dt.Rows.Count > 0)
            {
                List<Countries> list = new List<Countries>();
                foreach (DataRow row in dt.Rows)
                {
                    Countries country = new Countries();
                    country.Id = Convert.ToInt32(row["Id"]);
                    country.Name = Convert.ToString(row["Name"]);
                    list.Add(country);
                }
                return list;
            }
            return null;
        }

        public Countries GetRowById(int id)
        {
            string cmd = "select Id, Name from Countries where id=@id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            DataTable dt = _db.Query(cmd, parameters);//DataRow is an Object
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                Countries country = new Countries();
                country.Id = Convert.ToInt32(row["Id"]);
                country.Name = Convert.ToString(row["Name"]);
                return country;
            }
            return null;
        }

        public int Insert(Countries entity)
        {
            string cmd = "insert into Countries values (@name)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@name", entity.Name);
            return _db.Execute(cmd, parameters);
        }

        public int Update(Countries entity)
        {
            try
            {
                string cmd = "update Countries set name=@name where id=@id";
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@name", entity.Name);
                parameters.Add("@id", entity.Id);
                return _db.Execute(cmd, parameters);
            }
            catch (NotImplementedException e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }
    }
}
