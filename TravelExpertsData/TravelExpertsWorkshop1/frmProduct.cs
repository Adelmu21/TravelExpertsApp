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
    public partial class frmProduct : Form
    {

        public Package addedPackage;
        public Product addedProduct;
        public Supplier addedSupplier;
        public bool isAdd;

        private const int MODIFY_INDEX = 2;
        private const int DELETE_INDEX = 3;

        public frmProduct()
        {
            InitializeComponent();
        }



        private void frmProduct_Load(object sender, EventArgs e)
        {
            DisplayProducts();
        }




        private void DisplayProducts()
        {
            dgvProductsData.Columns.Clear();
            dgvProductsData.Refresh();
            List<ProductDTO> products = new List<ProductDTO>();
            using (var dbContext = new TravelExpertsContext())
            {
                products = (//from pps in dbContext.PackagesProductsSuppliers
                            //join ps in dbContext.ProductsSuppliers on pps.ProductSupplierId equals ps.ProductSupplierId
                            //from ps in dbContext.ProductsSuppliers
                            //join s in dbContext.Suppliers on ps.SupplierId equals s.SupplierId
                             from s in dbContext.Products
                             select new ProductDTO
                             {
                                 ProductId = s.ProductId,
                                 ProdName = s.ProdName,

                             }).Distinct().ToList();
            }

            dgvProductsData.DataSource = products;


            var modifyColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                Text = "Modify",
                HeaderText = ""
            };
            dgvProductsData.Columns.Add(modifyColumn);
            var deleteColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                Text = "Delete",
                HeaderText = ""
            };
            dgvProductsData.Columns.Add(deleteColumn);


            dgvProductsData.Columns[1].Width = 150;
        }

        private void dgvProductsData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // e.ColumnIndex is the column where the click happened
            // e.RowIndex is the row where the click happened
            if (e.RowIndex >= 0 && (e.ColumnIndex == MODIFY_INDEX || e.ColumnIndex == DELETE_INDEX))
            {
                int productId = Convert.ToInt32(dgvProductsData.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());
                addedProduct = ProductDB.FindProduct(productId);

                try
                {
                    addedProduct = ProductDB.FindProduct(productId);
                    if (addedProduct != null)
                    {
                        if (e.ColumnIndex == MODIFY_INDEX)// Modify
                        {
                            ModifyProduct();
                        }
                        else // Delete
                        {
                            DeleteProduct();
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


        private void ModifyProduct()
        {
            frmAddProduct secondForm = new frmAddProduct();
            secondForm.isAdd = false; // modify
            secondForm.addedProduct = addedProduct;
            DialogResult result = secondForm.ShowDialog();
            if (result == DialogResult.OK) // proceeding with modification
            {
                addedProduct = secondForm.addedProduct; // new data values being added
                try
                {
                    ProductDB.UpdateProduct(addedProduct);
                    DisplayProducts();
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
        private void DeleteProduct()
        {
            if (addedProduct != null)
            {
                DialogResult result = MessageBox.Show(
                    $"Do you want to delete {addedProduct.ProdName} with the ID: {addedProduct.ProductId}?",
                    "Confirm delete", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result == DialogResult.Yes)// user confirmed
                {
                    try
                    {
                        ProductDB.DeleteProduct(addedProduct.ProductId);
                        DisplayProducts(); // refresh grid
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
            frmAddProduct secondForm = new frmAddProduct();
            secondForm.isAdd = true;
            secondForm.addedProduct = null;
            DialogResult result = secondForm.ShowDialog();
            if (result == DialogResult.OK) // proceed with add
            {
                addedProduct = secondForm.addedProduct;
                if (addedProduct != null)
                {
                    try
                    {
                        ProductDB.AddProduct(addedProduct);
                        DisplayProducts(); // refresh grid
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
