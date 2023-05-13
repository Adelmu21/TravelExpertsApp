namespace TravelExpertsWorkshop1
{
    partial class frmProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProduct));
            dgvProductsData = new DataGridView();
            btnAdd = new Button();
            btnExit = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProductsData).BeginInit();
            SuspendLayout();
            // 
            // dgvProductsData
            // 
            dgvProductsData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductsData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvProductsData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductsData.Location = new Point(12, 12);
            dgvProductsData.Name = "dgvProductsData";
            dgvProductsData.RowTemplate.Height = 25;
            dgvProductsData.Size = new Size(445, 327);
            dgvProductsData.TabIndex = 1;
            dgvProductsData.CellContentClick += dgvProductsData_CellContentClick;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.None;
            btnAdd.Location = new Point(339, 353);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(56, 35);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "&Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.None;
            btnExit.Location = new Point(401, 353);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(56, 35);
            btnExit.TabIndex = 4;
            btnExit.Text = "&Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // frmProduct
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            ClientSize = new Size(469, 400);
            Controls.Add(btnExit);
            Controls.Add(btnAdd);
            Controls.Add(dgvProductsData);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "frmProduct";
            Text = "Products";
            Load += frmProduct_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProductsData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvProductsData;
        private Button btnAdd;
        private Button btnExit;
    }
}