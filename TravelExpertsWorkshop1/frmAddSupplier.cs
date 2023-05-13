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
    public partial class frmAddSupplier : Form
    {
        public Package addedPackage;
        public Product addedProduct;
        public Supplier addedSupplier;
        public bool isAdd;


        public frmAddSupplier()
        {
            InitializeComponent();
        }

        private void frmAddSupplier_Load(object sender, EventArgs e)
        {
            if (isAdd) // Add
            {
                this.Text = "Add Supplier";
                txtSupplierID.Enabled = true;
            }
            else // Modify
            {
                this.Text = "Modify Supplier";
                DisplaySupplier();
                txtSupplierID.Enabled = false;
            }
        }


        private void DisplaySupplier()
        {
            if (addedSupplier != null)
            {
                txtSupplierID.Text = addedSupplier.SupplierId.ToString();
                txtSupplierName.Text = addedSupplier.SupName;
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            bool valid = true;
            if (isAdd) // validate code
            {
                if (Validator.IsPresent(txtSupplierID))
                {
                    // check if unique
                    int ID = int.Parse(txtSupplierID.Text);
                    List<int> IDs = SupplierDB.GetSupplierIds();
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
                Validator.IsPresent(txtSupplierID) &&
                Validator.IsNonNegativeDecimal(txtSupplierID) &&
                Validator.IsPresent(txtSupplierName)
               )
            {
                if (isAdd) // creating a new object
                {
                    addedSupplier = new Supplier();
                }
                // Adding data
                //addedSupplier.SupplierId = int.Parse(txtSupplierID.Text.ToString());
                addedSupplier.SupplierId = Convert.ToInt32(txtSupplierID.Text);
                addedSupplier.SupName = txtSupplierName.Text;

                DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
