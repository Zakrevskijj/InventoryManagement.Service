﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Entities
{
    public class Company : Entity
    {
        public string Name { get; set; }
        public int Prefix { get; set; }
    }
}
