using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TravelExpertsData;

namespace TravelExpertsWorkshop1
{
    public partial class frmDetails : Form
    {
        public Package addedPackage;
        public Product addedProduct;
        public Supplier addedSupplier;

        public List<string> selectedProductsAndSuppliers = new List<string>();
        List<Product> products = new List<Product>();
        public frmDetails()
        {

            InitializeComponent();

        }


        private void frmDetails_Load(object sender, EventArgs e)
        {
            DisplayPackage1();

            foreach (string productAndSupplier in selectedProductsAndSuppliers)
            {
                lstSupProd.Items.Add(productAndSupplier);
            }
        }





        private void DisplayPackage1()
        {

            if (addedPackage != null)
            {

                txtPkgID.Text = addedPackage.PackageId.ToString();
                txtPkgName.Text = addedPackage.PkgName;
                txtPkgPrice.Text = addedPackage.PkgBasePrice.ToString("f2");

                using (var context = new TravelExpertsContext())
                {
                    var productSuppliers = (
                        from pps in context.PackagesProductsSuppliers
                        join ps in context.ProductsSuppliers on pps.ProductSupplierId equals ps.ProductSupplierId
                        join p in context.Products on ps.ProductId equals p.ProductId
                        join s in context.Suppliers on ps.SupplierId equals s.SupplierId
                        where pps.PackageId == addedPackage.PackageId // filter by selected package ID
                        select new { ProductName = p.ProdName, SupplierName = s.SupName }
                        //orderby p.ProdName, s.SupName
                        //group s.SupName by p.ProdName into g
                        //orderby g.Key
                        //select new { ProductName = g.Key, Suppliers = g.ToList() }
                    ).ToList();
                    lstSupProd.ColumnWidth = 200;
                    lstSupProd.Items.Clear(); // clear previous items in the list box

                    string columnHeader = string.Format("{0,50}{1,0}", "Product Name".PadRight(40), "Supplier Name");
                    lstSupProd.Items.Add(columnHeader);
                    lstSupProd.Items.Add("");

                    foreach (var f in productSuppliers)
                    {

                        string item = String.Format("{0,0}{1,0}", f.ProductName.PadRight(50), f.SupplierName);
                        lstSupProd.Items.Add(item);


                        //lstSupProd.Items.Add($". {f.ProductName} \n\t {f.SupplierName}");

                        //lstSupProd.Items.Add($" {f.SupplierName}");


                        //foreach (var supplier in f.Suppliers)
                        //{
                        //    lstSupProd.Items.Add($"\t\t {supplier}");

                        //}

                    }

                    foreach (string productAndSupplier in selectedProductsAndSuppliers)
                    {
                        lstSupProd.Items.Add(productAndSupplier);
                    }


                    //lstSupProd.MouseDoubleClick += (s, e) =>
                    //{
                    //    if (lstSupProd.SelectedItem != null)
                    //    {
                    //        string selectedItemText = lstSupProd.SelectedItem.ToString();

                    //        //If the selected item is a product, replace it with its suppliers
                    //        if (selectedItemText.StartsWith(""))
                    //        {
                    //            string productName = selectedItemText.Substring("".Length);
                    //            var product = productSuppliers.FirstOrDefault(p => p.ProductName == productName);

                    //            if (product != null)
                    //            {
                    //                int productIndex = lstSupProd.Items.IndexOf(selectedItemText);

                    //                Remove the product and its suppliers from the list box
                    //                lstSupProd.Items.RemoveAt(productIndex);
                    //                lstSupProd.Items.RemoveRange(productIndex, product.Suppliers.Count);

                    //                Add the suppliers of the product to the list box
                    //                foreach (var supplier in product.SupplierName)
                    //                {
                    //                    lstSupProd.Items.Insert(productIndex++, $"\tSupplier: {supplier}");
                    //                }
                    //            }
                    //        }

                    //        //If the selected item is a supplier, replace it with its products
                    //        else if (selectedItemText.StartsWith("\tSupplier:"))
                    //        {
                    //            string supplierName = selectedItemText.Substring("\tSupplier: ".Length);
                    //            var products = productSuppliers.Where(p => p.SupplierName.Contains(supplierName));

                    //            if (products.Any())
                    //            {
                    //                int supplierIndex = lstSupProd.Items.IndexOf(selectedItemText);

                    //                Remove the supplier and its products from the list box
                    //                lstSupProd.Items.RemoveAt(supplierIndex);
                    //                lstSupProd.Items.RemoveRange(supplierIndex, products.Count());

                    //                //Add the products of the supplier to the list box
                    //                foreach (var product in products)
                    //                {
                    //                    lstSupProd.Items.Insert(supplierIndex++, $". {product.ProductName}");
                    //                }
                    //            }
                    //        }
                    //    }
                    //};



                    //select new { ProductName = p.ProdName, SupplierName = s.SupName }
                    //group new { p.ProdName, s.SupName } by p.ProdName into g
                    //select new { ProductName = g.Key, SupplierName = string.Join(", ", g.Select(x => x.SupName)) }

                    //foreach (var f in productSuppliers)
                    //{
                    //    //lstSupProd.Items.Add($"{f.ProductName}: {f.SupplierName}");

                    //    lstSupProd.Items.Add($"Product: {f.ProductName}");
                    //    lstSupProd.Items.Add($"Suppliers: {f.SupplierNames}");
                    //    lstSupProd.Items.Add(""); // add an empty line to separate the groups
                    //}
                }




            }


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            frmAdd secondForm = new frmAdd();
            secondForm.isAdd = true;
            secondForm.addedProduct = null;
            DialogResult result = secondForm.ShowDialog();
            if (result == DialogResult.OK) // proceed with add
            {
                //lstSupProd.Items.Clear();
                //lstSupProd.Refresh();
                //addedPackage = secondForm.addedPackage;
                addedProduct = secondForm.addedProduct;
                //addedSupplier = secondForm.addedSupplier;
                if (addedPackage != null)
                {

                    try
                    {
                        ProductDB.AddProduct(addedProduct);
                        //PackageDB.AddPackage(addedPackage);
                        //ProductDB.AddProduct(addedProduct);
                        //SupplierDB.AddSupplier(addedSupplier);
                        DisplayPackage1(); // refresh grid
                    }
                    catch (DbUpdateException ex) // errors coming from SaveChanges
                    {
                        string errorMessage = "Error(s) while adding product:\n";
                        var sqlException = (SqlException)ex.InnerException;
                        foreach (SqlError error in sqlException.Errors)
                        {
                            errorMessage += "ERROR CODE:  " + error.Number +
                                            " " + error.Message + "\n";
                        }
                        MessageBox.Show(errorMessage);
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Database connection lost while adding a product. Try again later");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error while adding a product: " +
                            ex.Message, ex.GetType().ToString());
                    }
                }
            }
        }

