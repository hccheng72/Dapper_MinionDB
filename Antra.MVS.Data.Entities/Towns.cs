﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.MVS.Data.Entities
{
    public class Towns
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int CountryId { get; set; }
    }
}
