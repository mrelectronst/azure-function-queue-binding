using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace azurefunctablebinding.Models
{
    public class ProductDTO : TableEntity
    {
        public string Name { get; set; }

        public string Price { get; set; }

    }
}
