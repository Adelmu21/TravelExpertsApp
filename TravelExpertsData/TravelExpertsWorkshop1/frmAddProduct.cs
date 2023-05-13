using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TravelExpertsData;

namespace TravelExpertsWorkshop1
{
    public partial class frmAddProduct : Form
    {
        public Package addedPackage;
        public Product addedProduct;
        public Supplier addedSupplier;
        public bool isAdd;


        public frmAddProduct()
        {
            InitializeComponent();
        }

        private void frmAddProduct_Load(object sender, EventArgs e)
        {
            if (isAdd) // Add
            {
                this.Text = "Add Supplier";
                txtProductID.Enabled = true;
            }
            else // Modify
            {
                this.Text = "Modify Supplier";
                DisplayProduct();
                txtProductID.Enabled = false;
            }
        }


        private void DisplayProduct()
        {
            if (addedProduct != null)
            {
                txtProductID.Text = addedProduct.ProductId.ToString();
                txtProductName.Text = addedProduct.ProdName;
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            bool valid = true;
            if (isAdd) // validate code
            {
                if (Validator.IsPresent(txtProductID))
                {
                    // check if unique
                    int ID = int.Parse(txtProductID.Text);
                    List<int> IDs = ProductDB.GetProductIds();
                    foreach (int i in IDs)
                    {
                        if (i == ID)
                        {
                            MessageBox.Show($"Duplicate product code: {ID}");
                            valid = false; // found duplicate
                        }
                    }
                }
                else // empty string
                {
                    valid = false;
                }
            }
            // for both Add and Modify
            // input TextBoxes Validation
            if (valid &&
                Validator.IsPresent(txtProductID) &&
                Validator.IsNonNegativeDecimal(txtProductID) &&
                Validator.IsPresent(txtProductName)
               )
            {
                if (isAdd) // creating a new object
                {
                    addedProduct = new Product();
                }
                // Adding data
                //addedSupplier.SupplierId = int.Parse(txtSupplierID.Text.ToString());
                addedProduct.ProductId = Convert.ToInt32(txtProductID.Text);
                addedProduct.ProdName = txtProductName.Text;

                DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
