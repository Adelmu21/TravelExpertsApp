namespace TravelExpertsWorkshop1
{
    partial class frmPackages
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPackages));
            dgvPackageData = new DataGridView();
            btnExit = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPackageData).BeginInit();
            SuspendLayout();
            // 
            // dgvPackageData
            // 
            dgvPackageData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPackageData.Location = new Point(16, 15);
            dgvPackageData.Margin = new Padding(5, 3, 5, 3);
            dgvPackageData.Name = "dgvPackageData";
            dgvPackageData.RowHeadersWidth = 51;
            dgvPackageData.RowTemplate.Height = 29;
            dgvPackageData.Size = new Size(939, 310);
            dgvPackageData.TabIndex = 0;
            dgvPackageData.CellContentClick += dgvPackageData_CellContentClick;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(840, 331);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(90, 38);
            btnExit.TabIndex = 1;
            btnExit.Text = "&Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // frmPackages
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(969, 381);
            Controls.Add(btnExit);
            Controls.Add(dgvPackageData);
            Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 3, 5, 3);
            Name = "frmPackages";
            Text = "Packages";
            Load += frmPackages_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPackageData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvPackageData;
        private Button btnExit;
    }
}