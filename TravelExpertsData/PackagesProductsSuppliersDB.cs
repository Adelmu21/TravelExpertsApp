using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TravelExpertsData
{
    public class PackagesProductsSuppliersDB
    {

        public static List<PackagesProductsSuppliersDTO> GetPPS()
        {
            List<PackagesProductsSuppliersDTO> packagesProdSup = new List<PackagesProductsSuppliersDTO>();
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                packagesProdSup = (from pps in db.PackagesProductsSuppliers
                                   join ps in db.ProductsSuppliers on pps.ProductSupplierId equals ps.ProductSupplierId
                                   join p in db.Products on ps.ProductId equals p.ProductId
                                   join s in db.Suppliers on ps.SupplierId equals s.SupplierId
                                   join pkg in db.Packages on pps.PackageId equals pkg.PackageId
                                   select new PackagesProductsSuppliersDTO
                                   {
                                       ProductSupplierId = s.SupplierId,
                                       ProdName = p.ProdName,
                                       SupName = s.SupName,
                                   }).ToList();
            }
            return packagesProdSup;
        }

    }
}
