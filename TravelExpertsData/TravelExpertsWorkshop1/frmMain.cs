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
    public partial class frmMain : Form
    {

        public Package addedPackage;
        public Product addedProduct;
        public Supplier addedSupplier;


        public frmMain()
        {
            InitializeComponent();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {

            frmSupplier secondForm = new frmSupplier();
            DialogResult result = secondForm.ShowDialog();
        }

        private void btnPackage_Click(object sender, EventArgs e)
        {
            frmPackages secondForm = new frmPackages();
            DialogResult result = secondForm.ShowDialog();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            frmProduct secondForm = new frmProduct();
            DialogResult result = secondForm.ShowDialog();
        }
    }
}
