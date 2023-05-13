using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using TravelExpertsData.Models;

namespace TravelExpertsData
{

    [Index("ProductId", Name = "ProductId")]
    public static class ProductDB
    {
        /// <summary>
        /// retrieves products data
        /// </summary>
        /// <returns>list of lightweight product objects</returns>
        public static List<ProductDTO> GetProducts()
        {
            List<ProductDTO> products = new List<ProductDTO>();// empty list
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                products = db.Products.
                    OrderBy(p => p.ProductId).
                    Select(p => new ProductDTO()
                    {
                        //ProductId = p.ProductId,
                        ProdName = p.ProdName
                    }).ToList();
            }
            return products;
        }

        /// <summary>
        /// find product by primary key value
        /// </summary>
        /// <param name="ProdName">code of the product to find</param>
        /// <returns>found product or null</returns>
        public static Product FindProduct(int productId)
        {
            Product Id = null;
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                Id = db.Products.Find(productId);
            }
            return Id;
        }

        //public static List<ProductDTO> GetProductsBySupName(string supName)
        //{
        //    // Initialize a list of Product objects to return
        //    List<ProductDTO> products = new List<ProductDTO>();
        //    using (TravelExpertsContext db = new TravelExpertsContext()) ;
        //    // Get the Category object with the given name
        //    supplier = db.Suppliers.FirstOrDefault(c => c.Name == supName);

        //    if (supplier != null)
        //    {
        //        // Get the list of products that belong to the category
        //        products = db.Products.Where(p => p.CategoryId == category.Id).ToList();
        //    }

        //    return products;
        //}
        /// <summary>
        /// get list of product codes
        /// </summary>
        /// <returns> list of product codes</returns>
        public static List<int> GetProductIds()
        {
            List<int> IDs = new List<int>();
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                IDs = db.Products.Select(p => p.ProductId).ToList();
            }
            return IDs;
        }

        ///// <summary>
        ///// adds new product
        ///// </summary>
        ///// <param name="newProd">product to add</param>
        public static void AddProduct(Product newProd)
        {
            if (newProd != null)
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    db.Products.Add(newProd);
                    db.SaveChanges();
                }
            }
        }

        ///// <summary>
        /////  update existing product with new data 
        ///// </summary>
        ///// <param name="newProdData">new product data</param>
        public static void UpdateProduct(Product newProdData)
        {
            if (newProdData != null)
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    // find the product to update in this context
                    Product prod = db.Products.Find(newProdData.ProductId);
                    if (prod != null) // it still exists
                    {
                        // code does not  change
                        //prod.Description = newProdData.Description;
                        //prod.UnitPrice = newProdData.UnitPrice;
                        //prod.OnHandQuantity = newProdData.OnHandQuantity;

                        prod.ProdName = newProdData.ProdName;
                        db.SaveChanges();
                    }
                }
            }
        }

        ///// <summary>
        ///// delete product
        ///// </summary>
        ///// <param name="productCode">code of the product to delete</param>
        public static void DeleteProduct(int productId)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                Product prod = db.Products.Find(productId);
                if (prod != null)
                {
                    db.Products.Remove(prod);
                    db.SaveChanges();
                }
            }
        }
    }
}
