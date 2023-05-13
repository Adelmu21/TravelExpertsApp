using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelExpertsData.Models;


namespace TravelExpertsData
{
    public class ProductsSuppliersDB
    {
        public static List<ProductsSuppliersDTO> GetPS()
        {

            List<ProductsSuppliersDTO> prodSup = new List<ProductsSuppliersDTO>();// empty list
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                
                prodSup = ( from ps in db.ProductsSuppliers 
                            join p in db.Products on ps.ProductId equals p.ProductId
                            join s in db.Suppliers on ps.SupplierId equals s.SupplierId
                            //where s.SupplierId == ps.SupplierId

                            orderby p.ProdName, s.SupName
                            //group s.SupName by p.ProdName into g
                            select new ProductsSuppliersDTO
                            {
                                ProductId = p.ProductId,
                                ProdName = p.ProdName,
                                SupplierId = ps.SupplierId,
                                SupName = s.SupName,
                                ProductSupplierId = ps.ProductSupplierId,

                                //ProdName = g.Key,
                                //SupName = string.Join(Environment.NewLine, g.ToArray())


                            }).ToList();

            }

            return prodSup;
        }


    }
}




    //SupName = p.SupplierId.ToString(),

