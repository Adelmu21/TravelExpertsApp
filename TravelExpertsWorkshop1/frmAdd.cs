using System;
using System.Collections.Generic;
using System.ComponentModel;
//using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TravelExpertsData;

namespace TravelExpertsWorkshop1
{
    public partial class frmAdd : Form
    {

        public Package addedPackage;
        public Product addedProduct;
        public Supplier addedSupplier;
        public Package updatedPackage;

        public bool isAdd;

        public frmAdd()
        {
            InitializeComponent();
        }



        private void frmAdd_Load(object sender, EventArgs e)
        {
            cmbProduct.SelectedIndex = -1;
            DisplayPackage();
            
            List<ProductsSuppliersDTO> prodSup = ProductsSuppliersDB.GetPS();
            cmbSupplier.DataSource = prodSup;
            cmbSupplier.DisplayMember = "SupName";
            cmbSupplier.ValueMember = "SupplierId";

            //cmbFirstSupplier.SelectedValue = suppliers;
            //cmbFirstSupplier.Text = addedSupplier.SupName;
            cmbProduct.DataSource = prodSup.DistinctBy(p => p.ProdName).ToList();
            //cmbProduct.DataSource = prodSup;
            cmbProduct.DisplayMember = "ProdName";
            cmbProduct.ValueMember = "ProductId";
            //cmbProduct.SelectedValue = "ProdName";
        }




        private void DisplayPackage()
        {
            if (addedPackage != null)
            {
                txtPkgID.Text = addedPackage.PackageId.ToString();

                List<ProductsSuppliersDTO> prodSup = ProductsSuppliersDB.GetPS();
                cmbSupplier.DataSource = prodSup;
                cmbSupplier.DisplayMember = "SupName";
                cmbSupplier.ValueMember = "SupplierId";

                //cmbFirstSupplier.SelectedValue = suppliers;
                //cmbFirstSupplier.Text = addedSupplier.SupName;
                cmbProduct.DataSource = prodSup.DistinctBy(p => p.ProdName).ToList();
                //cmbProduct.DataSource = prodSup;
                cmbProduct.DisplayMember = "ProdName";
                cmbProduct.ValueMember = "ProductId";
                //cmbProduct.SelectedValue = "ProdName";

            }
        }




        private void cmbProduct_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //Get the selected ProductSupplierDTO object
            ProductsSuppliersDTO selectedProduct = (ProductsSuppliersDTO)cmbProduct.SelectedItem;

            //Clear the supplierComboBox
            //cmbSupplier.Items.Clear();
            cmbSupplier.DataSource = null;
            cmbSupplier.SelectedIndex = -1;
            cmbSupplier.Items.Clear();


            //Retrieve the suppliers for the selected product

            List<Supplier> suppliers = new List<Supplier>();
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                suppliers = (
                    from ps in db.ProductsSuppliers
                    join s in db.Suppliers on ps.SupplierId equals s.SupplierId
                    where ps.ProductId == selectedProduct.ProductId
                    orderby s.SupName
                    select s
                ).ToList();
            }

            //Populate the supplierComboBox with supplier names separated by a line break
            StringBuilder supplierNames = new StringBuilder();
            cmbSupplier.DropDownStyle = ComboBoxStyle.DropDown;
            foreach (Supplier supplier in suppliers)
            {
                cmbSupplier.Items.Add(supplier.SupName);
            }

            //cmbFirstSupplier.Text = supplierNames.ToString();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            bool valid = true;
            //if (isAdd) // validate code
            //{
            //    if (Validator.IsSelected(cmbProduct))
            //    {
            //        // check if unique
            //        int ID = addedSupplier.SupplierId;
            //        List<int> IDs = SupplierDB.GetSupplierIds();
            //        foreach (int i in IDs)
            //        {
            //            if (i == ID)
            //            {
            //                MessageBox.Show($"Duplicate supplier ID: {ID}");
            //                valid = false; // found duplicate
            //            }
            //        }
            //    }
            //    else // empty string
            //    {
            //        valid = false;
            //    }
            //}
            // Combo boxes Validation
            if (valid &&
                Validator.IsSelected(cmbProduct) &&
                Validator.IsSelected(cmbSupplier)
              )
            {


                if (isAdd) // creating a new object
                {
                    addedProduct = new Product();
                    addedSupplier = new Supplier();
                    addedPackage = new Package();
                }

                // Adding data

                addedProduct.ProdName = cmbProduct.Text;
                addedSupplier.SupName = cmbSupplier.Text;
                string selectedProduct = addedProduct.ProdName;
                string selectedSupplier = addedSupplier.SupName;
                string selectedProductAndSupplier = string.Format("{0,0}{1,0}", selectedProduct.PadRight(50), selectedSupplier);

                frmDetails detailsForm = (frmDetails)Application.OpenForms["frmDetails"];
                detailsForm.selectedProductsAndSuppliers.Add(selectedProductAndSupplier);




                DialogResult = DialogResult.OK;
            }




            //// create or get existing Product and Supplier objects
            //var product = context.Products.FirstOrDefault(p => p.ProdName == cmbProduct.Text)
            //              ?? new Product { ProdName = cmbProduct.Text };
            //var supplier = context.Suppliers.FirstOrDefault(s => s.SupName == cmbSupplier.Text)
            //               ?? new Supplier { SupName = cmbSupplier.Text };

            //// create a new PackagesProductsSuppliers object and add it to the context
            //var pps = new PackagesProductsSupplier
            //{
            //    PackageId = addedPackage.PackageId,
            //    ProductSupplier = new ProductsSupplier { Product = product, Supplier = supplier }
            //};
            //context.PackagesProductsSuppliers.Add(pps);

