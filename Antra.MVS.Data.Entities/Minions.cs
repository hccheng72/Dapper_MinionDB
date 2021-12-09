using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.MVS.Data.Entities
{
    public class Minions //default is internal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int TownId { get; set; }

        //navigational property
        public Towns Town { get; set; }
    }
}
