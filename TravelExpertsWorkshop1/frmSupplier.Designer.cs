namespace TravelExpertsWorkshop1
{
    partial class frmSupplier
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSupplier));
            dgvSuppliersData = new DataGridView();
            btnAdd = new Button();
            btnExit = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSuppliersData).BeginInit();
            SuspendLayout();
            // 
            // dgvSuppliersData
            // 
            dgvSuppliersData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSuppliersData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvSuppliersData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSuppliersData.Location = new Point(12, 12);
            dgvSuppliersData.Name = "dgvSuppliersData";
            dgvSuppliersData.RowTemplate.Height = 25;
            dgvSuppliersData.Size = new Size(486, 327);
            dgvSuppliersData.TabIndex = 0;
            dgvSuppliersData.CellContentClick += dgvSuppliersData_CellContentClick;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.None;
            btnAdd.Location = new Point(360, 357);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(56, 35);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "&Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.None;
            btnExit.Location = new Point(442, 357);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(56, 35);
            btnExit.TabIndex = 3;
            btnExit.Text = "&Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // frmSupplier
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(510, 404);
            Controls.Add(btnExit);
            Controls.Add(btnAdd);
            Controls.Add(dgvSuppliersData);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmSupplier";
            Text = "Suppliers";
            Load += frmSupplier_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSuppliersData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvSuppliersData;
        private Button btnAdd;
        private Button btnExit;
    }
}