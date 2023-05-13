namespace TravelExpertsWorkshop1
{
    partial class frmAddSupplier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddSupplier));
            label1 = new Label();
            label2 = new Label();
            txtSupplierID = new TextBox();
            txtSupplierName = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 44);
            label1.Name = "label1";
            label1.Size = new Size(79, 19);
            label1.TabIndex = 0;
            label1.Text = "Supplier ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 96);
            label2.Name = "label2";
            label2.Size = new Size(101, 19);
            label2.TabIndex = 1;
            label2.Text = "Supplier Name:";
            // 
            // txtSupplierID
            // 
            txtSupplierID.Location = new Point(159, 41);
            txtSupplierID.Name = "txtSupplierID";
            txtSupplierID.Size = new Size(100, 25);
            txtSupplierID.TabIndex = 2;
            txtSupplierID.Tag = "Supplier ID";
            // 
            // txtSupplierName
            // 
            txtSupplierName.Location = new Point(159, 93);
            txtSupplierName.Name = "txtSupplierName";
            txtSupplierName.Size = new Size(201, 25);
            txtSupplierName.TabIndex = 3;
            txtSupplierName.Tag = "Supplier Name";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(268, 147);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(59, 32);
            btnSave.TabIndex = 4;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(333, 147);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(59, 32);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // frmAddSupplier
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(404, 191);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtSupplierName);
            Controls.Add(txtSupplierID);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmAddSupplier";
            Text = "frmAddSupplier";
            Load += frmAddSupplier_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtSupplierID;
        private TextBox txtSupplierName;
        private Button btnSave;
        private Button btnCancel;
    }
}