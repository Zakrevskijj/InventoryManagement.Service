using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Models
{
    public class ProductsCountForCompany
    {
        public CompanyModel CompanyModel { get; set; }
        public int Count { get; set; }  
    }
}