        public void lstSupProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            //foreach (string productAndSupplier in selectedProductsAndSuppliers)
            //{
            //    lstSupProd.Items.Add(productAndSupplier);
            //}

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedIndex = lstSupProd.SelectedIndex;
            if (selectedIndex < 0 || selectedIndex >= products.Count) // no selection
            {
                MessageBox.Show("You need to select a product");
            }
            else // there is a selected product
            {
                Product selectedProduct = products[selectedIndex];
                DialogResult result = MessageBox.Show
                    ($"Do you want to delete {selectedProduct.ProdName}?",
                    "Confirm Delete", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    products.RemoveAt(selectedIndex);
                    // update display
                    DisplayPackage1();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        //List<CombinedDataModel> combinedDataList = new List<CombinedDataModel>();
        //// which package
        //using (var dbContext = new TravelExpertsContext())
        //{
        //    combinedDataList = (from pps in dbContext.PackagesProductsSuppliers
        //                        join ps in dbContext.ProductsSuppliers on pps.ProductSupplierId equals ps.ProductSupplierId
        //                        join p in dbContext.Products on ps.ProductId equals p.ProductId
        //                        join s in dbContext.Suppliers on ps.SupplierId equals s.SupplierId
        //                        join pkg in dbContext.Packages on pps.PackageId equals pkg.PackageId
        //                        //where 
        //                        select new CombinedDataModel
        //                        {
        //                            PackageId = pkg.PackageId,
        //                            PkgName = pkg.PkgName,
        //                            ProdName = p.ProdName,
        //                            SupName = s.SupName,
        //                        }).ToList();
        //}

        //// Populate the list box with the products and suppliers
        //lstSupProd.DataSource = combinedDataList;

        //using (var context = new TravelExpertsContext())
        //{
        //    lstSupProd.Items.Clear();

        //    //var packages = context.PackagesProductsSuppliers.ToList();
        //    var packageId = context.Packages.ToList();
        //    var selectedPackageId = lstSupProd.SelectedIndex;
        //    //addedPackage = PackageDB.FindPackage(packageId);
        //    foreach (var ppss in packageId)
        //    {

        //        var productSuppliers = (
        //            from pps in context.PackagesProductsSuppliers
        //            join ps in context.ProductsSuppliers on pps.ProductSupplierId equals ps.ProductSupplierId
        //            join p in context.Products on ps.ProductId equals p.ProductId
        //            join s in context.Suppliers on ps.SupplierId equals s.SupplierId
        //            where pps.PackageId == ppss.PackageId
        //            orderby p.ProdName, s.SupName
        //            select new { ProductName = p.ProdName, SupplierName = s.SupName }
        //        ).ToList();

        //        //foreach (var ps in productSuppliers)
        //        //        {
        //        //            lstSupProd.Items.Add($"{ps.ProductName}: {ps.SupplierName}");
        //        //        }
        //        //foreach (var p in productSuppliers)
        //        //{
        //        //    lstSupProd.Items.Add($"{p.ProductName}: {p.SupplierName}");
        //        //}
        //        foreach (var f in productSuppliers)
        //        {
        //            lstSupProd.Items.Add($"{f.ProductName}: {f.SupplierName}");
        //        }
        //        //var productSupplierStrings = productSuppliers
        //        //      .GroupBy(ps => ps.ProductName)
        //        //      .Select(g => $"{g.Key}: {string.Join(" \n ", g.Select(ps => ps.SupplierName))}")
        //        //      .ToList();

        //        //var packageString = $"{string.Join("; ", productSupplierStrings)}";

        //        //    lstSupProd.Items.Add(packageString);
        //    }
        //}









        //public void UpdateListBox(int packageId)
        //{
        //    lstSupProd.Items.Clear(); // clear the list box

        //    using (var context = new TravelExpertsContext())
        //    {
        //        var productSuppliers = (
        //            from pps in context.PackagesProductsSuppliers
        //            join ps in context.ProductsSuppliers on pps.ProductSupplierId equals ps.ProductSupplierId
        //            join p in context.Products on ps.ProductId equals p.ProductId
        //            join s in context.Suppliers on ps.SupplierId equals s.SupplierId
        //            where pps.PackageId == packageId
        //            orderby p.ProdName, s.SupName
        //            select new { ProductName = p.ProdName, SupplierName = s.SupName }
        //        ).ToList();

        //        foreach (var ps in productSuppliers)
        //        {
        //            lstSupProd.Items.Add($"{ps.ProductName}: {ps.SupplierName}");
        //        }
        //    }
        //}


        // Populate the list box with the data
        //lstSupProd.Items.Add("Product Name: " + addedProduct.ProdName);
        //lstSupProd.Items.Add("Supplier Name: " + addedSupplier.SupName);


        //using (var context = new TravelExpertsContext())
        //{
        //    var packages = context.Packages.ToList();

        //    foreach (var package in packages)
        //    {
        //        var productSuppliers = (
        //            from pps in context.PackagesProductsSuppliers
        //            join ps in context.ProductsSuppliers on pps.ProductSupplierId equals ps.ProductId
        //            join p in context.Products on ps.ProductId equals p.ProductId
        //            join s in context.Suppliers on ps.SupplierId equals s.SupplierId
        //            where pps.PackageId == package.PackageId
        //            orderby p.ProdName, s.SupName
        //            select new { ProductName = p.ProdName, SupplierName = s.SupName }
        //        ).ToList();

        //        var productSupplierStrings = productSuppliers
        //            .GroupBy(ps => ps.ProductName)
        //            .Select(g => $"{g.Key}: {string.Join(" \n ", g.Select(ps => ps.SupplierName))}")
        //            .ToList();

        //        var packageString = $"{package.PkgName}: {string.Join("; ", productSupplierStrings)}";

        //        lstSupProd.Items.Add(packageString);
        //    }
        //}


        //List<PackageDTO> packages = PackageDB.GetPackages();
        //txtPkgID.Text = addedPackage.PackageId.ToString();
        //txtPkgName.Text = addedPackage.PkgName;

        //List<PackagesProductsSuppliersDTO> productsSuppliers = PackagesProductsSuppliersDB.GetPPS();
        ////foreach (SupplierDTO supplier in suppliers)
        ////    base.Add(supplier);

        //lstSupProd.DataSource = productsSuppliers;
        //lstSupProd.DisplayMember = "SupName";



        //foreach (PackagesProductsSuppliersDTO p in suppliers)
        //{
        //    lstSupProd.Items.Add(p);
        //}
        //lstSupProd.Text = addedSupplier.SupName;
        //lstSupProd.ValueMember = "SupplierId";
        //lstSupProd.Items.Add("SupName");
        //lstSupProd.SelectedValue = suppliers;
        //lstSupProd.Text = addedSupplier.SupName;

        //lstSupProd.Items.Clear();
        //foreach (PackagesProductsSuppliersDTO s in suppliers)
        //{
        //    lstSupProd.SelectedIndexChanged(s);
        //}

        //List<ProductDTO> products = ProductDB.GetProducts();
        //lstSupProd.DataSource = products;
        //lstSupProd.DisplayMember = "ProdName";
        //lstSupProd.ValueMember = "ProductId";
        ////cmbFirstProduct.SelectedValue = "ProductId";

        //comboBox1.DataSource = dataSet1.Tables["Suppliers"];
        //comboBox1.DisplayMember = "ProductName";

        //var suppliers = travelExpertsContext.Suppliers.ToList();
        //cmbFirstSupplier.DataSource = suppliers;
        //cmbFirstSupplier.DisplayMember = "SupName";
        //cmbFirstSupplier.ValueMember = "SupplierId";


    }
}
