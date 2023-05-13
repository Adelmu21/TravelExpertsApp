using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TravelExpertsData;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TravelExpertsWorkshop1
{
    public partial class frmPackages : Form
    {

        private const int DETAILS_INDEX = 4;
        //private const int DELETE_INDEX = 9;

        public Package addedPackage;
        public Package updatedPackage;
        public Supplier addedSupplier;
        private Product addedProduct;

        public frmPackages()
        {
            InitializeComponent();
        }


        private void frmPackages_Load(object sender, EventArgs e)
        {
            DisplayPackages();
        }
        //public void myDataList()
        //{
        //    List<PackageDTO> packages = PackageDB.GetPackages();
        //    List<ProductDTO> products = ProductDB.GetProducts();
        //    //List<PackageDTO> packages = PackageDB.GetPackages();

        //    return myData;
        //}

        private void DisplayPackages()
        {

            //dgvPackageData.Columns.Clear();// reset columns
            //List<PackageDTO> packages = PackageDB.GetPackages();
            ////List<ProductDTO> products = ProductDB.GetProducts();
            //dgvPackageData.DataSource = packages;

            List<CombinedDataModel> combinedDataList = new List<CombinedDataModel>();

            using (var dbContext = new TravelExpertsContext())
            {
                combinedDataList = (from pps in dbContext.PackagesProductsSuppliers
                                    join ps in dbContext.ProductsSuppliers on pps.ProductSupplierId equals ps.ProductSupplierId
                                    join p in dbContext.Products on ps.ProductId equals p.ProductId
                                    join s in dbContext.Suppliers on ps.SupplierId equals s.SupplierId
                                    join pkg in dbContext.Packages on pps.PackageId equals pkg.PackageId
                                    group new { p, s } by new { pkg.PackageId, pkg.PkgName, pkg.PkgBasePrice, pkg.PkgAgencyCommission } into grp
                                    select new CombinedDataModel
                                    {
                                        //PackageId = pkg.PackageId,
                                        //PkgName = pkg.PkgName,
                                        //PkgBasePrice = pkg.PkgBasePrice,
                                        //PkgAgencyCommission = pkg.PkgAgencyCommission,
                                        //ProdName = p.ProdName,
                                        //SupName = s.SupName,

                                        PackageId = grp.Key.PackageId,
                                        PkgName = grp.Key.PkgName,
                                        PkgBasePrice = grp.Key.PkgBasePrice,
                                        PkgAgencyCommission = grp.Key.PkgAgencyCommission,
                                        //ProdName = string.Join(", ", grp.Select(x => x.p.ProdName)),

                                    }).ToList();
            }
            dgvPackageData.DataSource = combinedDataList;



            // Step 6: Set the DataPropertyName property of the columns to the corresponding property names of CombinedData class
            //dgvPackageData.Columns["SupName"].DataPropertyName = "SupName";
            //dgvPackageData.Columns["ProdName"].DataPropertyName = "ProdName";
            //dgvPackageData.Columns["SupName2"].DataPropertyName = "SupName";
            //dgvPackageData.Columns["ProdName2"].DataPropertyName = "ProdName";
            dgvPackageData.Columns["PkgName"].DataPropertyName = "PkgName";
            dgvPackageData.Columns["PkgBasePrice"].DataPropertyName = "PkgBasePrice";
            dgvPackageData.Columns["PkgAgencyCommission"].DataPropertyName = "PkgAgencyCommission";

            dgvPackageData.Columns[0].HeaderText = "Package ID";
            dgvPackageData.Columns[1].HeaderText = "Package Name";
            dgvPackageData.Columns[2].HeaderText = "Base Price";
            dgvPackageData.Columns[3].HeaderText = "Agency Commission";
            dgvPackageData.Columns[0].Width = 110;
            dgvPackageData.Columns[1].Width = 300;
            dgvPackageData.Columns[2].Width = 150;
            dgvPackageData.Columns[3].Width = 150;

            //// Add a new column for SupName
            //DataGridViewTextBoxColumn supNameColumn = new DataGridViewTextBoxColumn();
            //supNameColumn.HeaderText = "SupName 2";
            //supNameColumn.Name = "supNameColumn";
            //dgvPackageData.Columns.Add(supNameColumn);

            //// Step 5: Define the columns of the DataGridView
            //dgvPackageData.Columns.Add("SupName", "Supplier Name");
            //dgvPackageData.Columns.Add("ProdName", "Product Name");
            //dgvPackageData.Columns.Add("PkgName", "Package Name");
            //dgvPackageData.Columns.Add("PkgId", "Package ID");




            var detailsColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                Text = "Details",
                HeaderText = ""
            };
            dgvPackageData.Columns.Add(detailsColumn);

            //var deleteColumn = new DataGridViewButtonColumn()
            //{
            //    UseColumnTextForButtonValue = true,
            //    Text = "Delete",
            //    HeaderText = ""
            //};
            //dgvPackageData.Columns.Add(deleteColumn);


        }



        private void dgvPackageData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //e.ColumnIndex is the column where the click happened
            // e.RowIndex is the row where the click happened
            if (e.RowIndex >= 0 && e.ColumnIndex == DETAILS_INDEX) // || e.ColumnIndex == DELETE_INDEX)
            {
                // int packageId = int.Parse(dgvPackageData.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());

                int packageId = Convert.ToInt32(dgvPackageData.Rows[e.RowIndex].Cells["PackageId"].Value.ToString().Trim());
                //DataGridViewRow row = dgvPackageData.Rows[e.RowIndex];
                //selectedValue = row.Cells[0].Value.ToString();

                try
                {
                    addedPackage = PackageDB.FindPackage(packageId);
                    if (addedPackage != null)
                    {
                        if (e.ColumnIndex == DETAILS_INDEX)// Modify
                        {
                            DetailsOfPackage();
                        }
                        //else // Delete
                        //{
                        //    DeletePackage();
                        //}
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while finding a product: " +
                        ex.Message, ex.GetType().ToString());
                }
            }

        }



        private void DetailsOfPackage()
        {


            frmDetails secondForm = new frmDetails();

            //int packageId = Convert.ToInt32(dgvPackageData.SelectedRows[0].Cells["PackageId"].Value.ToString().Trim());

            secondForm.addedPackage = addedPackage;
            secondForm.addedProduct = addedProduct;

            DialogResult result = secondForm.ShowDialog();

            if (result == DialogResult.OK) // proceeding with modification
            {

                addedPackage = secondForm.addedPackage; // new data values being added
                addedProduct = secondForm.addedProduct;

                try
                {
                    PackageDB.UpdatePackage(addedPackage);
                    ProductDB.UpdateProduct(addedProduct);


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






        private void btnAddPackage_Click(object sender, EventArgs e)
        {
            AddModifySupProd secondForm = new AddModifySupProd();
            secondForm.isAdd = true;
            secondForm.addedProduct = null;
            DialogResult result = secondForm.ShowDialog();
            if (result == DialogResult.OK) // proceed with add
            {
                addedPackage = secondForm.addedPackage;
                if (addedPackage != null)
                {
                    try
                    {
                        PackageDB.AddPackage(addedPackage);
                        DisplayPackages(); // refresh grid
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
