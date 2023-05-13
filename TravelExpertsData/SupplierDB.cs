using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace TravelExpertsData
{

    public class SupplierDB
    {
        /// <summary>
        /// retrieves suppliers data
        /// </summary>
        /// <returns>list of lightweight supplier objects</returns>
        public static List<SupplierDTO> GetSuppliers()
        {
            List<SupplierDTO> suppliers = new List<SupplierDTO>();// empty list
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                suppliers = db.Suppliers.
                    OrderBy(s => s.SupplierId).
                    Select(s => new SupplierDTO()
                    {
                        //ProductId = p.ProductId,
                        SupName = s.SupName
                    }).ToList();
            }
            return suppliers;
        }

        public static Supplier FindSupplier(int supplierId)
        {
            Supplier id = null;
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                id = db.Suppliers.Find(supplierId);
            }
            return id;
        }

        //public static Supplier FindSupplier(string supplierID)
        //{
        //    int id = int.Parse(supplierID);
        //    using (var context = new TravelExpertsContext())
        //    {
        //        return context.Suppliers.Find(id);
        //    }
        //}

        //public static void SaveProducts(List<Product> products)
        //{
        //    // create the output stream for a text file that exists
        //    StreamWriter textOut =
        //        new StreamWriter(
        //            new FileStream(path, FileMode.Create, FileAccess.Write));

        //    // write each product
        //    foreach (Product product in products)
        //    {
        //        if (product.GetType().Name == "Book")
        //            WriteBook((Book)product, textOut);
        //        else if (product.GetType().Name == "Software")
        //            WriteSoftware((Software)product, textOut);
        //    }
        //    // write the end of the document
        //    textOut.Close();

        //}


        /// <summary>
        /// get list of product codes
        /// </summary>
        /// <returns> list of product codes</returns>
        public static List<int> GetSupplierIds()
        {
            List<int> IDs = new List<int>();
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                IDs = db.Suppliers.Select(s => s.SupplierId).ToList();
            }
            return IDs;
        }



        ///// <summary>
        ///// adds new product
        ///// </summary>
        ///// <param name="newProd">product to add</param>
        public static void AddSupplier(Supplier newSup)
        {
            if (newSup != null)
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    db.Suppliers.Add(newSup);
                    db.SaveChanges();
                }
            }
        }


        /// <summary>
        ///  update existing product with new data 
        /// </summary>
        /// <param name="newProdData">new product data</param>
        public static void UpdateSupplier(Supplier newSupData)
        {
            if (newSupData != null)
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    // find the product to update in this context
                    Supplier sup = db.Suppliers.Find(newSupData.SupplierId);
                    if (sup != null) // it still exists
                    {
                        // code does not  change
                        sup.SupName = newSupData.SupName;
                        db.SaveChanges();
                    }
                }
            }
        }



        /// <summary>
        /// delete product
        /// </summary>
        /// <param name="productCode">code of the product to delete</param>
        public static void DeleteSupplier(int supplierID)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                Supplier sup = db.Suppliers.Find(supplierID);
                if (sup != null)
                {
                    db.Suppliers.Remove(sup);
                    db.SaveChanges();
                }
            }
        }



        //public static List<string> GetSupplier()
        //{
        //    List<string> codes = new List<string>();
        //    using (TechSupportContext db = new TechSupportContext())
        //    {
        //        codes = db.Products.Select(p => p.ProductCode).ToList();
        //    }
        //    return codes;
        //}

    }
}