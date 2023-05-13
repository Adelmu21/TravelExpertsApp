using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public class ProductsSuppliersDT
    {


        public int? ProductSupplierId { get; set; }

        public int? ProductId { get; set; }


        public string? ProdName { get; set; } = null!;

        public int? SupplierId { get; set; }

        public string? SupName { get; set; }

        public ProductsSuppliersDT(string? prodName, string? supName)
        {
            this.ProdName = prodName;
            this.SupName = supName;
        }

        public virtual string GetDisplayText(string sep) =>
            ProdName + sep + SupName;
    }
}
