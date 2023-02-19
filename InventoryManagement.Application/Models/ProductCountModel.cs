using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Models
{
    public class ProductCountModel
    {
        public ProductModel ProductModel { get; set; }
        public int Count { get; set; }
    }
}
