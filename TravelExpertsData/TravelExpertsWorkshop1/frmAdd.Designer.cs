namespace TravelExpertsWorkshop1
{
    partial class frmAdd
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
            label1 = new Label();
            cmbProduct = new ComboBox();
            label2 = new Label();
            cmbSupplier = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            txtPkgID = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(76, 93);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(67, 21);
            label1.TabIndex = 0;
            label1.Text = "Product:";
            // 
            // cmbProduct
            // 
            cmbProduct.FormattingEnabled = true;
            cmbProduct.Location = new Point(175, 90);
            cmbProduct.Name = "cmbProduct";
            cmbProduct.Size = new Size(288, 29);
            cmbProduct.TabIndex = 1;
            cmbProduct.SelectedIndexChanged += cmbProduct_SelectedIndexChanged_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(72, 140);
            label2.Name = "label2";
            label2.Size = new Size(71, 21);
            label2.TabIndex = 2;
            label2.Text = "Supplier:";
            // 
            // cmbSupplier
            // 
            cmbSupplier.FormattingEnabled = true;
            cmbSupplier.Location = new Point(175, 137);
            cmbSupplier.Name = "cmbSupplier";
            cmbSupplier.Size = new Size(288, 29);
            cmbSupplier.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(271, 209);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(77, 33);
            btnSave.TabIndex = 4;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(386, 209);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(77, 33);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtPkgID
            // 
            txtPkgID.Location = new Point(175, 37);
            txtPkgID.Name = "txtPkgID";
            txtPkgID.ReadOnly = true;
            txtPkgID.Size = new Size(64, 29);
            txtPkgID.TabIndex = 6;
            // 
            // frmAdd
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(575, 270);
            Controls.Add(txtPkgID);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(cmbSupplier);
            Controls.Add(label2);
            Controls.Add(cmbProduct);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "frmAdd";
            Text = "Add Product and Supplier";
            Load += frmAdd_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbProduct;
        private Label label2;
        private ComboBox cmbSupplier;
        private Button btnSave;
        private Button btnCancel;
        private TextBox txtPkgID;
    }
}