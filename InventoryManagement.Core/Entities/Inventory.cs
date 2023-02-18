using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Entities
{
    public class Inventory : Entity
    {
        public DateTime DateTimeUtc { get; set; }
        public string ExternalId { get; set; }
        public string Location { get; set; }
    }
}
