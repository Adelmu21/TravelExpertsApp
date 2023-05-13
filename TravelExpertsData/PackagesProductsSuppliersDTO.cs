using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public class PackagesProductsSuppliersDTO
    {

        public int PackageId { get; set; }

        public int ProductSupplierId { get; set; }

        public string? PkgName { get; set; }
        public string? ProdName { get; set; }
        public string? SupName { get; set; }
    }
}