            //// save changes
            //context.SaveChanges();

            //string selectedProduct = addedProduct.ProdName;
            //string selectedSupplier = addedSupplier.SupName;
            //string selectedProductAndSupplier = string.Format("{0,0}{1,0}", selectedProduct.PadRight(50), selectedSupplier);

            //frmDetails detailsForm = (frmDetails)Application.OpenForms["frmDetails"];
            //detailsForm.selectedProductsAndSuppliers.Add(selectedProductAndSupplier);



            //bool valid = true;
            //if (isAdd) // validate code
            //{
            //    if (Validator.IsSelected(cmbPkgID))
            //    {
            //        // check if unique

            //        int pkg = addedPackage.PackageId;
            //        List<int> pkgs = PackageDB.GetPackageIds();
            //        foreach (int p in pkgs)
            //        {
            //            if (p == pkg)
            //            {
            //                MessageBox.Show($"Duplicate package ID: {pkg}");
            //                valid = false; // found duplicate
            //            }
            //        }
            //    }
            //    else // empty string
            //    {
            //        valid = false;
            //    }
            //    // for both Add and Modify
            //    // input TextBoxes Validation
            //    if (valid &&
            //        Validator.IsSelected(cmbPkgID) &&
            //        Validator.IsSelected(cmbPkgName) &&
            //        Validator.IsSelected(cmbFirstSupplier) &&
            //        Validator.IsSelected(cmbSecondSupplier) &&
            //        Validator.IsSelected(cmbFirstProduct) &&
            //        Validator.IsSelected(cmbSecondProduct)
            //      )
            //    {
            //        if (isAdd) // creating a new object
            //        {
            //            addedPackage = new Package();
            //        }
            //        // Adding data
            //        //addedPackage.PackageId = Convert.ToInt32(cmbPkgID.Text);

            //        List<PackageDTO> packages = PackageDB.GetPackages();
            //        cmbPkgID.DataSource = packages;
            //        cmbPkgID.DisplayMember = "PackageId";
            //        cmbPkgID.ValueMember = "PackageId";


            //        //addedPackage.PkgName = cmbPkgName.Text;
            //        //addedPackage.PkgStartDate = Convert.ToDateTime(dtpEndDate.Text);
            //        //addedPackage.PkgEndDate = Convert.ToDateTime(dtpEndDate.Text);
            //        //addedProduct.ProdName = cmbFirstProduct.Text;
            //        //addedSupplier.SupName = cmbFirstSupplier.Text;

            //        List<SupplierDTO> suppliers = SupplierDB.GetSuppliers();
            //        cmbFirstSupplier.DataSource = suppliers;
            //        cmbFirstSupplier.DisplayMember = "SupName";
            //        cmbFirstSupplier.ValueMember = "SupplierId";


            //        //addedProduct.ProdName = cmbSecondProduct.Text;
            //        //addedSupplier.SupName = cmbSecondSupplier.Text;

            //        DialogResult = DialogResult.OK;
            //    }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }








        //List<SupplierDTO> suppliers = SupplierDB.GetSuppliers();
        //cmbSupplier.DataSource = suppliers;
        //cmbSupplier.DisplayMember = "SupName";
        //cmbSupplier.ValueMember = "SupplierId";
        //cmbFirstSupplier.SelectedValue = suppliers;
        //cmbFirstSupplier.Text = addedSupplier.SupName;


        //List<ProductDTO> products = ProductDB.GetProducts();
        //cmbProduct.DataSource = products;
        //cmbProduct.DisplayMember = "ProdName";
        //cmbProduct.ValueMember = "ProductId";
        //cmbProduct.SelectedValue = "ProdName";



        //comboBox1.DataSource = dataSet1.Tables["Suppliers"];
        //comboBox1.DisplayMember = "ProductName";


        //var suppliers = travelExpertsContext.Suppliers.ToList();
        //cmbFirstSupplier.DataSource = suppliers;
        //cmbFirstSupplier.DisplayMember = "SupName";
        //cmbFirstSupplier.ValueMember = "SupplierId";



        //private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    //cmbSupplier.Items.Clear();

        //    int supplierId = Convert.ToInt32(cmbProduct.SelectedValue);
        //    //int supplierId = Convert.ToInt32(cmbFirstSupplier.SelectedValue);
        //    var dbContext = new TravelExpertsContext();
        //    // Filter the products based on the selected supplier name
        //    var products = from ps in dbContext.ProductsSuppliers
        //                   join p in dbContext.Products on ps.ProductId equals p.ProductId
        //                   join s in dbContext.Suppliers on ps.SupplierId equals s.SupplierId
        //                   where s.SupplierId == supplierId
        //                   select ps;
        //    //from ps in dbContext.ProductsSuppliers
        //    //join p in dbContext.Products on ps.ProductId equals p.ProductId
        //    //join s in dbContext.Suppliers on ps.SupplierId equals s.SupplierId
        //    //where p.ProductId == supplierId
        //    //select p;


        //    foreach (var product in products)
        //    {
        //        cmbProduct.Items.Add(product.SupplierId);
        //    }

        //    //{
        //    //    string supplierName = cmbSupplier.SelectedValue.ToString();
        //    //    //int supplierId = Convert.ToInt32(cmbFirstSupplier.SelectedValue);
        //    //    var dbContext = new TravelExpertsContext();
        //    //    // Filter the products based on the selected supplier name
        //    //    var products = from p in dbContext.Products
        //    //                   where p.ProdName == supplierName
        //    //                   select p;



        //    //    foreach (var product in products)
        //    //    {
        //    //        cmbProduct.Items.Add(product.ProdName);
        //    //    }
        //    //}


    }
}
