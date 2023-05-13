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
    public partial class frmSupplier : Form
    {

        public Package addedPackage;
        public Product addedProduct;
        public Supplier addedSupplier;
        public bool isAdd;

        private const int MODIFY_INDEX = 2;
        private const int DELETE_INDEX = 3;

        public frmSupplier()
        {
            InitializeComponent();
        }


        private void frmSupplier_Load(object sender, EventArgs e)
        {
            DisplaySuppliers();
        }

        private void DisplaySuppliers()
        {
            dgvSuppliersData.Columns.Clear();
            dgvSuppliersData.Refresh();
            List<SupplierDTO> suppliers = new List<SupplierDTO>();
            using (var dbContext = new TravelExpertsContext())
            {
                suppliers = (//from pps in dbContext.PackagesProductsSuppliers
                             //join ps in dbContext.ProductsSuppliers on pps.ProductSupplierId equals ps.ProductSupplierId
                             //from ps in dbContext.ProductsSuppliers
                             //join s in dbContext.Suppliers on ps.SupplierId equals s.SupplierId
                             from s in dbContext.Suppliers
                             select new SupplierDTO
                             {
                                 SupplierId = s.SupplierId,
                                 SupName = s.SupName,

                             }).Distinct().ToList();
            }

            dgvSuppliersData.DataSource = suppliers;


            var modifyColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                Text = "Modify",
                HeaderText = ""
            };
            dgvSuppliersData.Columns.Add(modifyColumn);
            var deleteColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                Text = "Delete",
                HeaderText = ""
            };
            dgvSuppliersData.Columns.Add(deleteColumn);


            dgvSuppliersData.Columns[1].Width = 200;
        }


        private void dgvSuppliersData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // e.ColumnIndex is the column where the click happened
            // e.RowIndex is the row where the click happened
            if (e.RowIndex >= 0 && (e.ColumnIndex == MODIFY_INDEX || e.ColumnIndex == DELETE_INDEX))
            {
                int supplierID = Convert.ToInt32(dgvSuppliersData.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());
                addedSupplier = SupplierDB.FindSupplier(supplierID);

                try
                {
                    addedSupplier = SupplierDB.FindSupplier(supplierID);
                    if (addedSupplier != null)
                    {
                        if (e.ColumnIndex == MODIFY_INDEX)// Modify
                        {
                            ModifySupplier();
                        }
                        else // Delete
                        {
                            DeleteSupplier();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while finding a product: " +
                        ex.Message, ex.GetType().ToString());
                }
            }
        }

        private void ModifySupplier()
        {
            frmAddSupplier secondForm = new frmAddSupplier();
            secondForm.isAdd = false; // modify
            secondForm.addedSupplier = addedSupplier;
            DialogResult result = secondForm.ShowDialog();
            if (result == DialogResult.OK) // proceeding with modification
            {
                addedSupplier = secondForm.addedSupplier; // new data values being added
                try
                {
                    SupplierDB.UpdateSupplier(addedSupplier);
                    DisplaySuppliers();
                }
                catch (DbUpdateException ex) // errors coming from SaveChanges
                {
                    string errorMessage = "Error(s) while modifying product:\n";
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
                    MessageBox.Show("Database connection lost while modifying a product." +
                        " Try again later");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while modifying a product: " +
                        ex.Message, ex.GetType().ToString());
                }
            }
        }


        // deleting current/existing product in the table
        private void DeleteSupplier()
        {
            if (addedSupplier != null)
            {
                DialogResult result = MessageBox.Show(
                    $"Do you want to delete {addedSupplier.SupName} with the ID: {addedSupplier.SupplierId}?",
                    "Confirm delete", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result == DialogResult.Yes)// user confirmed
                {
                    try
                    {
                        SupplierDB.DeleteSupplier(addedSupplier.SupplierId);
                        DisplaySuppliers(); // refresh grid
                    }
                    catch (DbUpdateException ex) // errors coming from SaveChanges
                    {
                        string errorMessage = "Error(s) while deleting product:\n";
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
                        MessageBox.Show("Database connection lost while deleting a product." +
                            " Try again later");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error while deleting a product: " +
                            ex.Message, ex.GetType().ToString());
                    }
                }
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddSupplier secondForm = new frmAddSupplier();
            secondForm.isAdd = true;
            secondForm.addedSupplier = null;
            DialogResult result = secondForm.ShowDialog();
            if (result == DialogResult.OK) // proceed with add
            {
                addedSupplier = secondForm.addedSupplier;
                if (addedSupplier != null)
                {
                    try
                    {
                        SupplierDB.AddSupplier(addedSupplier);
                        DisplaySuppliers(); // refresh grid
                    }
                    catch (DbUpdateException ex) // errors coming from SaveChanges
                    {
                        string errorMessage = "Error(s) while adding supplier:\n";
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
                        MessageBox.Show("Database connection lost while adding a supplier. Try again later");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error while adding a supplier: " +
                            ex.Message, ex.GetType().ToString());
                    }
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
