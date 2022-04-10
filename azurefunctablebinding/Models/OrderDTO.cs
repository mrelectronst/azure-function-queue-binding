using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace azurefunctablebinding.Models
{
    public class OrderDTO: TableEntity
    {
        public string Amount { get; set; }

        public CustomerDTO Customer { get; set; }

        public ProductDTO Product { get; set; }
    }
}
