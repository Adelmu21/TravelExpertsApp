using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExpertsData.Models;

namespace TravelExpertsData
{
    public class PackageDB
    {
        public static List<PackageDTO> GetPackages()
        {
            List<PackageDTO> packages = new List<PackageDTO>();// empty list
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                packages = db.Packages.
                OrderBy(p => p.PackageId).
                    Select(p => new PackageDTO()
                    {
                        PackageId = p.PackageId,
                        PkgName = p.PkgName,
                        PkgStartDate = p.PkgStartDate,
                        PkgEndDate = p.PkgEndDate,
                        //PkgDesc = p.PkgDesc,
                        //PkgBasePrice = p.PkgBasePrice,
                        //PkgAgencyCommission = p.PkgAgencyCommission
                    }).ToList();
            }
            return packages;
        }


        /// <summary>
        /// find product by primary key value
        /// </summary>
        /// <param name = "productCode" > code of the product to find</param>
        /// <returns>found product or null</returns>
        public static Package FindPackage(int packageId)
        {
            Package package;
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                package = db.Packages.Find(packageId);
            }
            return package;
        }

        /// <summary>
        /// get list of product codes
        /// </summary>
        /// <returns> list of product codes</returns>
        public static List<int> GetPackageIds()
        {
            List<int> id = new List<int>();
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                id = db.Packages.Select(p => p.PackageId).ToList();
            }
            return id;
        }

        /// <summary>
        /// adds new product
        /// </summary>
        /// <param name = "newProd" > product to add</param>
        public static void AddPackage(Package newPkg)
        {
            if (newPkg != null)
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    db.Packages.Add(newPkg);
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        ///  update existing product with new data 
        /// </summary>
        /// <param name = "newProdData" > new product data</param>
        public static void UpdatePackage(Package newPkgData)
        {
            if (newPkgData != null)
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    //find the product to update in this context
                   Package pkg = db.Packages.Find(newPkgData.PkgName);
                    if (pkg != null) // it still exists
                    {
                        //code does not change
                        pkg.PkgName = newPkgData.PkgName;
                        //prod.Version = newProdData.Version;
                        //prod.ReleaseDate = newProdData.ReleaseDate;
                        db.SaveChanges();
                    }
                }
            }
        }

        /// <summary>
        /// delete product
        /// </summary>
        /// <param name = "productCode" > code of the product to delete</param>
        public static void DeletePackage(string productId)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                Package pkg = db.Packages.Find(productId);
                if (pkg != null)
                {
                    db.Packages.Remove(pkg);
                    db.SaveChanges();
                }
            }
        }
    }
}
